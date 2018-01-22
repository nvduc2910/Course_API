using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course_API.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Course_API.Models.DatabaseModels
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Favorite
    {
        public int Id { get; set; }
        public int TraineeId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int CourseTypeId { get; set; }
        public int CourseScopeId { get; set; }
        public ECourseGender Gender { get; set; }
        public int PriceId { get; set; }
    }

}
