using System.ComponentModel.DataAnnotations;
using Course_API.Resources;

namespace Course_API.Models.BindingModels
{
    public class ExternalLoginModel
    {
        [Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "NullEmptyProvider")]
        public string Provider { get; set; }

        [Required(
            AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(ValidationModel),
            ErrorMessageResourceName = "NullEmptyAccessToken")]
        public string AccessToken { get; set; }
        public string DeviceToken { get; set; }
    }
}
