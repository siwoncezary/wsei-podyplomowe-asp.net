using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Z2.Migrations
{
    /// <inheritdoc />
    public partial class roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbe780e1-20a3-466f-921a-88a14bdc929c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23f79b61-206b-4fbf-a6ec-43be75f98671");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98c48f0b-2428-4790-bdf4-d9bbc1f4fd43", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "738717a1-a3d1-4712-854e-05c88a88970a", 0, "738717a1-a3d1-4712-854e-05c88a88970a", "admin@wsei.edu.pl", true, false, null, "ADMIN@WSEI.EDU.PL", "ADMIN@WSEI.EDU.PL", "AQAAAAIAAYagAAAAEJFkyuLkc9kwmvS5J0nz+Su47HteMuwTZaVN+vewPR0kqiLT6V0DsmVUeZ8rEYA5wQ==", null, false, "9c09ef64-f33a-4676-b4fa-6f1df84842f5", false, "admin@wsei.edu.pl" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "98c48f0b-2428-4790-bdf4-d9bbc1f4fd43", "738717a1-a3d1-4712-854e-05c88a88970a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "98c48f0b-2428-4790-bdf4-d9bbc1f4fd43", "738717a1-a3d1-4712-854e-05c88a88970a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98c48f0b-2428-4790-bdf4-d9bbc1f4fd43");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "738717a1-a3d1-4712-854e-05c88a88970a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bbe780e1-20a3-466f-921a-88a14bdc929c", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "23f79b61-206b-4fbf-a6ec-43be75f98671", 0, "23f79b61-206b-4fbf-a6ec-43be75f98671", "admin@wsei.edu.pl", true, false, null, "ADMIN@WSEI.EDU.PL", "ADMIN@WSEI.EDU.PL", "AQAAAAIAAYagAAAAEKKT33Vf3F8yRkgC49caGlRn613aFqR7AumQPQA640Kkcmfjh8VPtHtiQZ4nMfLctQ==", null, false, "332a0845-e905-4ff3-84c6-a1067f3de9b0", false, "admin@wsei.edu.pl" });
        }
    }
}
