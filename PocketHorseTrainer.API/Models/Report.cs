using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public class Report
    {
        public int Id { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public float TimeHandling { get; set; }
        public float TimeRiding { get; set; }
        public string[] Issues { get; set; }
        public string[] Strengths { get; set; }

    }
}
