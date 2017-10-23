using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course_API.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Course_API.Models.ReturnModels.TrainerReturnModels
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TrainerDetailsReturnModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public ECourseGender Gender { get; set; }
        public string About { get; set; }
        public string Major { get; set; }

        public ContactTrainerReturnModel Contact { get; set; }
        public List<TrainerCounserBriefReturModel> OldCourses { get; set; }

        public List<TrainerCounserBriefReturModel> NewCourses { get; set; }
    }

    public class ContactTrainerReturnModel
    {
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
    }

    public class TrainerCounserBriefReturModel 
    {
        public int Id { get; set; }
        public string Image { get; set; }
    }
   
}
