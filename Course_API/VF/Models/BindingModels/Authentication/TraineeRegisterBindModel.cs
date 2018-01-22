using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course_API.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Course_API.Models.BindingModels.AuthenticationBindModels
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TraineeRegisterBindModel
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string Sex { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}
