﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course_API.CustomAttribute;
using Course_API.Helpers;
using Course_API.Infrastructures;
using Course_API.Models;
using Course_API.Models.DatabaseModels.CourseModels;
using Course_API.Models.ReturnModels.CourseReturnModels;
using Course_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Course_API.Models.ReturnModels.CourseReturnModels.CourseDetailsReturnModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Course_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ValidateModel]
    [HandleException]
    public class CourseController : BaseController
    {
        public CourseController(IUnitOfWork unitOfWork, UserManager<Trainee> userManager, IHttpContextAccessor httpCotext) : base(unitOfWork, userManager, httpCotext)
        {
            
        }

        [HttpGet]
        public IActionResult GetCourse(int page, int pageSize)
        {
            var lstCourseBrief = new List<CourseBriefReturnModel>();

            var courses = unitOfWork.GetRepository<Course>().Get().Skip((page - 1) * pageSize).Take(pageSize).ToList();
            foreach(var item in courses)
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


        [HttpGet]
        public IActionResult GetCourseCategory()
        {
            var courseCategory = unitOfWork.GetRepository<CourseCategory>().Get();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseCategory);
        }

        [HttpGet]
        public IActionResult GetCourseFlag()
        {
            var courseFlag = unitOfWork.GetRepository<CourseFlag>().Get();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseFlag);
        }


        [HttpGet]
        public IActionResult GetCourseLanguage()
        {
            var courseLanguage = unitOfWork.GetRepository<CourseLanguage>().Get();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseLanguage);
        }

        [HttpGet]
        public IActionResult GetCourseLevel()
        {
            var courseLevel = unitOfWork.GetRepository<CourseLevel>().Get();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseLevel);
        }


        [HttpGet]
        public IActionResult GetCourseScope()
        {
            var courseScope = unitOfWork.GetRepository<CourseScope>().Get();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseScope);
        }


        [HttpGet]
        public IActionResult GetCourseStatus()
        {
            var courseStatus = unitOfWork.GetRepository<CourseStatus>().Get();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseStatus);
        }


        [HttpGet]
        public IActionResult GetCourseType()
        {
            var courseType = unitOfWork.GetRepository<CourseType>().Get();

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseType);
        }


        [HttpGet]
        public IActionResult GetFeaturedCourse(int page, int pageSize)
        {
            var courses = unitOfWork.GetRepository<Course>().Get(null,null,"Institude,Currency").Skip((page - 1) * pageSize).Take(pageSize).ToList();;

            var lstCoursesBriefDetails = new List<CourseDetailsBriefReturnModel>();

            foreach(var item in courses)
            {
                //foreach(var dayType in item.DayType)
                //{
                //    if(dayType == )
                //}
                
                var totalDay = (item.EndDate - item.StartDate).TotalDays;
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

                };
                lstCoursesBriefDetails.Add(coureseBriefDetailsItem);
            }

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, lstCoursesBriefDetails);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] Course course)
        {
            var courseInserted = await unitOfWork.GetRepository<Course>().InsertAsync(course);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseInserted);
        }



        [HttpGet]
        public IActionResult GetCourseDetails(int courseId)
        {
            var course = unitOfWork.GetRepository<Course>().Get(s => s.Id == courseId, null, "Institude,Currency,Organizer.Country.City,CourTra.Trainer.TrainerNationality,CourRel.Reliance,CourseDayType").FirstOrDefault();

            var courseReturn = new CourseDetailsReturnModel()
            {
                Id = course.Id,
                InstituteId = course.Institude.Id,
                InstituteName = course.Institude.Name,
                Gender = course.Gender,
                StartDate = course.StartDate,
                Country = course.Organizer.Country.Name,
                City = course.Organizer.City.Name,
                MainPrice = course.MainPrice.ToString() + course.Currency.Name,
                MoviationPrice = course.MotivationPrice.ToString() + course.Currency.Name,
                Image = course.Image,
                Description = course.Description,
                Contact = new CourseDetailsReturnModel.CourseContactReturnModel()
                {
                    ContactNumber = course.Institude.TelePhoneNumber,
                    Email = course.Institude.Email,
                    Facebook = course.Institude.Facebook,
                    Twitter = course.Institude.Twitter,
                    Instagram = course.Institude.Instagram,
                },
                Trainer = new List<CourseDetailsReturnModel.CourseTrainerReturnModel>(),
                Reliance = new List<CourseDetailsReturnModel.CourseRelianceReturnModel>(),

            };

            foreach(var item in course.CourTra)
            {
                var courseTrainerReturn = new CourseTrainerReturnModel()
                {
                    Id = item.Trainer.Id,
                    Avatar = item.Trainer.Logo,
                    Name = item.Trainer.Name,
                    Nationaly = item.Trainer.TrainerNationality.National,

                };

                courseReturn.Trainer.Add(courseTrainerReturn);
            }

            foreach(var item in course.CourRel)
            {
                var courseRelianceReturn = new CourseRelianceReturnModel()
                {
                    Id = item.Reliance.Id,
                    Logo = item.Reliance.Logo,
                };
                courseReturn.Reliance.Add(courseRelianceReturn);
            }

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, courseReturn);

        }
    }
}
