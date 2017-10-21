using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Course_API.Models
{
    public class Organizer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Website { get; set; }
        public string Remark { get; set; }
        public int OrganizerStatusId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public Country Country { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public City City { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public OrganizerStatus OrganizerStatus { get; set; }

    }
}
