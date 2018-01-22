using System;
using Course_API.Enums;

namespace Course_API.Models.BindingModels.Trainer
{
    public class TrainerDTO
    {
        public int TrainerTitleId { get; set; }
        public int InstituteId { get; set; }
        public string Name { get; set; }
        public ECourseGender Gender { get; set; }
        public int TrainerNationalityId { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public string About { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string GooglePlus { get; set; }
        public string Facebook { get; set; }
        public string Snapchat { get; set; }
        public string Youtube { get; set; }
        public string Telegram { get; set; }
        public string Major { get; set; }

        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }
        public string Remark { get; set; }
        public int TrainerStatusId { get; set; }
        public int TrainerFlagId { get; set; }
        public DateTime FlagDate { get; set; }
    }
}
