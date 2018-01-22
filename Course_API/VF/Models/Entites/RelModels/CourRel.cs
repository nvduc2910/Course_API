using System;
using Course_API.Models.DatabaseModels.RelianceModels;

namespace Course_API.Models.DatabaseModels.RelModels
{
    public class CourRel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int RelianceId { get; set; }

        public Course Course { get; set; }
        public Reliance Reliance { get; set; }
    }
}
