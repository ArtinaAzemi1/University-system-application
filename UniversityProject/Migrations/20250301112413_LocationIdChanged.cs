using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProject.Migrations
{
    /// <inheritdoc />
    public partial class LocationIdChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HallLocation");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "Hall",
                newName: "LocationId");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Hall",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hall_LocationId",
                table: "Hall",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hall_Location_LocationId",
                table: "Hall",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hall_Location_LocationId",
                table: "Hall");

            migrationBuilder.DropIndex(
                name: "IX_Hall_LocationId",
                table: "Hall");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Hall",
                newName: "LocationID");

            migrationBuilder.AlterColumn<int>(
                name: "LocationID",
                table: "Hall",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.CreateIndex(
                name: "IX_HallLocation_LocationId",
                table: "HallLocation",
                column: "LocationId");
        }
    }
}
