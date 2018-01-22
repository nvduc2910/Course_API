using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Course_API.CustomAttribute;
using Course_API.Exceptions;
using Course_API.Helpers;
using Course_API.Infrastructures;
using Course_API.Models;
using Course_API.Models.BindingModels.Institute;
using Course_API.Models.DatabaseModels.RelianceModels;
using Course_API.Models.ReturnModels.InstituteReturnModels;
using Course_API.Models.ReturnModels.Webs;
using Course_API.Repository;
using Course_API.Resources;
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
        public InstituteController(IUnitOfWork unitOfWork, UserManager<User> userManager, IHttpContextAccessor httpCotext, IMapper mapper) : base(unitOfWork, userManager, httpCotext, mapper)
        {

        }

        #region UpdateInstituteProfile
        [HttpPost]
        public async Task<IActionResult> UpdateInstituteProfile([FromBody] InstituteDTO institute)
        {
            var data = mapper.Map<InstituteDTO, Institute>(institute);
            data.UserId = UserIdRequested();
            var dataInserted = await unitOfWork.GetRepository<Institute>().InsertAsync(data);

            foreach(var item in institute.Reliance)
            {
                var relianceItem = new Reliance()
                {
                    InstituteId = dataInserted.Id,
                    Logo = item.Logo,
                    RelianceStatusId = item.Status,
                    Name = item.Name,
                };
                await unitOfWork.GetRepository<Reliance>().InsertAsync(relianceItem);
            }

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, dataInserted);
        }

        #endregion

        #region GetInstitueProfile
        [HttpGet]
        public IActionResult GetInstitueProfile()
        {
            var data = unitOfWork.GetRepository<Institute>().Get(s => s.UserId == UserIdRequested(), null, "Country,City,InstituteType,Reliance").FirstOrDefault();
            if(data == null)
                throw new UserNotExistsException(Account.UsetNotFound);

            var response = mapper.Map<Institute, InstituteProfileReturnModel>(data);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, response);
        }

        #endregion

        #region GetInstituteFlag

        [HttpGet]
        public IActionResult GetInstituteFlag()
        {
            var institutes = unitOfWork.GetRepository<InstitudeFlag>().Get().ToList();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, institutes);
        }

        #endregion

        #region GetInstituteStatus

        [HttpGet]
        public IActionResult GetInstituteStatus()
        {
            var instituteStatus = unitOfWork.GetRepository<InstituteStatus>().Get().ToList();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, instituteStatus);
        }

        #endregion

        #region GetInstituteType

        [HttpGet]
        public IActionResult GetInstituteType()
        {
            var instituteTypes = unitOfWork.GetRepository<InstituteType>().Get().ToList();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, instituteTypes);
        }

        #endregion

        #region GetInstitute
        [HttpGet]
        public IActionResult GetInstitute(int page, int pageSize)
        {

            var lstInstitudes = new List<InstitudeBriefReturnModel>();
            var institudes = unitOfWork.GetRepository<Institute>().Get().Skip((page - 1) * pageSize).Take(pageSize).ToList();

            foreach (var item in institudes)
            {
                var institudeBriefItem = new InstitudeBriefReturnModel()
                {
                    Id = item.Id,
                    Image = item.Logo,
                    Name = item.Name,
                };

                lstInstitudes.Add(institudeBriefItem);
            }

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, lstInstitudes);
        }

        #endregion

        #region InstituteDetails
        [HttpGet]
        public IActionResult InstituteDetails(int instituteId)
        {
            var institute = unitOfWork.GetRepository<Institute>().Get(s => s.Id == instituteId, null, "Course,Country,City").FirstOrDefault();

            if (institute == null)

                return ApiResponder.RespondFailureTo(HttpStatusCode.Ok, "Institute not found", ErrorCodes.TrainerNotFound);

            var instituteDetailsReturnModel = new InstituteDetailsReturnModel()
            {
                Id = institute.Id,
                Name = institute.Name,
                Country = institute.Country.Name,
                City = institute.City.Name,
                About = institute.About,
                Logo = institute.Logo,
                Contact = new InstituteContactReturnModel()
                {
                    ContactNumber = institute.TelePhoneNumber,
                    Email = institute.Email,
                    Facebook = institute.Facebook,
                    Twitter = institute.Twitter,
                    Instagram = institute.Instagram,

                },
                OldCourse = new List<InstituteCounserBriefReturModel>(),
                NewCourse = new List<InstituteCounserBriefReturModel>(),

            };

            foreach (var item in institute.Course)
            {
                if (item.EndDate < DateTime.Now)
                {
                    var oldCourseItem = new InstituteCounserBriefReturModel()
                    {
                        Id = item.Id,
                        Image = item.Image,

                    };
                    instituteDetailsReturnModel.OldCourse.Add(oldCourseItem);
                }

                else if (item.StartDate > DateTime.Now)
                {
                    var newCourseItem = new InstituteCounserBriefReturModel()
                    {
                        Id = item.Id,
                        Image = item.Image,

                    };
                    instituteDetailsReturnModel.NewCourse.Add(newCourseItem);
                }
            }

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, instituteDetailsReturnModel);
        }

        #endregion

        #region DeleteInstitude
        [HttpDelete]
        public async Task<IActionResult> DeleteInstitude(int institudeId)
        {
            var institute = unitOfWork.GetRepository<Institute>().Get(s => s.Id == institudeId, null, "Course,Country,City").FirstOrDefault();

            if (institute == null)

                return ApiResponder.RespondFailureTo(HttpStatusCode.Ok, "Institute not found", ErrorCodes.TrainerNotFound);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Deleted");

        }

        #endregion
    }
}
