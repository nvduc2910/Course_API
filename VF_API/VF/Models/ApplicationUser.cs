using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using Course_API.Enums;

namespace Course_API.Models
{
    public class ApplicationUser : IdentityUser<int>
    { 

        public string FullName { get; set; }


        public int PinCode { get; set; }
        public DateTime? PinCodeExpiration { get; set; }
        public string DeviceToken {get;set;}
    }
}
