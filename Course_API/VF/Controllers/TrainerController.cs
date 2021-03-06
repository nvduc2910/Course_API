﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Course_API.CustomAttribute;
using Course_API.Helpers;
using Course_API.Infrastructures;
using Course_API.Models;
using Course_API.Models.BindingModels.Trainer;
using Course_API.Models.ReturnModels.TrainerReturnModels;
using Course_API.Models.TrainerModels;
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
    public class TrainerController : BaseController
    {
        public TrainerController(IUnitOfWork unitOfWork, UserManager<User> userManager, IHttpContextAccessor httpCotext, IMapper mapper) : base(unitOfWork, userManager, httpCotext, mapper)
        {

        }

        [HttpGet]
        public IActionResult GetTrainers(int page, int pageSize)
        {
            var lstTrainerBirefReturnModel = new List<TrainerBirefReturnModel>();

            var traineres = unitOfWork.GetRepository<Trainer>().Get(null, null, "CourTra.Course").Skip((page - 1) * pageSize).Take(pageSize).ToList();

            foreach (var item in traineres)
            {
                var trainerBriefItem = new TrainerBirefReturnModel()
                {
                    Id = item.Id,
                    Avatar = item.Logo,
                    Name = item.Name,
                    Major = item.Major,

                };

                foreach (var itemTrainer in item.CourTra)
                {
                    if (itemTrainer.Course.StartDate < DateTime.Now)
                        trainerBriefItem.TotalActive += 1;
                }

                lstTrainerBirefReturnModel.Add(trainerBriefItem);
            }

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, lstTrainerBirefReturnModel);
        }

        [HttpGet]
        public IActionResult TrainersDetails(int trainerId)
        {
            var trainer = unitOfWork.GetRepository<Trainer>().Get(s => s.Id == trainerId, null, "CourTra.Course,Country,City").FirstOrDefault();

            if (trainer == null)

                return ApiResponder.RespondFailureTo(HttpStatusCode.Ok, "Trainer not found", ErrorCodes.TrainerNotFound);

            var trainerDetailsReturnModel = new TrainerDetailsReturnModel()
            {
                Id = trainer.Id,
                Name = trainer.Name,
                Country = trainer.Country.Name,
                City = trainer.City.Name,
                Gender = trainer.Gender,
                About = trainer.About,
                Avatar = trainer.Logo,
                Major = trainer.Major,
                Contact = new ContactTrainerReturnModel()
                {
                    ContactNumber = trainer.ContactNumber,
                    Email = trainer.Email,
                    Facebook = trainer.Facebook,
                    Twitter = trainer.Twitter,
                    Instagram = trainer.Instagram,

                },
                OldCourses = new List<TrainerCounserBriefReturModel>(),
                NewCourses = new List<TrainerCounserBriefReturModel>(),

            };

            foreach (var item in trainer.CourTra)
            {
                if (item.Course.EndDate < DateTime.Now)
                {
                    var oldCourseItem = new TrainerCounserBriefReturModel()
                    {
                        Id = item.Course.Id,
                        Image = item.Course.Image,

                    };
                    trainerDetailsReturnModel.OldCourses.Add(oldCourseItem);
                }

                else if (item.Course.StartDate > DateTime.Now)
                {
                    var newCourseItem = new TrainerCounserBriefReturModel()
                    {
                        Id = item.Course.Id,
                        Image = item.Course.Image,

                    };
                    trainerDetailsReturnModel.NewCourses.Add(newCourseItem);
                }
            }

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, trainerDetailsReturnModel);
        }


        #region CreateNewTrainer
        [HttpPost]
        public async Task<IActionResult> CreateNewTrainer([FromBody] TrainerDTO trainerDTO)
        {
            var dataInsert = mapper.Map<TrainerDTO, Trainer>(trainerDTO);
            dataInsert.InstituteId = UserIdRequested();

            await unitOfWork.GetRepository<Trainer>().InsertAsync(dataInsert);
            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Added");
        }

        #endregion


        #region GetInstitudeTrainerList
        [HttpGet]
        public IActionResult GetInstitudeTrainerList(int page, int pageSize)
        {
            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, null);
        }

        #endregion


        #region DeleteTrainer
        [HttpDelete]
        public async Task<IActionResult> DeleteTrainer(int trainerId)
        {
            var data = unitOfWork.GetRepository<Trainer>().Get(s => s.Id == trainerId).FirstOrDefault();
            if (data == null)
                return ApiResponder.RespondFailureTo(HttpStatusCode.Ok, "Trainer not found", ErrorCodes.TrainerNotFound);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Deleted");
        }

        #endregion

        #region UpdateTrainer
        [HttpPut]
        public async Task<IActionResult> UpdateTrainer([FromBody] TrainerDTO trainerDTO, int trainerId)
        {
            var data = unitOfWork.GetRepository<Trainer>().Get(s => s.Id == trainerId).FirstOrDefault();
            if (data == null)
                return ApiResponder.RespondFailureTo(HttpStatusCode.Ok, "Trainer not found", ErrorCodes.TrainerNotFound);

            return ApiResponder.RespondSuccessTo(HttpStatusCode.Ok, "Updated");
        }

        #endregion


    }
}
