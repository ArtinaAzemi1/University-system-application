using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityProject.Migrations
{
    /// <inheritdoc />
    public partial class ScheduleGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Schedule_ScheduleId",
                table: "Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5868b1ad-8785-4029-8187-1199b4d22bb1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "903fd297-a3fb-464f-af3e-89720abc335f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bedb63e6-2c7d-4bec-adb8-7e47d8653479");

            migrationBuilder.RenameTable(
                name: "Schedule",
                newName: "Schedules");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameIndex(
                name: "IX_Group_ScheduleId",
                table: "Groups",
                newName: "IX_Groups_ScheduleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "ScheduleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Schedules_ScheduleId",
                table: "Groups",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "ScheduleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Schedules_ScheduleId",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "Schedule");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_ScheduleId",
                table: "Group",
                newName: "IX_Group_ScheduleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                column: "ScheduleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "GroupId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5868b1ad-8785-4029-8187-1199b4d22bb1", "56a2b9ce-5107-4469-a195-11fef148ab60", "Admin", "ADMIN" },
                    { "903fd297-a3fb-464f-af3e-89720abc335f", "c6f6b724-285c-4550-827e-fb60ce6a4982", "Professor", "PROFESSOR" },
                    { "bedb63e6-2c7d-4bec-adb8-7e47d8653479", "1f629fa7-38ac-4332-addb-8f43a9bb8b3a", "Student", "STUDENT" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Schedule_ScheduleId",
                table: "Group",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "ScheduleID");
        }
    }
}
