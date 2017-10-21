using System;
using Course_API.Enums;

namespace Course_API.Models.ReturnModels.CourseReturnModels
{
    public class CourseDetailsBriefReturnModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ECourseGender Gender { get; set; }

        public string InstituteName { get; set; }
        public int InstituteId { get; set; }
        public DateTime? StartDate { get; set; }
        public int MainPrice { get; set; }
        public int MotivationPrice { get; set; }
        public string Currency { get; set; }
        public string Image { get; set; }
        public double TotalDay { get; set; }

    }
}
