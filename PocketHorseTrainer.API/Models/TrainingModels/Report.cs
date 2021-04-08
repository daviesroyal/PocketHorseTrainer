using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public class Report
    {
        public int Id { get; set; }
        public Horse Horse { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float TimeHandling { get; set; }
        public float TimeRiding { get; set; }
        public List<ReportIssue> Issues { get; set; }
        public List<ReportStrength> Strengths { get; set; }
        public List<Comments> Comments { get; set; }

        public Report()
        {
        }

        public Report(List<JournalEntry> entries)
        {
            foreach (JournalEntry entry in entries)
            {
                TimeHandling += entry.TimeHandling;
                TimeRiding += entry.TimeRiding;

                Comments.Add(entry.Comments);

                foreach (JournalIssue issue in entry.Issues)
                {
                    ReportIssue reportIssue = new(issue.Issue);
                    Issues.Add(reportIssue);
                }

                foreach (JournalStrength strength in entry.Strengths)
                {
                    ReportStrength reportStrength = new(strength.Strength);
                    Strengths.Add(reportStrength);
                }

                entries.Sort((a, b) => DateTime.Compare(a.Date, b.Date));
                StartDate = entries.First().Date;
                EndDate = entries.Last().Date;
            }
        }
    }
}
