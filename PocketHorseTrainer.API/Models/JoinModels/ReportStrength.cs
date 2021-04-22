using Microsoft.EntityFrameworkCore;

namespace PocketHorseTrainer.API.Models
{
    public class ReportStrength
    {
        public DbSet<ReportStrength> ReportStrengths { get; set; }

        public int ReportId { get; set; }
        public Report Report { get; set; }

        public int StrengthId { get; set; }
        public TargetAreas Strength { get; set; }

        public ReportStrength()
        {
        }

        public ReportStrength(TargetAreas strength)
        {
            Strength = strength;
        }
    }
}
