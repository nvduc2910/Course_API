using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course_API.CustomAttribute;
using Course_API.Helpers;
using Course_API.Infrastructures;
using Course_API.Models;
using Course_API.Models.DatabaseModels.CourseModels;
using Course_API.Models.TrainerModels;
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
    public class EntryDataController : BaseController
    {
        public EntryDataController(IUnitOfWork unitOfWork, UserManager<Trainee> userManager, IHttpContextAccessor httpCotext) : base(unitOfWork, userManager, httpCotext)
        {
        }

        [HttpPost]
        public async Task<IActionResult> EntryCountry(string name)
        {
            var countryItem = new Country()
            {
                Name = name,
            };

            await unitOfWork.GetRepository<Country>().InsertAsync(countryItem);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "ADDED");
        }

        [HttpPost]
        public async Task<IActionResult> EntryCity(int countryId, string name)
        {
            var cityItem = new City()
            {
                CountryId = countryId,
                Name = name,
            };

            await unitOfWork.GetRepository<City>().InsertAsync(cityItem);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "ADDED");
        }


        [HttpPost]
        public async Task<IActionResult> ActiveStatus(string name)
        {
            var activeStatus = new ActiveStatus()
            {

                Status = name,
            };

            await unitOfWork.GetRepository<ActiveStatus>().InsertAsync(activeStatus);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "ADDED");
        }


        #region InstituteData


        [HttpPost]
        public async Task<IActionResult> InsertInstituteFlag(string flag)
        {

            var instituteFlag = new InstitudeFlag()
            {
                Flag = flag,
            };

            var institutes = await unitOfWork.GetRepository<InstitudeFlag>().InsertAsync(instituteFlag);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, institutes);
        }

        [HttpPost]
        public async Task<IActionResult> InsertInstituteStatus(string status)
        {
            var instituteStatus = new InstituteStatus()
            {
                Status = status,
            };

            var institutes = await unitOfWork.GetRepository<InstituteStatus>().InsertAsync(instituteStatus);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, institutes);

        }


        [HttpPost]
        public async Task<IActionResult> InsertInstituteType(string type)
        {
            var instituteType = new InstituteType()
            {
                Type = type,
            };

            var institutes = await unitOfWork.GetRepository<InstituteType>().InsertAsync(instituteType);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, institutes);
        }

        #endregion


        #region Course

        [HttpPost]
        public async Task<IActionResult> InsertCancelReason(string reason)
        {
            var courseReason = new CourseCancelReason()
            {
                Reason = reason,
            };

            var courseReasonInserted = await unitOfWork.GetRepository<CourseCancelReason>().InsertAsync(courseReason);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseReasonInserted);
        }


        [HttpPost]
        public async Task<IActionResult> InsertCourseCategory(string category)
        {
            var courseCategory = new CourseCategory()
            {
                Category = category,
            };

            var courseCategoryInserted = await unitOfWork.GetRepository<CourseCategory>().InsertAsync(courseCategory);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseCategoryInserted);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCourseFlag(string flag)
        {
            var courseFlag = new CourseFlag()
            {
                Flag = flag,
            };

            var courseFlagInserted = await unitOfWork.GetRepository<CourseFlag>().InsertAsync(courseFlag);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseFlagInserted);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCourseLanguage(string language)
        {
            var courseLanguage = new CourseLanguage()
            {
                Language = language,
            };

            var courseLanguageInserted = await unitOfWork.GetRepository<CourseLanguage>().InsertAsync(courseLanguage);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseLanguageInserted);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCourseLevel(string level)
        {
            var courseLevel = new CourseLevel()
            {
                Level = level,
            };

            var courseLevelInserted = await unitOfWork.GetRepository<CourseLevel>().InsertAsync(courseLevel);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseLevelInserted);
        }


        [HttpPost]
        public async Task<IActionResult> InsertCourseScope(string scope)
        {
            var courseScope = new CourseScope()
            {
                Scope = scope,
            };

            var courseScopeInserted = await unitOfWork.GetRepository<CourseScope>().InsertAsync(courseScope);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseScopeInserted);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCourseStatus(string status)
        {
            var courseStatus = new CourseStatus()
            {
                Status = status,
            };

            var courseStatusInserted = await unitOfWork.GetRepository<CourseStatus>().InsertAsync(courseStatus);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseStatusInserted);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCourseType(string type)
        {
            var courseType = new CourseType()
            {
                Type = type,
            };

            var courseTypeInserted = await unitOfWork.GetRepository<CourseType>().InsertAsync(courseType);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseTypeInserted);
        }


        #endregion


        #region Currency


        [HttpPost]
        public async Task<IActionResult> InsertCurrency(string currencyName, string currencyCode)
        {
            var currency = new Currency()
            {
                CurrencyCode = currencyCode,
                Name = currencyName,
            };

            var currencyInserted = await unitOfWork.GetRepository<Currency>().InsertAsync(currency);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, currencyInserted);
        }


        #endregion

        #region Currency


        [HttpPost]
        public async Task<IActionResult> InsertOrgrainzer([FromBody] Organizer organizer)
        {
            

            var currencyInserted = await unitOfWork.GetRepository<Organizer>().InsertAsync(organizer);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, currencyInserted);
        }


        #endregion


        [HttpPost]
        public async Task<IActionResult> InsertOrginerStatus(string status)
        {
            var currency = new OrganizerStatus()
            {
                Status = status,
            };

            var currencyInserted = await unitOfWork.GetRepository<OrganizerStatus>().InsertAsync(currency);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, currencyInserted);
        }


        [HttpPost]
        public async Task<IActionResult> InsertNational(string nationnal, bool status)
        {
            var currency = new Nationality()
            {
                Status = status,
                National = nationnal,
            };

            var currencyInserted = await unitOfWork.GetRepository<Nationality>().InsertAsync(currency);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, currencyInserted);
        }
    }
}
