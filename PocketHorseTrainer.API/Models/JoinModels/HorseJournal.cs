using Microsoft.EntityFrameworkCore;

namespace PocketHorseTrainer.API.Models
{
    public class HorseJournal
    {
        public DbSet<HorseJournal> HorseJournals { get; set; }

        public int HorseId { get; set; }
        public Horse Horse { get; set; }

        public int EntryId { get; set; }
        public JournalEntry Entry { get; set; }
    }
}
