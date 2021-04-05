using Microsoft.EntityFrameworkCore;

namespace PocketHorseTrainer.API.Models
{
    public class JournalIssue
    {
        public DbSet<JournalIssue> JournalIssues { get; set; }

        public int EntryId { get; set; }
        public JournalEntry Entry { get; set; }

        public int IssueId { get; set; }
        public TargetAreas Issue { get; set; }

        public JournalIssue()
        {

        }
    }
}
