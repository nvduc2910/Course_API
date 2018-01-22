using System;
using System.Collections.Generic;

namespace Course_API.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<City> City { get; set; }
    }
}
