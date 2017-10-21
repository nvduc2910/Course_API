using System;
namespace Course_API.Models.DatabaseModels.RelModels
{
    public class CourseDayType
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int DayTypeId { get; set; }
        public Course Course { get; set; }
        public DayType DayType { get; set; }
    }
}
