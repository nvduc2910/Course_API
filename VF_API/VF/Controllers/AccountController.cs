﻿using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Course_API.Models;
using Microsoft.AspNetCore.Identity;
using Course_API.Models.BindingModels;
using Course_API.Infrastructures;
using Course_API.Exceptions;
using Course_API.Resources;
using Course_API.Helpers;
using Course_API.CustomAttribute;
using Course_API.Options;
using Course_API.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Course_API.Repository;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Course_API.Enums;
using Course_API.Models.BindingModels.AuthenticationModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Course_API.Controllers
{
    /// <summary>
    /// This class is used as an api for the 
    /// requests 1.
    /// </summary>
    /// 

    [Route("api/[controller]/[Action]")]
    [ValidateModel]
    [HandleException]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JwtIssuerOptions jwtIssuerOptions;
        private readonly IFacebookProvider facebookProvider;
        private readonly IGooglePlusProvider googleProvider;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpCotext;
        private readonly IEmailSender emailSender;
        private const int PinCodeExpirationTime = 24;
        private readonly IStringLocalizer<ValidationModel> localizerValidation;
        private readonly IStringLocalizer<Account> localizerAccount;

        /// <summary>
        /// Contructor
        /// </summary>
        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration configuration,
            IFacebookProvider facebookProvider, IOptions<JwtIssuerOptions> jwtOptions, SignInManager<ApplicationUser> signInManager, IUnitOfWork unitOfWork, IHttpContextAccessor httpCotext, IGooglePlusProvider googleProvider, IEmailSender emailSender, IStringLocalizer<ValidationModel> localizerValidation, IStringLocalizer<Account> localizerAccount)
        {
            this.userManager = userManager;
            this.facebookProvider = facebookProvider;
            this.signInManager = signInManager;
            this.unitOfWork = unitOfWork;
            this.httpCotext = httpCotext;
            jwtIssuerOptions = jwtOptions.Value;
            this.googleProvider = googleProvider;
            this.emailSender = emailSender;
            this.localizerValidation = localizerValidation;
            this.localizerAccount = localizerAccount;
        }

        /// <summary>
        /// Login with server
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(loginModel.Email);

            if (user == null)
                throw new UserNotExistsException(localizerAccount["UserNotFound"]);

            bool result = await userManager.CheckPasswordAsync(user, loginModel.Password);

            if (!result)
                throw new IncorrectPasswordException(localizerAccount["IncorrectPassword"]);

            user.DeviceToken = loginModel.DeviceToken;

            await unitOfWork.GetRepository<ApplicationUser>().UpdateAsync(user);

            return await RespondJwtTokenTo(user, false);
        }


        /// <summary>
        /// Register personal account with server
        /// </summary>
        /// <param name="registerModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterPersonalAccount([FromBody] PersonalAccountRegisterBindModel personalModel)
        {
            ApplicationUser user = await RegisterPersonalUser(personalModel.Email, personalModel.Password,  personalModel.FullName, personalModel.CompanyName, personalModel.DeviceToken, UserRole.Personal);

            if (user == null)

                return ApiResponder.RespondFailureTo(HttpStatusCode.Ok, localizerAccount["RegisterFail"], ErrorCodes.RegisterFailed);

            return await RespondJwtTokenTo(user, false);
        }

        
        /// <summary>
        /// Forgot password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            ApplicationUser currentUser = await userManager.FindByEmailAsync(email);

            if (currentUser == null)
                throw new UserNotExistsException(localizerAccount["UserNotFound"]);

            int pinCode = new Random().Next(100000, 999999);
            currentUser.PinCode = pinCode;
            currentUser.PinCodeExpiration = DateTime.UtcNow.AddHours(PinCodeExpirationTime);

            IdentityResult updateUserResult = await userManager.UpdateAsync(currentUser);

            if (!updateUserResult.Succeeded)
                throw new IdentityException(updateUserResult.Errors.FirstOrDefault().Description);

            string message = System.IO.File.ReadAllText(@"./HtmlPages/Email.html");

            await emailSender.SendEmailAsync(email, "Pin Code Confirmation",
                String.Format(message, currentUser.UserName, pinCode.ToString()));

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Please check your email to setup new password");
        }


        /// <summary>
        /// Reset password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="newPassword"></param>
        /// <param name="pinCode"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<IActionResult> ResetPassword(string email, string newPassword, int pinCode)
        {
            ApplicationUser currentUser = await userManager.FindByEmailAsync(email);

            if (currentUser == null)
                throw new UserNotExistsException(localizerAccount["UserNotFound"]);

            if (currentUser.PinCode != pinCode)
                throw new InvalidPinCodeException(localizerAccount["InvalidPinCode"]);

            if (currentUser.PinCodeExpiration < DateTime.UtcNow)
                throw new PinCodeExpiredException(localizerAccount["PinCodeExpired"]);

            IdentityResult deletePasswordResult = await userManager.RemovePasswordAsync(currentUser);

            if (!deletePasswordResult.Succeeded)
                throw new IdentityException(deletePasswordResult.Errors.FirstOrDefault().Description);

            IdentityResult addPasswordResult = await userManager.AddPasswordAsync(currentUser, newPassword);

            if (!addPasswordResult.Succeeded)
                throw new IdentityException(addPasswordResult.Errors.FirstOrDefault().Description);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Update new password sucessfully");
        }
       

        #region Mehods
        [NonAction]
        private async Task<ApplicationUser> RegisterPersonalUser(string email, string password, string fullName, string companyName, string deviceToken, UserRole roleId)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Email = email,
                UserName = email,
                FullName = fullName,
            };

            IdentityResult userCreationResult = password == null
                ? await userManager.CreateAsync(user)
                : await userManager.CreateAsync(user, password);

            if (!userCreationResult.Succeeded)
                throw new IdentityException(userCreationResult.Errors.FirstOrDefault().Description);

            return user;
        }

        [NonAction]
        private async Task<ObjectResult> RespondJwtTokenTo(ApplicationUser user, bool isFirstTime)
        {
            ClaimsPrincipal principal = await signInManager.CreateUserPrincipalAsync(user);
            string encodedJwt = JwtEncoder.EncodeSecurityToken(jwtIssuerOptions, principal);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, new
            {
                access_token = encodedJwt,
                full_name = user.FullName,
                user_id = user.Id,
                first_time = isFirstTime,
            });
        }

        #endregion
    }
}