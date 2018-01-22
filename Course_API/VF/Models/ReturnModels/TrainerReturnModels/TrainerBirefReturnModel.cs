using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Course_API.Models.ReturnModels.TrainerReturnModels
{
    
    public class TrainerBirefReturnModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Major { get; set; }
        public int TotalActive { get; set; }


    }
}
