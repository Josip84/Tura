using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DBSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DriverCompanyID = table.Column<string>(type: "text", nullable: false),
                    DriverLastName = table.Column<string>(type: "text", nullable: false),
                    DriverFirstName = table.Column<string>(type: "text", nullable: false),
                    OIB = table.Column<string>(type: "text", nullable: true),
                    ContactNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => new { x.DriverID, x.DriverCompanyID });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiclesType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlateNumber = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleID);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehiclesType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehiclesType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Planner",
                columns: table => new
                {
                    UID = table.Column<Guid>(type: "uuid", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    LPostNumber = table.Column<int>(type: "integer", nullable: false),
                    LPostalNumber = table.Column<int>(type: "integer", nullable: false),
                    LCityTown = table.Column<string>(type: "text", nullable: false),
                    LCountry = table.Column<string>(type: "text", nullable: false),
                    UPostalNumber = table.Column<int>(type: "integer", nullable: false),
                    UCityTown = table.Column<string>(type: "text", nullable: false),
                    UCountry = table.Column<string>(type: "text", nullable: false),
                    VehicleID = table.Column<int>(type: "integer", nullable: false),
                    UvozIzvoz = table.Column<string>(type: "text", nullable: false),
                    TransportPrice = table.Column<double>(type: "double precision", nullable: false),
                    Domaci = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planners", x => x.UID);
                    table.ForeignKey(
                        name: "FK_Planners_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Planners_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    UID = table.Column<Guid>(type: "uuid", nullable: false),
                    TourNumber = table.Column<int>(type: "integer", nullable: false),
                    TourMark = table.Column<string>(type: "text", nullable: false),
                    TourDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Permissions = table.Column<string>(type: "text", nullable: false),
                    Vechicle1IDVehicleID = table.Column<int>(type: "integer", nullable: false),
                    Vechicle2IDVehicleID = table.Column<int>(type: "integer", nullable: false),
                    LPostalNumber = table.Column<int>(type: "integer", nullable: false),
                    LCityTown = table.Column<string>(type: "text", nullable: false),
                    LCountry = table.Column<string>(type: "text", nullable: false),
                    UPostalNumber = table.Column<int>(type: "integer", nullable: false),
                    UCityTown = table.Column<string>(type: "text", nullable: false),
                    UCountry = table.Column<string>(type: "text", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "text", nullable: true),
                    DebtAmount = table.Column<double>(type: "double precision", nullable: false),
                    Received = table.Column<bool>(type: "boolean", nullable: false),
                    IPR = table.Column<bool>(type: "boolean", nullable: false),
                    InvoniceIssued = table.Column<bool>(type: "boolean", nullable: false),
                    Return = table.Column<bool>(type: "boolean", nullable: false),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    MonthlyPayer = table.Column<bool>(type: "boolean", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeIPRId = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.UID);
                    table.ForeignKey(
                        name: "FK_Tours_Users_EmployeeIPRId",
                        column: x => x.EmployeeIPRId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tours_Users_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tours_Vehicles_Vechicle1IDVehicleID",
                        column: x => x.Vechicle1IDVehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tours_Vehicles_Vechicle2IDVehicleID",
                        column: x => x.Vechicle2IDVehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planners_UserId",
                table: "Planner",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Planners_VehicleID",
                table: "Planner",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_EmployeeId",
                table: "Tours",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_EmployeeIPRId",
                table: "Tours",
                column: "EmployeeIPRId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_Vechicle1IDVehicleID",
                table: "Tours",
                column: "Vechicle1IDVehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_Vechicle2IDVehicleID",
                table: "Tours",
                column: "Vechicle2IDVehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Planner");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehiclesType");
        }
    }
}
