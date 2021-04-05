using Microsoft.EntityFrameworkCore.Migrations;

namespace PocketHorseTrainer.API.Migrations
{
    public partial class UpdateHorseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Horses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Horses_OwnerId",
                table: "Horses",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Horses_AspNetUsers_OwnerId",
                table: "Horses",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horses_AspNetUsers_OwnerId",
                table: "Horses");

            migrationBuilder.DropIndex(
                name: "IX_Horses_OwnerId",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Horses");
        }
    }
}
