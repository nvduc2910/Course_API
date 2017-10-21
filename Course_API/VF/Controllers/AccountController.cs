using System.Linq;
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
using System.Collections.Generic;
using Course_API.Models.ReturnModels;


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
        private readonly UserManager<Trainee> userManager;
        private readonly JwtIssuerOptions jwtIssuerOptions;
        private readonly IFacebookProvider facebookProvider;
        private readonly IGooglePlusProvider googleProvider;
        private readonly SignInManager<Trainee> signInManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpCotext;
        private readonly IEmailSender emailSender;
        private const int PinCodeExpirationTime = 24;


        /// <summary>
        /// Contructor
        /// </summary>
        public AccountController(UserManager<Trainee> userManager, IConfiguration configuration,
            IFacebookProvider facebookProvider, IOptions<JwtIssuerOptions> jwtOptions, SignInManager<Trainee> signInManager, IUnitOfWork unitOfWork, IHttpContextAccessor httpCotext, IGooglePlusProvider googleProvider, IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.facebookProvider = facebookProvider;
            this.signInManager = signInManager;
            this.unitOfWork = unitOfWork;
            this.httpCotext = httpCotext;
            jwtIssuerOptions = jwtOptions.Value;
            this.googleProvider = googleProvider;
            this.emailSender = emailSender;

           
        }

        /// <summary>
        /// Login with server
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            Trainee user = await userManager.FindByNameAsync(loginModel.PhoneNumber);

            if (user == null)
                throw new UserNotExistsException(Account.UsetNotFound);

            bool result = await userManager.CheckPasswordAsync(user, loginModel.Password);

            if (!result)
                throw new IncorrectPasswordException(Account.IncorrectPassword);

            user.DeviceToken = loginModel.DeviceToken;

            await unitOfWork.GetRepository<Trainee>().UpdateAsync(user);

            return await RespondJwtTokenTo(user, false);
        }


        /// <summary>
        /// Register personal account with server
        /// </summary>
        /// <param name="registerModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] PersonalAccountRegisterBindModel personalModel)
        {
            Trainee user = await Register(personalModel.PhoneNumber, personalModel.Password,  personalModel.CountryId, personalModel.CityId, personalModel.Sex);

            if (user == null)

                return ApiResponder.RespondFailureTo(HttpStatusCode.Ok, Account.RegisterFail, ErrorCodes.RegisterFailed);

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
            Trainee currentUser = await userManager.FindByEmailAsync(email);

            if (currentUser == null)
                throw new UserNotExistsException(Account.UsetNotFound);

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
            Trainee currentUser = await userManager.FindByEmailAsync(email);

            if (currentUser == null)
                throw new UserNotExistsException(Account.UsetNotFound);

            if (currentUser.PinCode != pinCode)
                throw new InvalidPinCodeException(Account.InvalidPinCode);

            if (currentUser.PinCodeExpiration < DateTime.UtcNow)
                throw new PinCodeExpiredException(Account.PinCodeExpired);

            IdentityResult deletePasswordResult = await userManager.RemovePasswordAsync(currentUser);

            if (!deletePasswordResult.Succeeded)
                throw new IdentityException(deletePasswordResult.Errors.FirstOrDefault().Description);

            IdentityResult addPasswordResult = await userManager.AddPasswordAsync(currentUser, newPassword);

            if (!addPasswordResult.Succeeded)
                throw new IdentityException(addPasswordResult.Errors.FirstOrDefault().Description);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Update new password sucessfully");
        }
       

        [HttpPost]
        public async Task<IActionResult> GetCountry()
        {
            var countrylst = new List<CountryReturnModel>();

            var countries = unitOfWork.GetRepository<Country>().Get().ToList();

            foreach(var item in countries)
            {
                var countryItemReturn = new CountryReturnModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                };

                countrylst.Add(countryItemReturn);
            }
            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, countrylst);
        }

        [HttpGet]
        public IActionResult GetCityByCountry(int countryId)
        {
            var citylst = new List<CityReturnModel>();

            var cities = unitOfWork.GetRepository<City>().Get(s => s.CountryId == countryId).ToList();

            foreach (var item in cities)
            {
                var countryItemReturn = new CityReturnModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                };

                citylst.Add(countryItemReturn);
            }
            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, citylst);
        }

        #region Mehods
        [NonAction]
        private async Task<Trainee> Register(string phonenumber, string password, int countryId, int cityId, string sex)
        {
            try
            {
                Trainee user = new Trainee()
                {

                    UserName = phonenumber,
                    CountryId = countryId,
                    CityId = cityId,
                    Gender = sex,
                    ActiveStatusId = 2,
                        
                };

                IdentityResult userCreationResult = password == null
                    ? await userManager.CreateAsync(user)
                    : await userManager.CreateAsync(user, password);

                if (!userCreationResult.Succeeded)
                    throw new IdentityException(userCreationResult.Errors.FirstOrDefault().Description);

                return user;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [NonAction]
        private async Task<ObjectResult> RespondJwtTokenTo(Trainee user, bool isFirstTime)
        {
            ClaimsPrincipal principal = await signInManager.CreateUserPrincipalAsync(user);
            string encodedJwt = JwtEncoder.EncodeSecurityToken(jwtIssuerOptions, principal);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, new
            {
                access_token = encodedJwt,
                full_name = user.Name,
                user_id = user.Id,
            });
        }

        #endregion
    }
}
