using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Course_API.Resources;

namespace Course_API.Models.BindingModels
{
    public class PersonalAccountRegisterBindModel
    {
        
        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "NullEmtpyPhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "NullEmpltyCountry")]
        public int CountryId { get; set; }

        
        [Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "NullEmptyCity")]
        
        public int CityId { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "NullEmtpySex")]
        public string Sex { get; set; }

        [Required(AllowEmptyStrings = false,
           ErrorMessageResourceType = typeof(ValidationModel),
           ErrorMessageResourceName = "NullEmtpyPassword")]
        public string Password { get; set; }
    }
}
