using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityProject.Migrations
{
    /// <inheritdoc />
    public partial class MStudentProfessorChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professor_User_UserId",
                table: "Professor");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_User_UserId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Student_UserId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Professor_UserId",
                table: "Professor");

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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Professor");

            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "Student",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "Professor",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_AspNetUserId",
                table: "Student",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_AspNetUserId",
                table: "Professor",
                column: "AspNetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_AspNetUsers_AspNetUserId",
                table: "Professor",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_AspNetUsers_AspNetUserId",
                table: "Student",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professor_AspNetUsers_AspNetUserId",
                table: "Professor");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_AspNetUsers_AspNetUserId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_AspNetUserId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Professor_AspNetUserId",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "Professor");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Professor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AspNetUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_AspNetUsers_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "679fc2bc-0e83-4310-aff2-a4b6f470a3a3", "c18071fd-6aac-42de-96c5-d872ebbfd32c", "Student", "STUDENT" },
                    { "c8622f63-169a-4f6a-abcc-059dd7da1630", "bbb6d776-4d26-47fb-a2a0-cd66130cb02e", "Admin", "ADMIN" },
                    { "f720156f-2ff6-4892-abaf-7010ba301edf", "8d45b0c2-17b6-4e20-9f2c-23387970c5d0", "Professor", "PROFESSOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_UserId",
                table: "Professor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_AspNetUserId",
                table: "User",
                column: "AspNetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_User_UserId",
                table: "Professor",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_User_UserId",
                table: "Student",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
