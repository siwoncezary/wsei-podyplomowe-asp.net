using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Z2.Migrations
{
    /// <inheritdoc />
    public partial class sqlite_migration_198 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_Authors_AuthorId",
                table: "books");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "books",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_books_Authors_AuthorId",
                table: "books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_Authors_AuthorId",
                table: "books");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "books",
                type: "INTEGER",
                maxLength: 50,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_books_Authors_AuthorId",
                table: "books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
