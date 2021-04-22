using System;

namespace PocketHorseTrainer.API.Models
{
    public enum TimeLength
    {
        daily,
        weekly,
        monthly,
        yearly
    }

    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Horse Horse { get; set; }

        public TimeLength TimeSpan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public TargetAreas AreaOfImprovement { get; set; }
        public bool Completed { get; set; }
    }
}
