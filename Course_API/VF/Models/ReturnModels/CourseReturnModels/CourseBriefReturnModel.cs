using System;
namespace Course_API.Models.ReturnModels.CourseReturnModels
{
    public class CourseBriefReturnModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string InstitudeName { get; set; }
    }
}
