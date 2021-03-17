using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PocketHorseTrainer.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Horse> Horses { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<HorseOwner> HorseOwners { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
