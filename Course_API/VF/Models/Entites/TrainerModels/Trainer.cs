using System;
using System.Collections.Generic;
using Course_API.Enums;
using Course_API.Models.DatabaseModels.RelModels;

namespace Course_API.Models.TrainerModels
{
    public class Trainer
    {

        public int Id { get; set; }
        public int InstituteId { get; set; }
        public int TrainerTitleId { get; set; }
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

        public Country Country { get; set; }
        public City City { get; set; }
        public TrainerTitle TrainerTitle { get; set; }
        public Nationality TrainerNationality { get; set; }
        public TrainerStatus TrainerStatus { get; set; }
        public TrainerFlag TrainerFlag { get; set; }
        public Institute Institute { get; set; }

        public virtual ICollection<CourTra> CourTra { get; set; }
    }
}
