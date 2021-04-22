using System.Collections.Generic;

namespace PocketHorseTrainer.API.Models
{
    public class Horse
    {
        public int Id { get; set; }
        public ApplicationUser Owner { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Barn Barn { get; set; }
        public Breed Breed { get; set; }
        public CoatColor Color { get; set; }
        public Markings Markings { get; set; }

        public List<HorseGoal> Goals { get; set; }
        public List<HorseJournal> Journals { get; set; }
    }
}
