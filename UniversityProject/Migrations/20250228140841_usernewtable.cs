using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityProject.Migrations
{
    /// <inheritdoc />
    public partial class usernewtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudentSurname",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "ProfessorName",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "ProfessorSurname",
                table: "Professor");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Professor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AspNetUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_User_UserId",
                table: "Student",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "StudentName",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentSurname",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "Professor",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfessorName",
                table: "Professor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfessorSurname",
                table: "Professor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a9416d5-f735-4d18-a207-f654766762d1", "492a1e60-6f4c-4f36-9ed7-831e66ee0cac", "Professor", "PROFESSOR" },
                    { "235cceee-e714-4fd1-83f5-881d49c27022", "7a2e5728-45f0-48ca-87dc-8af19089aeea", "Student", "STUDENT" },
                    { "935cc9b2-5aea-4a11-963a-cfba4eaa9904", "ed3b35f5-e7aa-4ceb-8965-0c2b2ad3ac2d", "Admin", "ADMIN" }
                });

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
    }
}
