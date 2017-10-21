using System;
using System.Collections.Generic;
using Course_API.Models.DatabaseModels.RelModels;

namespace Course_API.Models.DatabaseModels.RelianceModels
{
    public class Reliance
    {
        public int Id { get; set; }
        public string Logo { get; set; }
        public int RelianceStatusId { get; set; }

        public RelianceStatus RelianceStatus { get; set; }

        public virtual ICollection<CourRel> CourRel { get; set; }
    }
}
