using Microsoft.EntityFrameworkCore.Migrations;

namespace PocketHorseTrainer.API.Migrations
{
    public partial class HorseJournalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HorseJournals",
                columns: table => new
                {
                    HorseId = table.Column<int>(type: "int", nullable: false),
                    EntryId = table.Column<int>(type: "int", nullable: false),
                    HorseJournalEntryId = table.Column<int>(type: "int", nullable: true),
                    HorseJournalHorseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseJournals", x => new { x.HorseId, x.EntryId });
                    table.ForeignKey(
                        name: "FK_HorseJournals_HorseJournals_HorseJournalHorseId_HorseJournalEntryId",
                        columns: x => new { x.HorseJournalHorseId, x.HorseJournalEntryId },
                        principalTable: "HorseJournals",
                        principalColumns: new[] { "HorseId", "EntryId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorseJournals_Horses_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorseJournals_JournalEntries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "JournalEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HorseJournals_EntryId",
                table: "HorseJournals",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseJournals_HorseJournalHorseId_HorseJournalEntryId",
                table: "HorseJournals",
                columns: new[] { "HorseJournalHorseId", "HorseJournalEntryId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorseJournals");
        }
    }
}
