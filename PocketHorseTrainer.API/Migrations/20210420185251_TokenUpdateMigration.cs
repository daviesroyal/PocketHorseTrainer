using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PocketHorseTrainer.API.Migrations
{
    public partial class TokenUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horses_Breed_BreedId",
                table: "Horses");

            migrationBuilder.DropForeignKey(
                name: "FK_Horses_CoatColor_ColorId",
                table: "Horses");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_LegMarking",
                table: "LegMarking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FaceMarking",
                table: "FaceMarking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoatColor",
                table: "CoatColor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Breed",
                table: "Breed");

            migrationBuilder.RenameTable(
                name: "LegMarking",
                newName: "LegMarkings");

            migrationBuilder.RenameTable(
                name: "FaceMarking",
                newName: "FaceMarkings");

            migrationBuilder.RenameTable(
                name: "CoatColor",
                newName: "Colors");

            migrationBuilder.RenameTable(
                name: "Breed",
                newName: "Breeds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LegMarkings",
                table: "LegMarkings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FaceMarkings",
                table: "FaceMarkings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Breeds",
                table: "Breeds",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevokedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_ApplicationUserId",
                table: "RefreshToken",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Horses_Breeds_BreedId",
                table: "Horses",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Horses_Colors_ColorId",
                table: "Horses",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Markings_FaceMarkings_FaceMarkingId",
                table: "Markings",
                column: "FaceMarkingId",
                principalTable: "FaceMarkings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Markings_LegMarkings_BackLeftId",
                table: "Markings",
                column: "BackLeftId",
                principalTable: "LegMarkings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Markings_LegMarkings_BackRightId",
                table: "Markings",
                column: "BackRightId",
                principalTable: "LegMarkings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Markings_LegMarkings_FrontLeftId",
                table: "Markings",
                column: "FrontLeftId",
                principalTable: "LegMarkings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Markings_LegMarkings_FrontRightId",
                table: "Markings",
                column: "FrontRightId",
                principalTable: "LegMarkings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horses_Breeds_BreedId",
                table: "Horses");

            migrationBuilder.DropForeignKey(
                name: "FK_Horses_Colors_ColorId",
                table: "Horses");

            migrationBuilder.DropForeignKey(
                name: "FK_Markings_FaceMarkings_FaceMarkingId",
                table: "Markings");

            migrationBuilder.DropForeignKey(
                name: "FK_Markings_LegMarkings_BackLeftId",
                table: "Markings");

            migrationBuilder.DropForeignKey(
                name: "FK_Markings_LegMarkings_BackRightId",
                table: "Markings");

            migrationBuilder.DropForeignKey(
                name: "FK_Markings_LegMarkings_FrontLeftId",
                table: "Markings");

            migrationBuilder.DropForeignKey(
                name: "FK_Markings_LegMarkings_FrontRightId",
                table: "Markings");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LegMarkings",
                table: "LegMarkings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FaceMarkings",
                table: "FaceMarkings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Breeds",
                table: "Breeds");

            migrationBuilder.RenameTable(
                name: "LegMarkings",
                newName: "LegMarking");

            migrationBuilder.RenameTable(
                name: "FaceMarkings",
                newName: "FaceMarking");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "CoatColor");

            migrationBuilder.RenameTable(
                name: "Breeds",
                newName: "Breed");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LegMarking",
                table: "LegMarking",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FaceMarking",
                table: "FaceMarking",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoatColor",
                table: "CoatColor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Breed",
                table: "Breed",
                column: "Id");

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
    }
}
