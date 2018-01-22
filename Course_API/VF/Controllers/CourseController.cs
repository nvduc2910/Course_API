using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Course_API.CustomAttribute;
using Course_API.Helpers;
using Course_API.Infrastructures;
using Course_API.Models;
using Course_API.Models.BindingModels;
using Course_API.Models.BindingModels.Course;
using Course_API.Models.DatabaseModels;
using Course_API.Models.DatabaseModels.CourseModels;
using Course_API.Models.DatabaseModels.RelModels;
using Course_API.Models.ReturnModels.CourseReturnModels;
using Course_API.Options;
using Course_API.Providers;
using Course_API.Repository;
using Course_API.Resources;
using Course_API.TaskSchedules;
using FluentScheduler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static Course_API.Models.ReturnModels.CourseReturnModels.CourseDetailsReturnModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Course_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ValidateModel]
    [HandleException]
    [Authorize()]
    public class CourseController : BaseController
    {
        private readonly IEmailSender emailSender;
        private readonly EmailOptions emailOptions;


        #region Contructors

        public CourseController(IUnitOfWork unitOfWork, UserManager<User> userManager, IHttpContextAccessor httpCotext, IEmailSender emailSender, IOptions<EmailOptions> emailOptions, IMapper mapper) : base(unitOfWork, userManager, httpCotext, mapper)
        {
            this.emailSender = emailSender;
            this.emailOptions = emailOptions.Value;

        }

        #endregion

        #region GetCourses
        [HttpGet]
        public IActionResult GetCourse(int page, int pageSize)
        {
            var lstCourseBrief = new List<CourseBriefReturnModel>();

            var courses = unitOfWork.GetRepository<Course>().Get().Skip((page - 1) * pageSize).Take(pageSize).ToList();
            foreach (var item in courses)
            {
                var courseItemBrief = new CourseBriefReturnModel()
                {
                    Id = item.Id,
                    Image = item.Image,
                };
                lstCourseBrief.Add(courseItemBrief);
            }
            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, lstCourseBrief);
        }

        #endregion

        #region GetInstitudeCourse
        [HttpGet]
        public IActionResult GetInstitudeCourse(int page, int pageSize)
        {
            var institude = unitOfWork.GetRepository<Institute>().Get(s => s.UserId == UserIdRequested()).FirstOrDefault();

            var courses = unitOfWork.GetRepository<Course>().Get(s => s.InstituteId == institude.Id, null, "Institude").Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var totalCourseItem = unitOfWork.GetContext().Course.Where(s => s.InstituteId == institude.Id).Count();

            var response = mapper.Map<List<Course>, List<CourseBriefReturnModel>>(courses);

            var objectResponse = new
            {
                courses = response,
                total = totalCourseItem,
            };

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, objectResponse);

        }

        #endregion

        #region GetCourseCategory

        [HttpGet]
        public IActionResult GetCourseCategory()
        {
            var courseCategory = unitOfWork.GetRepository<CourseCategory>().Get();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseCategory);
        }

        #endregion

        #region GetCourseFlag
        [HttpGet]
        public IActionResult GetCourseFlag()
        {
            var courseFlag = unitOfWork.GetRepository<CourseFlag>().Get();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseFlag);
        }
        #endregion

        #region GetCourseLanguage

        [HttpGet]
        public IActionResult GetCourseLanguage()
        {
            var courseLanguage = unitOfWork.GetRepository<CourseLanguage>().Get();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseLanguage);
        }

        #endregion

        #region GetCourseLevel


        [HttpGet]
        public IActionResult GetCourseLevel()
        {
            var courseLevel = unitOfWork.GetRepository<CourseLevel>().Get();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseLevel);
        }
        #endregion

        #region GetCourseScope
        [HttpGet]
        public IActionResult GetCourseScope()
        {
            var courseScope = unitOfWork.GetRepository<CourseScope>().Get();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseScope);
        }
        #endregion

        #region GetCourseStatus
        [HttpGet]
        public IActionResult GetCourseStatus()
        {
            var courseStatus = unitOfWork.GetRepository<CourseStatus>().Get();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseStatus);
        }
        #endregion

        #region GetCourseType 

        [HttpGet]
        public IActionResult GetCourseType()
        {
            var courseType = unitOfWork.GetRepository<CourseType>().Get();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseType);
        }

        #endregion

        #region GetFeaturedCourse

        [HttpGet]
        public IActionResult GetFeaturedCourse(int page, int pageSize)
        {
            var courses = unitOfWork.GetRepository<Course>().Get(null, null, "Organizer.Country.City,Institude,Currency").Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var lstCoursesBriefDetails = new List<CourseDetailsBriefReturnModel>();

            foreach (var item in courses)
            {

                var totalDay = (item.EndDate - item.StartDate).TotalDays;
                var coureseBriefDetailsItem = new CourseDetailsBriefReturnModel()
                {
                    Id = item.Id,
                    Currency = item.Currency.Name,
                    Gender = item.Gender,
                    Name = item.Name,
                    InstituteId = item.InstituteId,
                    Image = item.Image,
                    InstituteName = item.Institude.Name,
                    MainPrice = item.MainPrice,
                    MotivationPrice = item.MotivationPrice,
                    StartDate = item.StartDate,
                    TotalDay = item.TotalDay,
                    Country = item.Organizer.Country.Name,
                    City = item.Organizer.City.Name,

                };
                lstCoursesBriefDetails.Add(coureseBriefDetailsItem);
            }

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, lstCoursesBriefDetails);
        }

        #endregion

        #region CreateCourse

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseDTO course)
        {
            var institude = unitOfWork.GetRepository<Institute>().Get(s => s.UserId == UserIdRequested()).FirstOrDefault();

            var dataInsert = mapper.Map<CourseDTO, Course>(course);
            dataInsert.InstituteId = institude.Id;
            var courseInserted = await unitOfWork.GetRepository<Course>().InsertAsync(dataInsert);

            //foreach (var item in course.Trainers)
            //{
            //    var courseTrainerItem = new CourTra()
            //    {
            //        CourseId = courseInserted.Id,
            //        TrainerId = item,
            //    };
            //    await unitOfWork.GetRepository<CourTra>().InsertAsync(courseTrainerItem);
            //}

            //foreach (var item in course.Reliances)
            //{
            //    var courseRelianceItem = new CourRel()
            //    {
            //        CourseId = courseInserted.Id,
            //        RelianceId = item,
            //    };
            //    await unitOfWork.GetRepository<CourRel>().InsertAsync(courseRelianceItem);
            //}

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseInserted);
        }

        #endregion

        #region GetCourseDetails

        [HttpGet]
        public IActionResult GetCourseDetails(int courseId)
        {
            var course = unitOfWork.GetRepository<Course>().Get(s => s.Id == courseId, null, "Institude,Currency,Organizer.Country.City,CourTra.Trainer.TrainerNationality,CourRel.Reliance,CourseDayType,CourseType").FirstOrDefault();

            if (course == null)
                return ApiResponder.RespondFailureTo(HttpStatusCode.Ok, "Product not found", ErrorCodes.ProductNotFound);


            var data = mapper.Map<Course, CourseDetailsReturnModel>(course);
            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, data);

        }
        #endregion

        #region DeleteCourse
        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            var course = unitOfWork.GetRepository<Course>().Get(s => s.Id == courseId, null, "Institude,Currency,Organizer.Country.City,CourTra.Trainer.TrainerNationality,CourRel.Reliance,CourseDayType,CourseType").FirstOrDefault();

            if (course == null)
                return ApiResponder.RespondFailureTo(HttpStatusCode.Ok, "Product not found", ErrorCodes.ProductNotFound);

            foreach (var item in course.CourRel)
            {
                await unitOfWork.GetRepository<CourRel>().DeleteAsync(item);
            }

            foreach (var item in course.CourTra)
            {
                await unitOfWork.GetRepository<CourTra>().DeleteAsync(item);
            }
            foreach (var item in course.CourseDayType)
            {
                await unitOfWork.GetRepository<CourseDayType>().DeleteAsync(item);
            }
            foreach (var item in course.CourseFavorite)
            {
                await unitOfWork.GetRepository<Favorite>().DeleteAsync(item);
            }

            await unitOfWork.GetRepository<Course>().DeleteAsync(course);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Deleted");
        }

        #endregion

        #region GetCourseWaitingAppove
        [HttpGet]
        public IActionResult GetCourseWaitingAppove(int page, int pageSize)
        {
            var courses = unitOfWork.GetRepository<Course>().Get(s => s.IsApproved == false, null, "Institude").Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var totalCourseItem = unitOfWork.GetContext().Course.Where(s => s.IsApproved == false).Count();

            var response = mapper.Map<List<Course>, List<CourseBriefReturnModel>>(courses);

            var objectResponse = new
            {
                courses = response,
                total = totalCourseItem,
            };
            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, objectResponse);
        }

        #endregion

        #region ApproveCourse
        [HttpPut]
        public async Task<IActionResult> ApproveCourse(int courseId)
        {
            var course = unitOfWork.GetRepository<Course>().Get(s => s.Id == courseId, null, "Institude,Currency,Organizer.Country.City,CourTra.Trainer.TrainerNationality,CourRel.Reliance,CourseDayType,CourseType").FirstOrDefault();

            if (course == null)
                return ApiResponder.RespondFailureTo(HttpStatusCode.Ok, "Product not found", ErrorCodes.ProductNotFound);

            course.IsApproved = true;

            await unitOfWork.GetRepository<Course>().UpdateAsync(course);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Approved");
        }

        #endregion

        #region RejectCourse
        [HttpPut]
        public async Task<IActionResult> RejectCourse(int courseId)
        {
            var course = unitOfWork.GetRepository<Course>().Get(s => s.Id == courseId, null, "Institude,Currency,Organizer.Country.City,CourTra.Trainer.TrainerNationality,CourRel.Reliance,CourseDayType,CourseType").FirstOrDefault();

            if (course == null)
                return ApiResponder.RespondFailureTo(HttpStatusCode.Ok, "Product not found", ErrorCodes.ProductNotFound);

            course.IsApproved = false;

            await unitOfWork.GetRepository<Course>().UpdateAsync(course);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Rejected");
        }

        #endregion

        #region UpdateCourse
        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromBody] CourseDTO courseDTO, int courseId)
        {
            var course = unitOfWork.GetRepository<Course>().Get(s => s.Id == courseId, null, "CourTra,CourRel").FirstOrDefault();
            var dataInsert = mapper.Map<CourseDTO, Course>(courseDTO, course);

            //////delete old trainer

            //if (course.CourTra != null)
            //{
            //    foreach (var item in course.CourTra)
            //    {
            //        await unitOfWork.GetRepository<CourTra>().DeleteAsync(item);
            //    }
            //}

            ////add new trainer

            //foreach(var item in courseDTO.Trainers)
            //{
            //    var courseTrainerItem = new CourTra()
            //    {
            //        CourseId = course.Id,
            //        TrainerId = item,
            //    };
            //    await unitOfWork.GetRepository<CourTra>().InsertAsync(courseTrainerItem);
            //}

            ////delete old reliances
            //if (course.CourRel != null)
            //{
            //    foreach (var item in course.CourRel)
            //    {
            //        await unitOfWork.GetRepository<CourRel>().DeleteAsync(item);
            //    }
            //}

            ////add new reliances

            //foreach(var item in courseDTO.Reliances)
            //{
            //    var courseRelianceItem = new CourRel()
            //    {
            //        CourseId = course.Id,
            //        RelianceId = item,
            //    };
            //    await unitOfWork.GetRepository<CourRel>().InsertAsync(courseRelianceItem);
            //}

            await unitOfWork.GetRepository<Course>().UpdateAsync(dataInsert);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Updated");

        }

        #endregion


        #region SetupFavorite

        [HttpPost]
        public async Task<IActionResult> SetupFavorite([FromBody]FavoriteBindModel favoriteModel)
        {
            var userId = Convert.ToInt32(userManager.GetUserId(User));
            var favoriteInserted = unitOfWork.GetRepository<Favorite>().Get(s => s.TraineeId == userId).FirstOrDefault();

            var courseFavor = new Favorite()
            {

                CityId = favoriteModel.CityId,
                CourseScopeId = favoriteModel.CourseScopeId,
                CourseTypeId = favoriteModel.CourseTypeId,
                Gender = favoriteModel.Gender,
                TraineeId = userId,
                CountryId = favoriteModel.CountryId,
            };
            if (favoriteInserted == null)
                await unitOfWork.GetRepository<Favorite>().InsertAsync(courseFavor);

            else
            {
                favoriteInserted.CityId = favoriteModel.CityId;
                favoriteInserted.CourseTypeId = favoriteModel.CourseTypeId;
                favoriteInserted.CourseScopeId = favoriteModel.CourseScopeId;
                favoriteInserted.Gender = favoriteModel.Gender;
                favoriteInserted.TraineeId = userId;
                favoriteInserted.CountryId = favoriteModel.CountryId;

                await unitOfWork.GetRepository<Favorite>().UpdateAsync(favoriteInserted);
            }
            var courses = unitOfWork.GetRepository<Course>().Get(null, null, "Organizer.Country.City,Institude,Currency").ToList();

            var lstCoursesBriefDetails = new List<CourseDetailsBriefReturnModel>();

            foreach (var item in courses)
            {
                if (item.Organizer.CityId == favoriteModel.CityId && item.CourseTypeId == favoriteModel.CourseTypeId && item.CourseScopeId == favoriteModel.CourseScopeId && item.Gender == favoriteModel.Gender)
                {
                    var coureseBriefDetailsItem = new CourseDetailsBriefReturnModel()
                    {
                        Id = item.Id,
                        Currency = item.Currency.Name,
                        Gender = item.Gender,
                        Name = item.Name,
                        InstituteId = item.InstituteId,
                        Image = item.Name,
                        InstituteName = item.Institude.Name,
                        MainPrice = item.MainPrice,
                        MotivationPrice = item.MotivationPrice,
                        StartDate = item.StartDate,
                        TotalDay = item.TotalDay,
                        Country = item.Organizer.Country.Name,
                        City = item.Organizer.City.Name,

                    };
                    lstCoursesBriefDetails.Add(coureseBriefDetailsItem);
                }
            }

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, lstCoursesBriefDetails);
        }

        #endregion

        #region GetFavorite

        [HttpGet]
        public IActionResult GetFavorite()
        {
            var userId = Convert.ToInt32(userManager.GetUserId(User));

            var favoriteModel = unitOfWork.GetRepository<Favorite>().Get(s => s.TraineeId == userId).FirstOrDefault();

            var courses = unitOfWork.GetRepository<Course>().Get(null, null, "Organizer.Country.City,Institude,Currency").ToList();

            var lstCoursesBriefDetails = new List<CourseDetailsBriefReturnModel>();

            foreach (var item in courses)
            {
                if (item.Organizer.CityId == favoriteModel.CityId && item.CourseTypeId == favoriteModel.CourseTypeId && item.CourseScopeId == favoriteModel.CourseScopeId && item.Gender == favoriteModel.Gender)
                {
                    var coureseBriefDetailsItem = new CourseDetailsBriefReturnModel()
                    {
                        Id = item.Id,
                        Currency = item.Currency.Name,
                        Gender = item.Gender,
                        Name = item.Name,
                        InstituteId = item.InstituteId,
                        Image = item.Name,
                        InstituteName = item.Institude.Name,
                        MainPrice = item.MainPrice,
                        MotivationPrice = item.MotivationPrice,
                        StartDate = item.StartDate,
                        TotalDay = item.TotalDay,
                        Country = item.Organizer.Country.Name,
                        City = item.Organizer.City.Name,

                    };
                    lstCoursesBriefDetails.Add(coureseBriefDetailsItem);
                }
            }

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, lstCoursesBriefDetails);
        }
        #endregion

        #region Reminder

        [HttpPost]
        public IActionResult Reminder(int courseId, int day)
        {

            var userId = Convert.ToInt32(userManager.GetUserId(User));

            var user = unitOfWork.GetRepository<User>().Get(s => s.Id == userId).FirstOrDefault();

            var course = unitOfWork.GetRepository<Course>().Get(s => s.Id == courseId).FirstOrDefault();

            var jobRegistry = new JobRegistry(user.Email, course.Name, course + "is going start", course.StartDate.AddDays(-day), this.emailOptions);
            JobManager.Initialize(new JobRegistry(user.Email, course.Name, course + "is going start", course.StartDate.AddDays(-day), this.emailOptions));

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "OK");
        }

        #endregion

        #region SearchCourse
        [HttpPost]
        public IActionResult SearchCourse([FromBody]FavoriteBindModel favoriteModel)
        {
            var userId = Convert.ToInt32(userManager.GetUserId(User));

            var courses = unitOfWork.GetRepository<Course>().Get(null, null, "Organizer.Country.City,Institude,Currency").ToList();

            var lstCoursesBriefDetails = new List<CourseDetailsBriefReturnModel>();

            foreach (var item in courses)
            {
                if (item.Organizer.CityId == favoriteModel.CityId && item.CourseTypeId == favoriteModel.CourseTypeId && item.CourseScopeId == favoriteModel.CourseScopeId && item.Gender == favoriteModel.Gender)
                {
                    var coureseBriefDetailsItem = new CourseDetailsBriefReturnModel()
                    {
                        Id = item.Id,
                        Currency = item.Currency.Name,
                        Gender = item.Gender,
                        Name = item.Name,
                        InstituteId = item.InstituteId,
                        Image = item.Name,
                        InstituteName = item.Institude.Name,
                        MainPrice = item.MainPrice,
                        MotivationPrice = item.MotivationPrice,
                        StartDate = item.StartDate,
                        TotalDay = item.TotalDay,
                        Country = item.Organizer.Country.Name,
                        City = item.Organizer.City.Name,

                    };
                    lstCoursesBriefDetails.Add(coureseBriefDetailsItem);
                }
            }

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, lstCoursesBriefDetails);
        }

        #endregion
    }
}

