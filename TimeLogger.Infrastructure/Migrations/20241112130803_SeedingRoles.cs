using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TimeLogger.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0afaee79-ef9f-43ed-8d28-cd970ea61247");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e63009e-9cd8-405a-bfae-bf389b3dec70");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8625a3b6-1afb-429e-802b-a34cafe1e649", null, "Admin", "ADMIN" },
                    { "b70c3c2b-822c-42ab-a26f-18b49c048659", null, "Employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8625a3b6-1afb-429e-802b-a34cafe1e649");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b70c3c2b-822c-42ab-a26f-18b49c048659");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0afaee79-ef9f-43ed-8d28-cd970ea61247", null, "Employee", "EMPLOYEE" },
                    { "1e63009e-9cd8-405a-bfae-bf389b3dec70", null, "Admin", "ADMIN" }
                });
        }
    }
}
