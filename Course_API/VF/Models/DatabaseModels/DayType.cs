using System;
using System.Collections.Generic;

namespace Course_API.Models.DatabaseModels
{
    public class DayType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Course> Course { get; set; }
    }
}
