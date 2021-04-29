using Microsoft.EntityFrameworkCore.Migrations;

namespace PocketHorseTrainer.API.Migrations
{
    public partial class WeatherUpdateMigration : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
