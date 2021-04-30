using PocketHorseTrainer.Models.Training;
using System;
using System.Collections.Generic;

namespace PocketHorseTrainer.Models
{
    public enum Discipline
    {
        Western,
        English,
        Endurance,
        Natural,
        Stock,
        Driving,
        Groundwork,
        Any
    }

    public class JournalEntry
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public float TimeHandling { get; set; }
        public float TimeRiding { get; set; }

        public Horse Horse { get; set; }

        public Discipline Discipline { get; set; }

        public Weather Weather { get; set; }

        public string Location { get; set; }

        public List<TargetAreas> Issues { get; set; }
        public List<TargetAreas> Strengths { get; set; }

        public Comments Comments { get; set; }

        public string Video { get; set; }
    }
}
