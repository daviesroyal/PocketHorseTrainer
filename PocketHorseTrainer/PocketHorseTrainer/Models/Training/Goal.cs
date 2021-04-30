using PocketHorseTrainer.Models.Enums;
using PocketHorseTrainer.Models.Training;
using System;

namespace PocketHorseTrainer.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Horse Horse { get; set; }

        public Interval Interval { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public TargetAreas AreaOfImprovement { get; set; }
        public bool Completed { get; set; }
    }
}
