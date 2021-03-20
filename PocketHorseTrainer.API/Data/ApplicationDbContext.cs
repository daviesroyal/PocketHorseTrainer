﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public DbSet<Goal> TrainingGoals { get; set; }
        public DbSet<Log> TrainingLogs { get; set; }
        public DbSet<HorseOwner> HorseOwners { get; set; }
        public DbSet<Report> TrainingReports { get; set; }
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
