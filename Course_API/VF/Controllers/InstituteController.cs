using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course_API.CustomAttribute;
using Course_API.Helpers;
using Course_API.Infrastructures;
using Course_API.Models;
using Course_API.Models.ReturnModels.InstituteReturnModels;
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
    public class InstituteController : BaseController
    {
        public InstituteController(IUnitOfWork unitOfWork, UserManager<Trainee> userManager, IHttpContextAccessor httpCotext) : base(unitOfWork, userManager, httpCotext)
        {
            
        }


        [HttpGet]
        public IActionResult GetInstituteFlag()
        {
            var institutes = unitOfWork.GetRepository<InstitudeFlag>().Get().ToList();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, institutes);
        }

        [HttpGet]
        public IActionResult GetInstituteStatus()
        {
            var instituteStatus = unitOfWork.GetRepository<InstituteStatus>().Get().ToList();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, instituteStatus);
        }


        [HttpGet]
        public IActionResult GetInstituteType()
        {
            var instituteTypes = unitOfWork.GetRepository<InstituteType>().Get().ToList();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, instituteTypes);
        }

        [HttpGet]
        public IActionResult GetInstitute(int page, int pageSize)
        {

            var lstInstitudes = new List<InstitudeBriefReturnModel>();
            var institudes = unitOfWork.GetRepository<Institute>().Get().Skip((page - 1) * pageSize).Take(pageSize).ToList();

            foreach(var item in institudes)
            {
                var institudeBriefItem = new InstitudeBriefReturnModel()
                {
                    Id = item.Id,
                    Image = item.Logo,
                };

                lstInstitudes.Add(institudeBriefItem);
            }

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, lstInstitudes);
        }

    }


}
