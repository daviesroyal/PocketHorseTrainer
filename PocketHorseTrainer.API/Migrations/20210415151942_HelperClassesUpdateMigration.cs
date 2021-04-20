using Microsoft.EntityFrameworkCore.Migrations;

namespace PocketHorseTrainer.API.Migrations
{
    public partial class HelperClassesUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "BackLeftId",
                table: "Markings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BackRightId",
                table: "Markings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FaceMarkingId",
                table: "Markings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FrontLeftId",
                table: "Markings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FrontRightId",
                table: "Markings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FaceMarking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaceMarking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegMarking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegMarking", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Markings_BackLeftId",
                table: "Markings",
                column: "BackLeftId");

            migrationBuilder.CreateIndex(
                name: "IX_Markings_BackRightId",
                table: "Markings",
                column: "BackRightId");

            migrationBuilder.CreateIndex(
                name: "IX_Markings_FaceMarkingId",
                table: "Markings",
                column: "FaceMarkingId");

            migrationBuilder.CreateIndex(
                name: "IX_Markings_FrontLeftId",
                table: "Markings",
                column: "FrontLeftId");

            migrationBuilder.CreateIndex(
                name: "IX_Markings_FrontRightId",
                table: "Markings",
                column: "FrontRightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Markings_FaceMarking_FaceMarkingId",
                table: "Markings",
                column: "FaceMarkingId",
                principalTable: "FaceMarking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Markings_LegMarking_BackLeftId",
                table: "Markings",
                column: "BackLeftId",
                principalTable: "LegMarking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Markings_LegMarking_BackRightId",
                table: "Markings",
                column: "BackRightId",
                principalTable: "LegMarking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Markings_LegMarking_FrontLeftId",
                table: "Markings",
                column: "FrontLeftId",
                principalTable: "LegMarking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Markings_LegMarking_FrontRightId",
                table: "Markings",
                column: "FrontRightId",
                principalTable: "LegMarking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Markings_FaceMarking_FaceMarkingId",
                table: "Markings");

            migrationBuilder.DropForeignKey(
                name: "FK_Markings_LegMarking_BackLeftId",
                table: "Markings");

            migrationBuilder.DropForeignKey(
                name: "FK_Markings_LegMarking_BackRightId",
                table: "Markings");

            migrationBuilder.DropForeignKey(
                name: "FK_Markings_LegMarking_FrontLeftId",
                table: "Markings");

            migrationBuilder.DropForeignKey(
                name: "FK_Markings_LegMarking_FrontRightId",
                table: "Markings");

            migrationBuilder.DropTable(
                name: "FaceMarking");

            migrationBuilder.DropTable(
                name: "LegMarking");

            migrationBuilder.DropIndex(
                name: "IX_Markings_BackLeftId",
                table: "Markings");

            migrationBuilder.DropIndex(
                name: "IX_Markings_BackRightId",
                table: "Markings");

            migrationBuilder.DropIndex(
                name: "IX_Markings_FaceMarkingId",
                table: "Markings");

            migrationBuilder.DropIndex(
                name: "IX_Markings_FrontLeftId",
                table: "Markings");

            migrationBuilder.DropIndex(
                name: "IX_Markings_FrontRightId",
                table: "Markings");

            migrationBuilder.DropColumn(
                name: "BackLeftId",
                table: "Markings");

            migrationBuilder.DropColumn(
                name: "BackRightId",
                table: "Markings");

            migrationBuilder.DropColumn(
                name: "FaceMarkingId",
                table: "Markings");

            migrationBuilder.DropColumn(
                name: "FrontLeftId",
                table: "Markings");

            migrationBuilder.DropColumn(
                name: "FrontRightId",
                table: "Markings");

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
        }
    }
}
