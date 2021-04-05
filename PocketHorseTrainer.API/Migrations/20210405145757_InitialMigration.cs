using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PocketHorseTrainer.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recurring = table.Column<bool>(type: "bit", nullable: false),
                    NumOfWeeks = table.Column<int>(type: "int", nullable: false),
                    NextAppDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Markings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TargetAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeSpan = table.Column<int>(type: "int", nullable: false),
                    TimeHandling = table.Column<float>(type: "real", nullable: false),
                    TimeRiding = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TempF = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Barns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barns_AspNetUsers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Barns_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingGoals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSpan = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AreaOfImprovementId = table.Column<int>(type: "int", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingGoals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingGoals_TargetAreas_AreaOfImprovementId",
                        column: x => x.AreaOfImprovementId,
                        principalTable: "TargetAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportIssues",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    IssueId = table.Column<int>(type: "int", nullable: false),
                    ReportIssueIssueId = table.Column<int>(type: "int", nullable: true),
                    ReportIssueReportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportIssues", x => new { x.ReportId, x.IssueId });
                    table.ForeignKey(
                        name: "FK_ReportIssues_ReportIssues_ReportIssueReportId_ReportIssueIssueId",
                        columns: x => new { x.ReportIssueReportId, x.ReportIssueIssueId },
                        principalTable: "ReportIssues",
                        principalColumns: new[] { "ReportId", "IssueId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportIssues_TargetAreas_IssueId",
                        column: x => x.IssueId,
                        principalTable: "TargetAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportIssues_TrainingReports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "TrainingReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportStrengths",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    StrengthId = table.Column<int>(type: "int", nullable: false),
                    ReportStrengthReportId = table.Column<int>(type: "int", nullable: true),
                    ReportStrengthStrengthId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportStrengths", x => new { x.ReportId, x.StrengthId });
                    table.ForeignKey(
                        name: "FK_ReportStrengths_ReportStrengths_ReportStrengthReportId_ReportStrengthStrengthId",
                        columns: x => new { x.ReportStrengthReportId, x.ReportStrengthStrengthId },
                        principalTable: "ReportStrengths",
                        principalColumns: new[] { "ReportId", "StrengthId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportStrengths_TargetAreas_StrengthId",
                        column: x => x.StrengthId,
                        principalTable: "TargetAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportStrengths_TrainingReports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "TrainingReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BarnId = table.Column<int>(type: "int", nullable: true),
                    Breed = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    MarkingsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horses_Barns_BarnId",
                        column: x => x.BarnId,
                        principalTable: "Barns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Horses_Markings_MarkingsId",
                        column: x => x.MarkingsId,
                        principalTable: "Markings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BarnHorses",
                columns: table => new
                {
                    HorseId = table.Column<int>(type: "int", nullable: false),
                    BarnId = table.Column<int>(type: "int", nullable: false),
                    HorseBarnBarnId = table.Column<int>(type: "int", nullable: true),
                    HorseBarnHorseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarnHorses", x => new { x.HorseId, x.BarnId });
                    table.ForeignKey(
                        name: "FK_BarnHorses_BarnHorses_HorseBarnHorseId_HorseBarnBarnId",
                        columns: x => new { x.HorseBarnHorseId, x.HorseBarnBarnId },
                        principalTable: "BarnHorses",
                        principalColumns: new[] { "HorseId", "BarnId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BarnHorses_Barns_BarnId",
                        column: x => x.BarnId,
                        principalTable: "Barns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarnHorses_Horses_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorseGoals",
                columns: table => new
                {
                    HorseId = table.Column<int>(type: "int", nullable: false),
                    GoalId = table.Column<int>(type: "int", nullable: false),
                    HorseGoalGoalId = table.Column<int>(type: "int", nullable: true),
                    HorseGoalHorseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseGoals", x => new { x.HorseId, x.GoalId });
                    table.ForeignKey(
                        name: "FK_HorseGoals_HorseGoals_HorseGoalHorseId_HorseGoalGoalId",
                        columns: x => new { x.HorseGoalHorseId, x.HorseGoalGoalId },
                        principalTable: "HorseGoals",
                        principalColumns: new[] { "HorseId", "GoalId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorseGoals_Horses_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorseGoals_TrainingGoals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "TrainingGoals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorseOwners",
                columns: table => new
                {
                    HorseId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    HorseOwnerHorseId = table.Column<int>(type: "int", nullable: true),
                    HorseOwnerOwnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseOwners", x => new { x.HorseId, x.OwnerId });
                    table.ForeignKey(
                        name: "FK_HorseOwners_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorseOwners_HorseOwners_HorseOwnerHorseId_HorseOwnerOwnerId",
                        columns: x => new { x.HorseOwnerHorseId, x.HorseOwnerOwnerId },
                        principalTable: "HorseOwners",
                        principalColumns: new[] { "HorseId", "OwnerId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorseOwners_Horses_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeHandling = table.Column<float>(type: "real", nullable: false),
                    TimeRiding = table.Column<float>(type: "real", nullable: false),
                    HorseId = table.Column<int>(type: "int", nullable: true),
                    WeatherId = table.Column<int>(type: "int", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JournalEntries_AspNetUsers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalEntries_Horses_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalEntries_Weather_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "Weather",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JournalIssues",
                columns: table => new
                {
                    EntryId = table.Column<int>(type: "int", nullable: false),
                    IssueId = table.Column<int>(type: "int", nullable: false),
                    JournalIssueEntryId = table.Column<int>(type: "int", nullable: true),
                    JournalIssueIssueId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalIssues", x => new { x.EntryId, x.IssueId });
                    table.ForeignKey(
                        name: "FK_JournalIssues_JournalEntries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "JournalEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalIssues_JournalIssues_JournalIssueEntryId_JournalIssueIssueId",
                        columns: x => new { x.JournalIssueEntryId, x.JournalIssueIssueId },
                        principalTable: "JournalIssues",
                        principalColumns: new[] { "EntryId", "IssueId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalIssues_TargetAreas_IssueId",
                        column: x => x.IssueId,
                        principalTable: "TargetAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JournalStrengths",
                columns: table => new
                {
                    EntryId = table.Column<int>(type: "int", nullable: false),
                    StrengthId = table.Column<int>(type: "int", nullable: false),
                    JournalStrengthEntryId = table.Column<int>(type: "int", nullable: true),
                    JournalStrengthStrengthId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalStrengths", x => new { x.EntryId, x.StrengthId });
                    table.ForeignKey(
                        name: "FK_JournalStrengths_JournalEntries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "JournalEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalStrengths_JournalStrengths_JournalStrengthEntryId_JournalStrengthStrengthId",
                        columns: x => new { x.JournalStrengthEntryId, x.JournalStrengthStrengthId },
                        principalTable: "JournalStrengths",
                        principalColumns: new[] { "EntryId", "StrengthId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalStrengths_TargetAreas_StrengthId",
                        column: x => x.StrengthId,
                        principalTable: "TargetAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BarnHorses_BarnId",
                table: "BarnHorses",
                column: "BarnId");

            migrationBuilder.CreateIndex(
                name: "IX_BarnHorses_HorseBarnHorseId_HorseBarnBarnId",
                table: "BarnHorses",
                columns: new[] { "HorseBarnHorseId", "HorseBarnBarnId" });

            migrationBuilder.CreateIndex(
                name: "IX_Barns_ManagerId",
                table: "Barns",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Barns_OwnerId",
                table: "Barns",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseGoals_GoalId",
                table: "HorseGoals",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseGoals_HorseGoalHorseId_HorseGoalGoalId",
                table: "HorseGoals",
                columns: new[] { "HorseGoalHorseId", "HorseGoalGoalId" });

            migrationBuilder.CreateIndex(
                name: "IX_HorseOwners_HorseOwnerHorseId_HorseOwnerOwnerId",
                table: "HorseOwners",
                columns: new[] { "HorseOwnerHorseId", "HorseOwnerOwnerId" });

            migrationBuilder.CreateIndex(
                name: "IX_HorseOwners_OwnerId",
                table: "HorseOwners",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Horses_BarnId",
                table: "Horses",
                column: "BarnId");

            migrationBuilder.CreateIndex(
                name: "IX_Horses_MarkingsId",
                table: "Horses",
                column: "MarkingsId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_HorseId",
                table: "JournalEntries",
                column: "HorseId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_TrainerId",
                table: "JournalEntries",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_WeatherId",
                table: "JournalEntries",
                column: "WeatherId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalIssues_IssueId",
                table: "JournalIssues",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalIssues_JournalIssueEntryId_JournalIssueIssueId",
                table: "JournalIssues",
                columns: new[] { "JournalIssueEntryId", "JournalIssueIssueId" });

            migrationBuilder.CreateIndex(
                name: "IX_JournalStrengths_JournalStrengthEntryId_JournalStrengthStrengthId",
                table: "JournalStrengths",
                columns: new[] { "JournalStrengthEntryId", "JournalStrengthStrengthId" });

            migrationBuilder.CreateIndex(
                name: "IX_JournalStrengths_StrengthId",
                table: "JournalStrengths",
                column: "StrengthId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportIssues_IssueId",
                table: "ReportIssues",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportIssues_ReportIssueReportId_ReportIssueIssueId",
                table: "ReportIssues",
                columns: new[] { "ReportIssueReportId", "ReportIssueIssueId" });

            migrationBuilder.CreateIndex(
                name: "IX_ReportStrengths_ReportStrengthReportId_ReportStrengthStrengthId",
                table: "ReportStrengths",
                columns: new[] { "ReportStrengthReportId", "ReportStrengthStrengthId" });

            migrationBuilder.CreateIndex(
                name: "IX_ReportStrengths_StrengthId",
                table: "ReportStrengths",
                column: "StrengthId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingGoals_AreaOfImprovementId",
                table: "TrainingGoals",
                column: "AreaOfImprovementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BarnHorses");

            migrationBuilder.DropTable(
                name: "HorseGoals");

            migrationBuilder.DropTable(
                name: "HorseOwners");

            migrationBuilder.DropTable(
                name: "JournalIssues");

            migrationBuilder.DropTable(
                name: "JournalStrengths");

            migrationBuilder.DropTable(
                name: "ReportIssues");

            migrationBuilder.DropTable(
                name: "ReportStrengths");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TrainingGoals");

            migrationBuilder.DropTable(
                name: "JournalEntries");

            migrationBuilder.DropTable(
                name: "TrainingReports");

            migrationBuilder.DropTable(
                name: "TargetAreas");

            migrationBuilder.DropTable(
                name: "Horses");

            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Barns");

            migrationBuilder.DropTable(
                name: "Markings");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
