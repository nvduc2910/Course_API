using System;
namespace Course_API.Models.BindingModels.Authentication
{
    public class InstitudeRegisterBindModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
