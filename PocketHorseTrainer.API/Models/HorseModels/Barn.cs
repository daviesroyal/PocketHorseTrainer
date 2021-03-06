using System.Collections.Generic;

namespace PocketHorseTrainer.API.Models
{
    public class Barn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ApplicationUser Owner { get; set; }
        public ApplicationUser Manager { get; set; }
        public List<HorseBarn> Horses { get; set; }
    }
}
