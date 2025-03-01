using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityProject.Migrations
{
    /// <inheritdoc />
    public partial class SchduleGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hall_Location_LocationID",
                table: "Hall");

            migrationBuilder.DropIndex(
                name: "IX_Hall_LocationID",
                table: "Hall");

            migrationBuilder.CreateTable(
                name: "HallLocation",
                columns: table => new
                {
                    HallID = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallLocation", x => new { x.HallID, x.LocationId });
                    table.ForeignKey(
                        name: "FK_HallLocation_Hall_HallID",
                        column: x => x.HallID,
                        principalTable: "Hall",
                        principalColumn: "HallID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HallLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Shift = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleID);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Group_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "ScheduleID");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5868b1ad-8785-4029-8187-1199b4d22bb1", "56a2b9ce-5107-4469-a195-11fef148ab60", "Admin", "ADMIN" },
                    { "903fd297-a3fb-464f-af3e-89720abc335f", "c6f6b724-285c-4550-827e-fb60ce6a4982", "Professor", "PROFESSOR" },
                    { "bedb63e6-2c7d-4bec-adb8-7e47d8653479", "1f629fa7-38ac-4332-addb-8f43a9bb8b3a", "Student", "STUDENT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_ScheduleId",
                table: "Group",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_HallLocation_LocationId",
                table: "HallLocation",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "HallLocation");

            migrationBuilder.DropTable(
                name: "Schedule");

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

            migrationBuilder.CreateIndex(
                name: "IX_Hall_LocationID",
                table: "Hall",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hall_Location_LocationID",
                table: "Hall",
                column: "LocationID",
                principalTable: "Location",
                principalColumn: "LocationId");
        }
    }
}
