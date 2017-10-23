using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Course_API.Models.ReturnModels.TraineeReturnModels
{
  
    public class TraineeReturnModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }

}
