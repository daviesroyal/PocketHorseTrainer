using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public class Report
    {
        public int Id { get; set; }
        public TimeLength TimeSpan { get; set; }
        public float TimeHandling { get; set; }
        public float TimeRiding { get; set; }
        public string Issues { get; set; }
        public string Strengths { get; set; }

        public Report()
        {
        }

        //TODO: refine datatypes for Issues and Strengths - enums or lists, etc
        //TODO: write function for calculating TimeHandling and TimeRiding based on log times
        //TODO: self-reference class to track progress, create one-to-many relationships for reports-logs instead of many-to-many?
    }
}
