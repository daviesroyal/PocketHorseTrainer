using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public class HorseInput
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int BarnId { get; set; }
        public int BreedId { get; set; }
        public int ColorId { get; set; }
        public int MarkingsId { get; set; }
    }
}
