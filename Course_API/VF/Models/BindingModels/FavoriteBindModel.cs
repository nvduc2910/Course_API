using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Course_API.Models.BindingModels
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class FavoriteBindModel
    {
        public int CityId { get; set; }
        public int InstituteId { get; set; }
        public int CourseTypeId { get; set; }
        public DateTime SelectTime { get; set; }
        public int CountryId { get; set; }
        //public int Page { get; set; }
        //public int PageSize { get; set; }
    }

}
