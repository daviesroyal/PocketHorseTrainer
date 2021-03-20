using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public class Log
    {
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Horse Horse { get; set; }
        public string Discipline { get; set; }
        public string Weather { get; set; }
        public string Location { get; set; }
        public string Temperment { get; set; }
        public string[] Issues { get; set; }
        public string[] Strengths { get; set; }
        public string Video { get; set; }
        public string Comments { get; set; }
        public ApplicationUser Trainer { get; set; }

        public Log()
        {

        }
    }
}
