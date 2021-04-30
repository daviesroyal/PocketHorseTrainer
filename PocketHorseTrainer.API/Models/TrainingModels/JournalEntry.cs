using System;
using System.Collections.Generic;

namespace PocketHorseTrainer.API.Models
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

        //TODO: add map api for location
        public string Location { get; set; }

        public List<JournalIssue> Issues { get; set; }
        public List<JournalStrength> Strengths { get; set; }

        public Comments Comments { get; set; }

        //TODO: figure out how to upload and store videos for app
        public string Video { get; set; }

        public ApplicationUser Trainer { get; set; }
    }
}
