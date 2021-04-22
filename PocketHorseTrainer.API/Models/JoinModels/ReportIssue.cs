using Microsoft.EntityFrameworkCore;

namespace PocketHorseTrainer.API.Models
{
    public class ReportIssue
    {
        public DbSet<ReportIssue> ReportIssues { get; set; }

        public int ReportId { get; set; }
        public Report Report { get; set; }

        public int IssueId { get; set; }
        public TargetAreas Issue { get; set; }

        public ReportIssue()
        {
        }

        public ReportIssue(TargetAreas issue)
        {
            Issue = issue;
        }
    }
}
