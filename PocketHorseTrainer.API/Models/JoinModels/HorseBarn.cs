using Microsoft.EntityFrameworkCore;

namespace PocketHorseTrainer.API.Models
{
    public class HorseBarn
    {
        public DbSet<HorseBarn> BarnHorses { get; set; }

        public int HorseId { get; set; }
        public Horse Horse { get; set; }

        public int BarnId { get; set; }
        public Barn Barn { get; set; }
    }
}
