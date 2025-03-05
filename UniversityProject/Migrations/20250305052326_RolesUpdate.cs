using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityProject.Migrations
{
    /// <inheritdoc />
    public partial class RolesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Schedules_ScheduleId",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "ScheduleId",
                table: "Groups",
                newName: "SemesterID");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_ScheduleId",
                table: "Groups",
                newName: "IX_Groups_SemesterID");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HallID",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0349440b-a1e4-4f6b-9c15-58917ed78da8", "05e7de18-4373-48a7-a3cc-748b2cb4d603", "Professor", "PROFESSOR" },
                    { "9df0ebcf-4581-4e64-aa10-f3850fcc878a", "74579c67-0097-439e-87e3-7d411a5f51c4", "Student", "STUDENT" },
                    { "fbdc6b14-20b3-4866-8c00-ee04273110ef", "a0fc4631-192d-4975-8db8-6dade73bf765", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_CourseId",
                table: "Schedules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_GroupId",
                table: "Schedules",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_HallID",
                table: "Schedules",
                column: "HallID");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Semester_SemesterID",
                table: "Groups",
                column: "SemesterID",
                principalTable: "Semester",
                principalColumn: "SemesterID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Course_CourseId",
                table: "Schedules",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Groups_GroupId",
                table: "Schedules",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Hall_HallID",
                table: "Schedules",
                column: "HallID",
                principalTable: "Hall",
                principalColumn: "HallID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Semester_SemesterID",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Course_CourseId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Groups_GroupId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Hall_HallID",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_CourseId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_GroupId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_HallID",
                table: "Schedules");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0349440b-a1e4-4f6b-9c15-58917ed78da8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9df0ebcf-4581-4e64-aa10-f3850fcc878a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbdc6b14-20b3-4866-8c00-ee04273110ef");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "HallID",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "SemesterID",
                table: "Groups",
                newName: "ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_SemesterID",
                table: "Groups",
                newName: "IX_Groups_ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Schedules_ScheduleId",
                table: "Groups",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "ScheduleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
