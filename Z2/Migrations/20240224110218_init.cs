using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Z2.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    AuthorId = table.Column<int>(type: "INTEGER", maxLength: 50, nullable: false),
                    Pages = table.Column<int>(type: "INTEGER", nullable: false),
                    ISBN = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    data_wydania = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "freeman@wsei.edu.pl", "Adam", "Freeman" },
                    { 2, "unclebob@wsei.edu.pl", "Robert", "Martin" }
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "AuthorId", "ISBN", "Pages", "data_wydania", "Title" },
                values: new object[] { 1, 1, "334324233545", 1023, new DateOnly(2022, 10, 10), "ASP.NET Core 3.0" });

            migrationBuilder.CreateIndex(
                name: "IX_books_AuthorId",
                table: "books",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
