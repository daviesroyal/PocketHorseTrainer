using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public class Log
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; } //separate properties for TimeHandling and TimeRiding?
        public DateTime EndTime { get; set; }

        public Horse Horse { get; set; }

        //TODO: refine datatypes for following properties - enums or lists, etc
        public string Discipline { get; set; }
        public string Weather { get; set; }
        public string Location { get; set; }
        public string Temperment { get; set; }
        public string Issues { get; set; }
        public string Strengths { get; set; }
        public string Comments { get; set; }

        //TODO: figure out how to upload and store videos for app
        public string Video { get; set; }

        public ApplicationUser Trainer { get; set; }

        public Log()
        {

        }

        //TODO: figure out how to get time only from DateTime class and calculate TimeHandling and TimeRiding
    }
}
