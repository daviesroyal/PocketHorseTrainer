using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PocketHorseTrainer.API.Migrations
{
    public partial class BreedAndColorMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeSpan",
                table: "TrainingReports");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Horses");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "TrainingReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "TrainingReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "BreedId",
                table: "Horses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Horses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Breed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breed", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoatColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoatColor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Horses_BreedId",
                table: "Horses",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Horses_ColorId",
                table: "Horses",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Horses_Breed_BreedId",
                table: "Horses",
                column: "BreedId",
                principalTable: "Breed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Horses_CoatColor_ColorId",
                table: "Horses",
                column: "ColorId",
                principalTable: "CoatColor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horses_Breed_BreedId",
                table: "Horses");

            migrationBuilder.DropForeignKey(
                name: "FK_Horses_CoatColor_ColorId",
                table: "Horses");

            migrationBuilder.DropTable(
                name: "Breed");

            migrationBuilder.DropTable(
                name: "CoatColor");

            migrationBuilder.DropIndex(
                name: "IX_Horses_BreedId",
                table: "Horses");

            migrationBuilder.DropIndex(
                name: "IX_Horses_ColorId",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "TrainingReports");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "TrainingReports");

            migrationBuilder.DropColumn(
                name: "BreedId",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Horses");

            migrationBuilder.AddColumn<int>(
                name: "TimeSpan",
                table: "TrainingReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Breed",
                table: "Horses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "Horses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
