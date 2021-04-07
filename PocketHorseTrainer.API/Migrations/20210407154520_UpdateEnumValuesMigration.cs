using Microsoft.EntityFrameworkCore.Migrations;

namespace PocketHorseTrainer.API.Migrations
{
    public partial class UpdateEnumValuesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CloudCover",
                table: "Weather",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroundCondition",
                table: "Weather",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Precipitation",
                table: "Weather",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Visibility",
                table: "Weather",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wind",
                table: "Weather",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HorseId",
                table: "TrainingGoals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BackLeft",
                table: "Markings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BackRight",
                table: "Markings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FaceMarking",
                table: "Markings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FrontLeft",
                table: "Markings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FrontRight",
                table: "Markings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Discipline",
                table: "JournalEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingGoals_HorseId",
                table: "TrainingGoals",
                column: "HorseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingGoals_Horses_HorseId",
                table: "TrainingGoals",
                column: "HorseId",
                principalTable: "Horses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingGoals_Horses_HorseId",
                table: "TrainingGoals");

            migrationBuilder.DropIndex(
                name: "IX_TrainingGoals_HorseId",
                table: "TrainingGoals");

            migrationBuilder.DropColumn(
                name: "CloudCover",
                table: "Weather");

            migrationBuilder.DropColumn(
                name: "GroundCondition",
                table: "Weather");

            migrationBuilder.DropColumn(
                name: "Precipitation",
                table: "Weather");

            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Weather");

            migrationBuilder.DropColumn(
                name: "Wind",
                table: "Weather");

            migrationBuilder.DropColumn(
                name: "HorseId",
                table: "TrainingGoals");

            migrationBuilder.DropColumn(
                name: "BackLeft",
                table: "Markings");

            migrationBuilder.DropColumn(
                name: "BackRight",
                table: "Markings");

            migrationBuilder.DropColumn(
                name: "FaceMarking",
                table: "Markings");

            migrationBuilder.DropColumn(
                name: "FrontLeft",
                table: "Markings");

            migrationBuilder.DropColumn(
                name: "FrontRight",
                table: "Markings");

            migrationBuilder.DropColumn(
                name: "Discipline",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Appointments");
        }
    }
}
