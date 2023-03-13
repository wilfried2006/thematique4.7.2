using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LamyThematique.Infrastructure.Database.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2023, 3, 13, 15, 22, 22, 180, DateTimeKind.Local).AddTicks(9779)),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 100, nullable: false),
                    Label = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 250, nullable: false),
                    LastName = table.Column<string>(maxLength: 250, nullable: false),
                    AccessCode = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SousThemes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2023, 3, 13, 15, 22, 22, 166, DateTimeKind.Local).AddTicks(2957)),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 100, nullable: false),
                    Label = table.Column<string>(maxLength: 250, nullable: false),
                    ThemeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SousThemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SousThemes_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Themes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sujets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true, defaultValue: "1"),
                    Created = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2023, 3, 13, 15, 22, 22, 180, DateTimeKind.Local).AddTicks(9779)),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 100, nullable: false),
                    Label = table.Column<string>(maxLength: 250, nullable: false),
                    SousThemeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sujets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sujets_SousThemes_SousThemeId",
                        column: x => x.SousThemeId,
                        principalTable: "SousThemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SousThemes_ThemeId",
                table: "SousThemes",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sujets_SousThemeId",
                table: "Sujets",
                column: "SousThemeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sujets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SousThemes");

            migrationBuilder.DropTable(
                name: "Themes");
        }
    }
}
