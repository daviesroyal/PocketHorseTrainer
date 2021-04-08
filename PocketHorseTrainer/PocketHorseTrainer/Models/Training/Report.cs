using PocketHorseTrainer.Models.Training;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketHorseTrainer.Models
{
    public class Report
    {
        public int Id { get; set; }
        public Horse Horse { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float TimeHandling { get; set; }
        public float TimeRiding { get; set; }
        public List<TargetAreas> Issues { get; set; }
        public List<TargetAreas> Strengths { get; set; }
        public List<Comments> Comments { get; set; }

        public Report()
        {
        }
    }
}
