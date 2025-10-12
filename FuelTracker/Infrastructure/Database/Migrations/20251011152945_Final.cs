using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuelTracker.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FuelEntries_UserId",
                table: "FuelEntries");

            migrationBuilder.DropIndex(
                name: "IX_FuelEntries_VehicleId",
                table: "FuelEntries");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserId_Name",
                table: "Vehicles",
                columns: new[] { "UserId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_FuelEntries_UserId_Date",
                table: "FuelEntries",
                columns: new[] { "UserId", "Date" });

            migrationBuilder.CreateIndex(
                name: "IX_FuelEntries_UserId_VehicleId_Date",
                table: "FuelEntries",
                columns: new[] { "UserId", "VehicleId", "Date" });

            migrationBuilder.CreateIndex(
                name: "IX_FuelEntries_VehicleId_Date",
                table: "FuelEntries",
                columns: new[] { "VehicleId", "Date" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehicles_UserId_Name",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_FuelEntries_UserId_Date",
                table: "FuelEntries");

            migrationBuilder.DropIndex(
                name: "IX_FuelEntries_UserId_VehicleId_Date",
                table: "FuelEntries");

            migrationBuilder.DropIndex(
                name: "IX_FuelEntries_VehicleId_Date",
                table: "FuelEntries");

            migrationBuilder.CreateIndex(
                name: "IX_FuelEntries_UserId",
                table: "FuelEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelEntries_VehicleId",
                table: "FuelEntries",
                column: "VehicleId");
        }
    }
}
