using PocketHorseTrainer.Models.Horses;

namespace PocketHorseTrainer.Models
{
    public class Horse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Barn Barn { get; set; }
        public Breed Breed { get; set; }
        public CoatColor Color { get; set; }
        public Markings Markings { get; set; }
    }
}
