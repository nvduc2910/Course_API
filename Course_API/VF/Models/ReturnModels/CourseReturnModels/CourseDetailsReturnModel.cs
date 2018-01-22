using System;
using System.Collections.Generic;
using Course_API.Enums;
using Course_API.Models.ReturnModels.TrainerReturnModels;
using Course_API.Models.ReturnModels.Webs;

namespace Course_API.Models.ReturnModels.CourseReturnModels
{
    public class CourseDetailsReturnModel
    {

        public int Id { get; set; }

        public int? OrganizerId { get; set; }

        public string Name { get; set; }

        public CourseScopeReturnModel CourseScope { get; set; }

        public CourseStatusReturnModel CourseStatus { get; set; }

        public CourseTypeReturnModel CourseType { get; set; }

        public CourseInstituteReturnModel CourseInstitute { get; set; }

        public string OnlineLink { get; set; }

        public string Address { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }

        public CourseLevelReturnModel CourseLevel { get; set; }

        public CourseCategoryReturnModel CourseCategory { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public ECourseGender Gender { get; set; }

        public string Targerts { get; set; }

        public CourseLanguageReturnModel CourseLanguage { get; set; }

        public string Age { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string StarTime { get; set; }

        public string EndTime { get; set; }

        public bool Disable { get; set; }

        public int TotalDay { get; set; }

        public int HoursTotal { get; set; }

        public EPriceType PriceType { get; set; }

        public CurrencyReturnModel Currency { get; set; }

        public int MainPrice { get; set; }

        public int MotivationPrice { get; set; }

        public int GroupPrice { get; set; }

        public DateTime MotivationDate { get; set; }

        public string PromotionDetails { get; set; }

        public string ContactNumerFirst { get; set; }

        public string ContactNumberSecond { get; set; }

        public string WhatAppsNumber { get; set; }

        public string Email { get; set; }

        public string RegisterLink { get; set; }

        public string VideoLink { get; set; }

        public string Others { get; set; }

        public CourseCancelReasonReturnModel CourseCancelReason { get; set; }

        public CourseFlagReturnModel CourseFlag { get; set; }

        public DateTime FlagDate { get; set; }


        public List<TrainerBirefReturnModel> Trainer { get; set; }

        public List<RelianceReturnModel> Reliance { get; set; }




        //public int Id { get; set; }
        //public int InstituteId { get; set; }
        //public string InstituteName { get; set; }
        //public string Country { get; set; }
        //public string City { get; set; }
        //public string Name { get; set; }
        //public ECourseGender Gender { get; set; }
        //public DateTime StartDate { get; set; }
        //public string MainPrice { get; set; }
        //public string MoviationPrice { get; set; }
        //public string Note { get; set; }
        //public string Image { get; set; }
        //public string Description { get; set; }
        //public double Lat { get; set; }
        //public double Lng { get; set; }
        //public string Address { get; set; }
        //public string RegisterLink { get; set; }
        //public string CourseType { get; set; }

        //public List<CourseTrainerReturnModel> Trainer { get; set; }
        //public CourseContactReturnModel Contact { get; set; }
        //public List<CourseRelianceReturnModel> Reliance { get; set; }

        //public class CourseTrainerReturnModel
        //{
        //    public int Id { get; set; }
        //    public string Avatar { get; set; }
        //    public string Name { get; set; }
        //    public string Major { get; set; }
        //}

        //public class CourseContactReturnModel
        //{

        //    public string ContactNumber { get; set; }
        //    public string Email { get; set; }
        //    public string Facebook { get; set; }
        //    public string Twitter { get; set; }
        //    public string Instagram { get; set; }
        //}

        //public class CourseRelianceReturnModel
        //{
        //    public int Id { get; set; }
        //    public string Logo { get; set; }
        //}
    }
}
