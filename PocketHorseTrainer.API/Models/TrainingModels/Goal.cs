using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TimeLength TimeSpan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public TargetAreas AreaOfImprovement { get; set; }
        public bool Completed { get; set; }

        public Goal()
        {

        }
        
    }
}
