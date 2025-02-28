using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityProject.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "679fc2bc-0e83-4310-aff2-a4b6f470a3a3", "c18071fd-6aac-42de-96c5-d872ebbfd32c", "Student", "STUDENT" },
                    { "c8622f63-169a-4f6a-abcc-059dd7da1630", "bbb6d776-4d26-47fb-a2a0-cd66130cb02e", "Admin", "ADMIN" },
                    { "f720156f-2ff6-4892-abaf-7010ba301edf", "8d45b0c2-17b6-4e20-9f2c-23387970c5d0", "Professor", "PROFESSOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "679fc2bc-0e83-4310-aff2-a4b6f470a3a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8622f63-169a-4f6a-abcc-059dd7da1630");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f720156f-2ff6-4892-abaf-7010ba301edf");
        }
    }
}
