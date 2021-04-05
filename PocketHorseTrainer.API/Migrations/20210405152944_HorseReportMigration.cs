using Microsoft.EntityFrameworkCore.Migrations;

namespace PocketHorseTrainer.API.Migrations
{
    public partial class HorseReportMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HorseId",
                table: "TrainingReports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingReports_HorseId",
                table: "TrainingReports",
                column: "HorseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingReports_Horses_HorseId",
                table: "TrainingReports",
                column: "HorseId",
                principalTable: "Horses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingReports_Horses_HorseId",
                table: "TrainingReports");

            migrationBuilder.DropIndex(
                name: "IX_TrainingReports_HorseId",
                table: "TrainingReports");

            migrationBuilder.DropColumn(
                name: "HorseId",
                table: "TrainingReports");
        }
    }
}
