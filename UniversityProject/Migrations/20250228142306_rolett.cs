using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityProject.Migrations
{
    /// <inheritdoc />
    public partial class rolett : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b969c4f-15cc-47ba-9380-d865698751ff", "4aa41ba9-9f6b-4468-88e2-33d184846db2", "Professor", "PROFESSOR" },
                    { "6a708edf-0fd5-4cad-afb4-789fdbeb1f68", "4a1ed6a6-2fff-46fa-b92a-183f77536dae", "Admin", "ADMIN" },
                    { "8fa0ee66-5d0f-4351-a933-1187dedac999", "7345fbcf-4019-47fd-b86a-cc794e84e9e2", "Student", "STUDENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b969c4f-15cc-47ba-9380-d865698751ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a708edf-0fd5-4cad-afb4-789fdbeb1f68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fa0ee66-5d0f-4351-a933-1187dedac999");
        }
    }
}
