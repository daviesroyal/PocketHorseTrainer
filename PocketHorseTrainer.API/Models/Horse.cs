
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public class Horse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        //TODO: refine datatypes for following properties - enums or lists, etc
        public string Breed { get; set; }
        public string Color { get; set; }
        public string Markings { get; set; }

        public List<Goal> Goals { get; set; }

        public Horse()
        {

        }
    }
}
