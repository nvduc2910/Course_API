using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course_API.CustomAttribute;
using Course_API.Helpers;
using Course_API.Infrastructures;
using Course_API.Models;
using Course_API.Models.DatabaseModels;
using Course_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Course_API.Controllers
{

    [Route("api/[controller]/[Action]")]
    [ValidateModel]
    [HandleException]
    public class ContactController : BaseController
    {
        public ContactController(IUnitOfWork unitOfWork, UserManager<User> userManager, IHttpContextAccessor httpCotext) : base(unitOfWork, userManager, httpCotext)
        {
        }

        [HttpGet]
        public IActionResult GetContactUse()
        {
            var contactUs = unitOfWork.GetRepository<ContactUs>().Get().FirstOrDefault();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, contactUs);
        }
    }
}
