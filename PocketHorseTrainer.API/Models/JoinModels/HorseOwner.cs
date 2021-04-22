using Microsoft.EntityFrameworkCore;

namespace PocketHorseTrainer.API.Models
{
    public class HorseOwner
    {
        public DbSet<HorseOwner> HorseOwners { get; set; }

        public int HorseId { get; set; }
        public Horse Horse { get; set; }

        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
    }
}
