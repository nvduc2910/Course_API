using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Course_API.Repository;
using Microsoft.AspNetCore.Identity;
using Course_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Course_API.Exceptions;
using Course_API.Resources;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Course_API.Controllers
{
    /// <summary>
    /// Base Controller
    /// </summary>
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        public StringValues token;
        /// <summary>
        /// Unit of work instance
        /// </summary>
        public IUnitOfWork unitOfWork;
        /// <summary>
        /// usermanager instance
        /// </summary>
        public UserManager<User> userManager;
        /// <summary>
        /// httpContext instance
        /// </summary>
        public IHttpContextAccessor httpContext;

        public  IMapper mapper;
        private IHttpContextAccessor httpCotext;

        public BaseController(IUnitOfWork unitOfWork, UserManager<User> userManager, IHttpContextAccessor httpCotext)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.httpCotext = httpCotext;
        }

        /// <summary>
        /// Contructor of base controller
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="userManager"></param>
        public BaseController(IUnitOfWork unitOfWork, UserManager<User> userManager, IHttpContextAccessor httpCotext, IMapper mapper)
        {
            this.httpContext = httpCotext;
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [NonAction]
        public string HeaderLanguage()
        {
            var language = this.httpContext.HttpContext.Request?.Headers["Accept-Language"];
            return language.ToString();
        }

        [NonAction]
        public int UserIdRequested()
        {
            var userId = Convert.ToInt32(userManager.GetUserId(User));
            if (userId != 0)
                return userId;
            else 
                throw new UserNotExistsException(Account.UsetNotFound); 
        }
    }
}
