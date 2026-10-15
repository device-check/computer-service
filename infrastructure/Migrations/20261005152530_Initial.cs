using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TableBuilding",
                columns: table => new
                {
                    id_building = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableBuilding", x => x.id_building);
                });

            migrationBuilder.CreateTable(
                name: "TableCampus",
                columns: table => new
                {
                    id_campus = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampusName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableCampus", x => x.id_campus);
                });

            migrationBuilder.CreateTable(
                name: "TableComputerPowerStatus",
                columns: table => new
                {
                    id_computer_power_status = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableComputerPowerStatus", x => x.id_computer_power_status);
                });

            migrationBuilder.CreateTable(
                name: "TableComputerType",
                columns: table => new
                {
                    id_computer_type = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComputerTypeName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableComputerType", x => x.id_computer_type);
                });

            migrationBuilder.CreateTable(
                name: "TableRoom",
                columns: table => new
                {
                    id_room = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableRoom", x => x.id_room);
                });

            migrationBuilder.CreateTable(
                name: "TableComputerPhysicalLocation",
                columns: table => new
                {
                    id_computer_physical_location = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    _floorNumber = table.Column<int>(type: "int", nullable: false),
                    id_building = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_campus = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_room = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableComputerPhysicalLocation", x => x.id_computer_physical_location);
                    table.ForeignKey(
                        name: "FK_TableComputerPhysicalLocation_TableBuilding_id_building",
                        column: x => x.id_building,
                        principalTable: "TableBuilding",
                        principalColumn: "id_building",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableComputerPhysicalLocation_TableCampus_id_campus",
                        column: x => x.id_campus,
                        principalTable: "TableCampus",
                        principalColumn: "id_campus",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableComputerPhysicalLocation_TableRoom_id_room",
                        column: x => x.id_room,
                        principalTable: "TableRoom",
                        principalColumn: "id_room",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableComputer",
                columns: table => new
                {
                    id_computer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComputerIpv4Address = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComputerMacAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id_computer_physical_location = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_computer_power_status = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_computer_type = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_support = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableComputer", x => x.id_computer);
                    table.ForeignKey(
                        name: "FK_TableComputer_TableComputerPhysicalLocation_id_computer_physical_location",
                        column: x => x.id_computer_physical_location,
                        principalTable: "TableComputerPhysicalLocation",
                        principalColumn: "id_computer_physical_location",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableComputer_TableComputerPowerStatus_id_computer_power_status",
                        column: x => x.id_computer_power_status,
                        principalTable: "TableComputerPowerStatus",
                        principalColumn: "id_computer_power_status",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableComputer_TableComputerType_id_computer_type",
                        column: x => x.id_computer_type,
                        principalTable: "TableComputerType",
                        principalColumn: "id_computer_type",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TableBuilding_BuildingName",
                table: "TableBuilding",
                column: "BuildingName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableCampus_CampusName",
                table: "TableCampus",
                column: "CampusName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableComputer_ComputerIpv4Address",
                table: "TableComputer",
                column: "ComputerIpv4Address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableComputer_ComputerMacAddress",
                table: "TableComputer",
                column: "ComputerMacAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableComputer_id_computer_physical_location",
                table: "TableComputer",
                column: "id_computer_physical_location");

            migrationBuilder.CreateIndex(
                name: "IX_TableComputer_id_computer_power_status",
                table: "TableComputer",
                column: "id_computer_power_status");

            migrationBuilder.CreateIndex(
                name: "IX_TableComputer_id_computer_type",
                table: "TableComputer",
                column: "id_computer_type");

            migrationBuilder.CreateIndex(
                name: "IX_TableComputerPhysicalLocation_id_building",
                table: "TableComputerPhysicalLocation",
                column: "id_building");

            migrationBuilder.CreateIndex(
                name: "IX_TableComputerPhysicalLocation_id_campus_id_building__floorNumber_id_room",
                table: "TableComputerPhysicalLocation",
                columns: new[] { "id_campus", "id_building", "_floorNumber", "id_room" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableComputerPhysicalLocation_id_room",
                table: "TableComputerPhysicalLocation",
                column: "id_room");

            migrationBuilder.CreateIndex(
                name: "IX_TableComputerPowerStatus_StatusName",
                table: "TableComputerPowerStatus",
                column: "StatusName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableComputerType_ComputerTypeName",
                table: "TableComputerType",
                column: "ComputerTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableRoom_RoomName",
                table: "TableRoom",
                column: "RoomName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableComputer");

            migrationBuilder.DropTable(
                name: "TableComputerPhysicalLocation");

            migrationBuilder.DropTable(
                name: "TableComputerPowerStatus");

            migrationBuilder.DropTable(
                name: "TableComputerType");

            migrationBuilder.DropTable(
                name: "TableBuilding");

            migrationBuilder.DropTable(
                name: "TableCampus");

            migrationBuilder.DropTable(
                name: "TableRoom");
        }
    }
}
