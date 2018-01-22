using System;
using Course_API.Models.TrainerModels;

namespace Course_API.Models.DatabaseModels.RelModels
{
    public class CourTra
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int TrainerId { get; set; }

        public Course Course { get; set; }
        public Trainer Trainer { get; set; }
    }
}
