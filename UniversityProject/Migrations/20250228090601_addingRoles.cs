using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityProject.Migrations
{
    /// <inheritdoc />
    public partial class addingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a9416d5-f735-4d18-a207-f654766762d1", "492a1e60-6f4c-4f36-9ed7-831e66ee0cac", "Professor", "PROFESSOR" },
                    { "235cceee-e714-4fd1-83f5-881d49c27022", "7a2e5728-45f0-48ca-87dc-8af19089aeea", "Student", "STUDENT" },
                    { "935cc9b2-5aea-4a11-963a-cfba4eaa9904", "ed3b35f5-e7aa-4ceb-8965-0c2b2ad3ac2d", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a9416d5-f735-4d18-a207-f654766762d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "235cceee-e714-4fd1-83f5-881d49c27022");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "935cc9b2-5aea-4a11-963a-cfba4eaa9904");
        }
    }
}
