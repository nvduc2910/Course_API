using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using Course_API.Enums;
using Course_API.Models.TrainerModels;

namespace Course_API.Models
{
    public class Trainee : IdentityUser<int>
    { 
        
        public string Name { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int? NationalityId { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public bool Disable { get; set; }
        public int? DisableTypeId { get; set; }
        public string ContactNumber { get; set; }
        public int ActiveStatusId { get; set; }


        public DisableType DisableType { get; set; }
        public ActiveStatus ActiveStatus { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public Nationality Nationality { get; set; }


        public int PinCode { get; set; }
        public DateTime? PinCodeExpiration { get; set; }
        public string DeviceToken {get;set;}
    }
}
