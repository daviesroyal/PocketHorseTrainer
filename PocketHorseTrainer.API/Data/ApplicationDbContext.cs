using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PocketHorseTrainer.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public override DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Horse> Horses { get; set; }
        public DbSet<Goal> TrainingGoals { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }
        public DbSet<Report> TrainingReports { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Barn> Barns { get; set; }

        public DbSet<HorseOwner> HorseOwners { get; set; }
        public DbSet<HorseGoal> HorseGoals { get; set; }
        public DbSet<HorseBarn> BarnHorses { get; set; }
        public DbSet<HorseJournal> HorseJournals { get; set; }

        public DbSet<JournalIssue> JournalIssues { get; set; }
        public DbSet<JournalStrength> JournalStrengths { get; set; }
        public DbSet<ReportIssue> ReportIssues { get; set; }
        public DbSet<ReportStrength> ReportStrengths { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<HorseOwner>()
                .HasKey(ho => new { ho.HorseId, ho.OwnerId});
            builder.Entity<HorseGoal>()
                .HasKey(hg => new { hg.HorseId, hg.GoalId });
            builder.Entity<HorseBarn>()
                .HasKey(hb => new { hb.HorseId, hb.BarnId });
            builder.Entity<HorseJournal>()
                .HasKey(hj => new { hj.HorseId, hj.EntryId });
            builder.Entity<JournalIssue>()
                .HasKey(ji => new { ji.EntryId, ji.IssueId });
            builder.Entity<JournalStrength>()
                .HasKey(js => new { js.EntryId, js.StrengthId });
            builder.Entity<ReportIssue>()
                .HasKey(ri => new { ri.ReportId, ri.IssueId });
            builder.Entity<ReportStrength>()
                .HasKey(rs => new { rs.ReportId, rs.StrengthId });

            base.OnModelCreating(builder);
        }
    }
}
