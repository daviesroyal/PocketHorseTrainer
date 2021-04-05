﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PocketHorseTrainer.API.Data;

namespace PocketHorseTrainer.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210405145757_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AppointmentDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NextAppDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumOfWeeks")
                        .HasColumnType("int");

                    b.Property<bool>("Recurring")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.Barn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Barns");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AreaOfImprovementId")
                        .HasColumnType("int");

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TimeSpan")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaOfImprovementId");

                    b.ToTable("TrainingGoals");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.Horse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("BarnId")
                        .HasColumnType("int");

                    b.Property<int>("Breed")
                        .HasColumnType("int");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<int?>("MarkingsId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BarnId");

                    b.HasIndex("MarkingsId");

                    b.ToTable("Horses");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.HorseBarn", b =>
                {
                    b.Property<int>("HorseId")
                        .HasColumnType("int");

                    b.Property<int>("BarnId")
                        .HasColumnType("int");

                    b.Property<int?>("HorseBarnBarnId")
                        .HasColumnType("int");

                    b.Property<int?>("HorseBarnHorseId")
                        .HasColumnType("int");

                    b.HasKey("HorseId", "BarnId");

                    b.HasIndex("BarnId");

                    b.HasIndex("HorseBarnHorseId", "HorseBarnBarnId");

                    b.ToTable("BarnHorses");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.HorseGoal", b =>
                {
                    b.Property<int>("HorseId")
                        .HasColumnType("int");

                    b.Property<int>("GoalId")
                        .HasColumnType("int");

                    b.Property<int?>("HorseGoalGoalId")
                        .HasColumnType("int");

                    b.Property<int?>("HorseGoalHorseId")
                        .HasColumnType("int");

                    b.HasKey("HorseId", "GoalId");

                    b.HasIndex("GoalId");

                    b.HasIndex("HorseGoalHorseId", "HorseGoalGoalId");

                    b.ToTable("HorseGoals");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.HorseOwner", b =>
                {
                    b.Property<int>("HorseId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int?>("HorseOwnerHorseId")
                        .HasColumnType("int");

                    b.Property<int?>("HorseOwnerOwnerId")
                        .HasColumnType("int");

                    b.HasKey("HorseId", "OwnerId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("HorseOwnerHorseId", "HorseOwnerOwnerId");

                    b.ToTable("HorseOwners");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.JournalEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HorseId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TimeHandling")
                        .HasColumnType("real");

                    b.Property<float>("TimeRiding")
                        .HasColumnType("real");

                    b.Property<int?>("TrainerId")
                        .HasColumnType("int");

                    b.Property<string>("Video")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WeatherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HorseId");

                    b.HasIndex("TrainerId");

                    b.HasIndex("WeatherId");

                    b.ToTable("JournalEntries");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.JournalIssue", b =>
                {
                    b.Property<int>("EntryId")
                        .HasColumnType("int");

                    b.Property<int>("IssueId")
                        .HasColumnType("int");

                    b.Property<int?>("JournalIssueEntryId")
                        .HasColumnType("int");

                    b.Property<int?>("JournalIssueIssueId")
                        .HasColumnType("int");

                    b.HasKey("EntryId", "IssueId");

                    b.HasIndex("IssueId");

                    b.HasIndex("JournalIssueEntryId", "JournalIssueIssueId");

                    b.ToTable("JournalIssues");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.JournalStrength", b =>
                {
                    b.Property<int>("EntryId")
                        .HasColumnType("int");

                    b.Property<int>("StrengthId")
                        .HasColumnType("int");

                    b.Property<int?>("JournalStrengthEntryId")
                        .HasColumnType("int");

                    b.Property<int?>("JournalStrengthStrengthId")
                        .HasColumnType("int");

                    b.HasKey("EntryId", "StrengthId");

                    b.HasIndex("StrengthId");

                    b.HasIndex("JournalStrengthEntryId", "JournalStrengthStrengthId");

                    b.ToTable("JournalStrengths");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.Markings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Markings");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("TimeHandling")
                        .HasColumnType("real");

                    b.Property<float>("TimeRiding")
                        .HasColumnType("real");

                    b.Property<int>("TimeSpan")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TrainingReports");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.ReportIssue", b =>
                {
                    b.Property<int>("ReportId")
                        .HasColumnType("int");

                    b.Property<int>("IssueId")
                        .HasColumnType("int");

                    b.Property<int?>("ReportIssueIssueId")
                        .HasColumnType("int");

                    b.Property<int?>("ReportIssueReportId")
                        .HasColumnType("int");

                    b.HasKey("ReportId", "IssueId");

                    b.HasIndex("IssueId");

                    b.HasIndex("ReportIssueReportId", "ReportIssueIssueId");

                    b.ToTable("ReportIssues");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.ReportStrength", b =>
                {
                    b.Property<int>("ReportId")
                        .HasColumnType("int");

                    b.Property<int>("StrengthId")
                        .HasColumnType("int");

                    b.Property<int?>("ReportStrengthReportId")
                        .HasColumnType("int");

                    b.Property<int?>("ReportStrengthStrengthId")
                        .HasColumnType("int");

                    b.HasKey("ReportId", "StrengthId");

                    b.HasIndex("StrengthId");

                    b.HasIndex("ReportStrengthReportId", "ReportStrengthStrengthId");

                    b.ToTable("ReportStrengths");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.TargetAreas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TargetAreas");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.Weather", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("TempF")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Weather");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("PocketHorseTrainer.API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("PocketHorseTrainer.API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketHorseTrainer.API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("PocketHorseTrainer.API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.Barn", b =>
                {
                    b.HasOne("PocketHorseTrainer.API.Models.ApplicationUser", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.HasOne("PocketHorseTrainer.API.Models.ApplicationUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Manager");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.Goal", b =>
                {
                    b.HasOne("PocketHorseTrainer.API.Models.TargetAreas", "AreaOfImprovement")
                        .WithMany()
                        .HasForeignKey("AreaOfImprovementId");

                    b.Navigation("AreaOfImprovement");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.Horse", b =>
                {
                    b.HasOne("PocketHorseTrainer.API.Models.Barn", "Barn")
                        .WithMany()
                        .HasForeignKey("BarnId");

                    b.HasOne("PocketHorseTrainer.API.Models.Markings", "Markings")
                        .WithMany()
                        .HasForeignKey("MarkingsId");

                    b.Navigation("Barn");

                    b.Navigation("Markings");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.HorseBarn", b =>
                {
                    b.HasOne("PocketHorseTrainer.API.Models.Barn", "Barn")
                        .WithMany("Horses")
                        .HasForeignKey("BarnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketHorseTrainer.API.Models.Horse", "Horse")
                        .WithMany()
                        .HasForeignKey("HorseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketHorseTrainer.API.Models.HorseBarn", null)
                        .WithMany("BarnHorses")
                        .HasForeignKey("HorseBarnHorseId", "HorseBarnBarnId");

                    b.Navigation("Barn");

                    b.Navigation("Horse");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.HorseGoal", b =>
                {
                    b.HasOne("PocketHorseTrainer.API.Models.Goal", "Goal")
                        .WithMany()
                        .HasForeignKey("GoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketHorseTrainer.API.Models.Horse", "Horse")
                        .WithMany("Goals")
                        .HasForeignKey("HorseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketHorseTrainer.API.Models.HorseGoal", null)
                        .WithMany("HorseGoals")
                        .HasForeignKey("HorseGoalHorseId", "HorseGoalGoalId");

                    b.Navigation("Goal");

                    b.Navigation("Horse");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.HorseOwner", b =>
                {
                    b.HasOne("PocketHorseTrainer.API.Models.Horse", "Horse")
                        .WithMany()
                        .HasForeignKey("HorseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketHorseTrainer.API.Models.ApplicationUser", "Owner")
                        .WithMany("Horses")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketHorseTrainer.API.Models.HorseOwner", null)
                        .WithMany("HorseOwners")
                        .HasForeignKey("HorseOwnerHorseId", "HorseOwnerOwnerId");

                    b.Navigation("Horse");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.JournalEntry", b =>
                {
                    b.HasOne("PocketHorseTrainer.API.Models.Horse", "Horse")
                        .WithMany()
                        .HasForeignKey("HorseId");

                    b.HasOne("PocketHorseTrainer.API.Models.ApplicationUser", "Trainer")
                        .WithMany()
                        .HasForeignKey("TrainerId");

                    b.HasOne("PocketHorseTrainer.API.Models.Weather", "Weather")
                        .WithMany()
                        .HasForeignKey("WeatherId");

                    b.Navigation("Horse");

                    b.Navigation("Trainer");

                    b.Navigation("Weather");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.JournalIssue", b =>
                {
                    b.HasOne("PocketHorseTrainer.API.Models.JournalEntry", "Entry")
                        .WithMany("Issues")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketHorseTrainer.API.Models.TargetAreas", "Issue")
                        .WithMany()
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketHorseTrainer.API.Models.JournalIssue", null)
                        .WithMany("JournalIssues")
                        .HasForeignKey("JournalIssueEntryId", "JournalIssueIssueId");

                    b.Navigation("Entry");

                    b.Navigation("Issue");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.JournalStrength", b =>
                {
                    b.HasOne("PocketHorseTrainer.API.Models.JournalEntry", "Entry")
                        .WithMany("Strengths")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketHorseTrainer.API.Models.TargetAreas", "Strength")
                        .WithMany()
                        .HasForeignKey("StrengthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketHorseTrainer.API.Models.JournalStrength", null)
                        .WithMany("JournalStrengths")
                        .HasForeignKey("JournalStrengthEntryId", "JournalStrengthStrengthId");

                    b.Navigation("Entry");

                    b.Navigation("Strength");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.ReportIssue", b =>
                {
                    b.HasOne("PocketHorseTrainer.API.Models.TargetAreas", "Issue")
                        .WithMany()
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketHorseTrainer.API.Models.Report", "Report")
                        .WithMany("Issues")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketHorseTrainer.API.Models.ReportIssue", null)
                        .WithMany("ReportIssues")
                        .HasForeignKey("ReportIssueReportId", "ReportIssueIssueId");

                    b.Navigation("Issue");

                    b.Navigation("Report");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.ReportStrength", b =>
                {
                    b.HasOne("PocketHorseTrainer.API.Models.Report", "Report")
                        .WithMany("Strengths")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketHorseTrainer.API.Models.TargetAreas", "Strength")
                        .WithMany()
                        .HasForeignKey("StrengthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketHorseTrainer.API.Models.ReportStrength", null)
                        .WithMany("ReportStrengths")
                        .HasForeignKey("ReportStrengthReportId", "ReportStrengthStrengthId");

                    b.Navigation("Report");

                    b.Navigation("Strength");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.ApplicationUser", b =>
                {
                    b.Navigation("Horses");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.Barn", b =>
                {
                    b.Navigation("Horses");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.Horse", b =>
                {
                    b.Navigation("Goals");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.HorseBarn", b =>
                {
                    b.Navigation("BarnHorses");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.HorseGoal", b =>
                {
                    b.Navigation("HorseGoals");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.HorseOwner", b =>
                {
                    b.Navigation("HorseOwners");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.JournalEntry", b =>
                {
                    b.Navigation("Issues");

                    b.Navigation("Strengths");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.JournalIssue", b =>
                {
                    b.Navigation("JournalIssues");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.JournalStrength", b =>
                {
                    b.Navigation("JournalStrengths");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.Report", b =>
                {
                    b.Navigation("Issues");

                    b.Navigation("Strengths");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.ReportIssue", b =>
                {
                    b.Navigation("ReportIssues");
                });

            modelBuilder.Entity("PocketHorseTrainer.API.Models.ReportStrength", b =>
                {
                    b.Navigation("ReportStrengths");
                });
#pragma warning restore 612, 618
        }
    }
}
