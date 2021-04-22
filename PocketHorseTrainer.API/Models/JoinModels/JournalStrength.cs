using Microsoft.EntityFrameworkCore;

namespace PocketHorseTrainer.API.Models
{
    public class JournalStrength
    {
        public DbSet<JournalStrength> JournalStrengths { get; set; }

        public int EntryId { get; set; }
        public JournalEntry Entry { get; set; }

        public int StrengthId { get; set; }
        public TargetAreas Strength { get; set; }
    }
}
