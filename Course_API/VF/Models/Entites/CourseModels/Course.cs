using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Course_API.Enums;
using Course_API.Models.DatabaseModels;
using Course_API.Models.DatabaseModels.CourseModels;
using Course_API.Models.DatabaseModels.RelModels;
using Course_API.Models.TrainerModels;
using Newtonsoft.Json;

namespace Course_API.Models
{
    public class Course
    {
        
        public int Id { get; set; }

        public int? OrganizerId { get; set; }

        [Required(ErrorMessage = "Course name can not be empty.")]
        public string Name { get; set; }

        public int CourseScopeId { get; set; }

        public int CourseStatusId { get; set; }

        public int CourseTypeId { get; set; }

        [Required(ErrorMessage = "Institute can not be empty.")]
        public int InstituteId { get; set; }

        public string OnlineLink { get; set; }

        public string Address { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }

        public int CourseLevelId { get; set; }

        public int CourseCategoryId { get; set; }

        [Required(ErrorMessage = "Course image can not be empty.")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Course Description can not be empty.")]
        public string Description { get; set; }

        public ECourseGender Gender { get; set; }

        public string Targerts { get; set; }

        public int CourseLanguageId { get; set; }
            
        public string Age { get; set; }

        [Required(ErrorMessage = "Course start date can not be empty.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Course end date can not be empty.")]
        public DateTime EndDate { get; set; }

        public string StarTime { get; set; }

        public string EndTime { get; set; }

        public bool Disable { get; set; }


        [Required(ErrorMessage = "Total day can not be empty.")]
        public int TotalDay { get; set; }

        public int HoursTotal { get; set; }

        public EPriceType PriceType { get; set; }

        public int CurrencyId { get; set; }

        [Required(ErrorMessage = "Main price can not be empty.")]
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

        public int CourseCancelReasonId { get; set; }

        public int FlagId { get; set; }

        public DateTime FlagDate { get; set; }

        public bool IsApproved { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public CourseScope CourseScope { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public Institute Institude { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public CourseStatus CourseStatus { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public CourseType CourseType { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public CourseLevel CourseLevel { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public CourseCategory CourseCategory { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public CourseLanguage CourseLanguage { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public Currency Currency { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public CourseCancelReason CourseCancelReason { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public CourseFlag CourseFlag { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public Organizer Organizer { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<CourTra> CourTra { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<CourRel> CourRel { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<CourseDayType> CourseDayType { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Favorite> CourseFavorite { get; set; }
    }
}
