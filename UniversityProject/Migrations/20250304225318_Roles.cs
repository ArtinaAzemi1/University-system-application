using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityProject.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "199ae3a6-6473-4662-8fc0-ed8af03053da", "a4a83f7f-1c7f-4d0d-8a60-bad544f70cc3", "Student", "STUDENT" },
                    { "63665aea-3be5-4507-bab9-d4fb58043c8f", "52c3adf9-328d-4ba6-97f5-d400c103255d", "Professor", "PROFESSOR" },
                    { "7476b109-afae-4e5f-bb09-dfb2bbb637ab", "ec7ba952-03bc-4efa-920c-049e3056ba17", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
