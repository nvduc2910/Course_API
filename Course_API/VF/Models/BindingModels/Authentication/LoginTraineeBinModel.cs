using System.ComponentModel.DataAnnotations;
using Course_API.Resources;

namespace Course_API.Models.BindingModels
{
    public class LoginTraineeBinModel
    {
        [Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "NullEmptyEmail")]
        public string PhoneNumber { get; set; }

        [Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "NullEmptyPassword")]
        [StringLength(
            20,
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "InvalidPassword",
            MinimumLength = 8)]
        public string Password { get; set; }

        public string DeviceToken { get; set; }
    }
}
