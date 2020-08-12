using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BP.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserIdentities",
                columns: table => new
                {
                    UserIdentityID = table.Column<Guid>(nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Username = table.Column<string>(maxLength: 255, nullable: false),
                    PasswordHash = table.Column<byte[]>(maxLength: 255, nullable: false),
                    PasswordSalt = table.Column<string>(maxLength: 255, nullable: false),
                    Role = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIdentities", x => x.UserIdentityID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleID = table.Column<Guid>(nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Type = table.Column<string>(maxLength: 255, nullable: false),
                    NumberPlate = table.Column<string>(maxLength: 255, nullable: false),
                    Colour = table.Column<string>(maxLength: 255, nullable: false),
                    AdultSeats = table.Column<int>(nullable: false),
                    InfantSeats = table.Column<int>(nullable: false),
                    BootCapacity = table.Column<int>(nullable: false),
                    CurrentLat = table.Column<double>(nullable: true),
                    CurrentLng = table.Column<double>(nullable: true),
                    IsShared = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<Guid>(nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    Surname = table.Column<string>(maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    CurrentLat = table.Column<double>(nullable: true),
                    CurrentLng = table.Column<double>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    UserIdentityID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_UserIdentities_UserIdentityID",
                        column: x => x.UserIdentityID,
                        principalTable: "UserIdentities",
                        principalColumn: "UserIdentityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverID = table.Column<Guid>(nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    Surname = table.Column<string>(maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    UserIdentityID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverID);
                    table.ForeignKey(
                        name: "FK_Drivers_UserIdentities_UserIdentityID",
                        column: x => x.UserIdentityID,
                        principalTable: "UserIdentities",
                        principalColumn: "UserIdentityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    StartTime = table.Column<DateTime>(nullable: false),
                    VehicleArriveEstimate = table.Column<DateTime>(nullable: false),
                    EndTimeEstimate = table.Column<DateTime>(nullable: true),
                    StartLocationLat = table.Column<double>(nullable: false),
                    StartLocationLng = table.Column<double>(nullable: false),
                    EndLocationLat = table.Column<double>(nullable: true),
                    EndLocationLng = table.Column<double>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true, defaultValue: true),
                    CustomerID = table.Column<Guid>(nullable: false),
                    VehicleID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleRents",
                columns: table => new
                {
                    VehicleRentID = table.Column<Guid>(nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    TimeFrom = table.Column<DateTime>(nullable: true),
                    TimeUntil = table.Column<DateTime>(nullable: true),
                    IsOwned = table.Column<bool>(nullable: false),
                    VehicleID = table.Column<Guid>(nullable: false),
                    DriverID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleRents", x => x.VehicleRentID);
                    table.ForeignKey(
                        name: "FK_VehicleRents_Drivers_DriverID",
                        column: x => x.DriverID,
                        principalTable: "Drivers",
                        principalColumn: "DriverID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleRents_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserIdentityID",
                table: "Customers",
                column: "UserIdentityID");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_UserIdentityID",
                table: "Drivers",
                column: "UserIdentityID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VehicleID",
                table: "Orders",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRents_DriverID",
                table: "VehicleRents",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRents_VehicleID",
                table: "VehicleRents",
                column: "VehicleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "VehicleRents");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "UserIdentities");
        }
    }
}
