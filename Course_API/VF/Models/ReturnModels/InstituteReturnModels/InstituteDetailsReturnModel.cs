using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Course_API.Models.ReturnModels.InstituteReturnModels
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class InstituteDetailsReturnModel
    {
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string About { get; set; }
        public InstituteContactReturnModel Contact { get; set; }
        public List<InstituteCounserBriefReturModel> OldCourse { get; set; }
        public List<InstituteCounserBriefReturModel> NewCourse { get; set; }
    }


    public class InstituteCounserBriefReturModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
    }
   
    public class InstituteContactReturnModel
    {
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
    }
}
