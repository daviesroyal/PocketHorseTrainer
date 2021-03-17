using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public class Evaluation
    {
        public TimeSpan TimeSpan { get; set; }
        public float TimeHandling { get; set; }
        public float TimeRiding { get; set; }
        public string Issues { get; set; }
        public string Strengths { get; set; }
        public string Video { get; set; }

        public Evaluation()
        {

        }
    }
}
