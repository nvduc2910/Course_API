using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Course_API.Models.BindingModels.Institute
{
    public class InstituteDTO
    {
        public int Id { get; set; }
        public int InstituteTypeId { get; set; }

        [Required(ErrorMessage = "Course name can not be empty.")]
        public string Name { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public string TelePhoneNumber { get; set; }

        public string MobileNumber { get; set; }

        public string UNANumber { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public string GooglePlus { get; set; }

        public string Facebook { get; set; }

        public string Snapchat { get; set; }

        public string Youtube { get; set; }

        public string Telegram { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public string Address { get; set; }

        public string About { get; set; }

        public string Logo { get; set; }

        public string Remark { get; set; }

        public int StatusId { get; set; }

        public int InstitudeFlagId { get; set; }

        public DateTime FlagDate { get; set; }

        public int CommissionRate { get; set; }

        public List<RelianceDTO> Reliance { get; set; }

    }
}
