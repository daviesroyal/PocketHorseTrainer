using System.Collections.Generic;

namespace PocketHorseTrainer.API.Models
{
    public class Horse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public List<Breeds> Breed { get; set; }
        public CoatColors Color { get; set; }
        public Markings Markings { get; set; }
        
        public List<Goal> Goals { get; set; }

        public Horse()
        {

        }
    }
}
