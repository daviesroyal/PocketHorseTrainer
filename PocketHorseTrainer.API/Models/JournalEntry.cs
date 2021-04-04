using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public class JournalEntry
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public float TimeHandling { get; set; }
        public float TimeRiding { get; set; }

        public Horse Horse { get; set; }

        //TODO: refine datatypes for following properties - enums or lists, etc
        public enum Discipline
        {
            Western,
            English,
            Endurance,
            Natural,
            Stock,
            Driving,
            Groundwork
        }
        public Weather Weather { get; set; }
        
        //TODO: add map api for location
        public string Location { get; set; }

        public string Issues { get; set; }
        public string Strengths { get; set; }
        public string Comments { get; set; }

        //TODO: figure out how to upload and store videos for app
        public string Video { get; set; }

        public ApplicationUser Trainer { get; set; }

        public JournalEntry()
        {

        }

        //TODO: figure out how to get time only from DateTime class and calculate TimeHandling and TimeRiding
    }
}
