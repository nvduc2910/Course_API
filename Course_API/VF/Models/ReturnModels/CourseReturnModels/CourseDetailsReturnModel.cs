using System;
using System.Collections.Generic;
using Course_API.Enums;

namespace Course_API.Models.ReturnModels.CourseReturnModels
{
    public class CourseDetailsReturnModel
    {
        public int Id { get; set; }
        public int InstituteId { get; set; }
        public string InstituteName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public ECourseGender Gender { get; set; }
        public DateTime StartDate { get; set; }
        public string MainPrice { get; set; }
        public string MoviationPrice { get; set; }
        public string Note { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Address { get; set; }
        public string RegisterLink { get; set; }

        public List<CourseTrainerReturnModel> Trainer { get; set; }

        public CourseContactReturnModel Contact { get; set; }
        public List<CourseRelianceReturnModel> Reliance { get; set; }

        public class CourseTrainerReturnModel
        {
            public int Id { get; set; }
            public string Avatar { get; set; }
            public string Name { get; set; }
            public string Major { get; set; }
        }

        public class CourseContactReturnModel
        {

            public string ContactNumber { get; set; }
            public string Email { get; set; }
            public string Facebook { get; set; }
            public string Twitter { get; set; }
            public string Instagram { get; set; }
        }

        public class CourseRelianceReturnModel
        {
            public int Id { get; set; }
            public string Logo { get; set; }
        }
    }
}
