﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Course_API.Models.BindingModels.AuthenticationBindModels
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TraineeUpdateProfileBindModel
    {
        public string PhoneNumber { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string Sex { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

   
}
