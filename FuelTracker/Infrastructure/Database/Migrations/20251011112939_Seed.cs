using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuelTracker.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        // Requested user ID
        private static readonly Guid SeedUserId = Guid.Parse("0199D2F7-4FDB-7D2A-A706-1FA7A9CDE216");

        // Vehicles
        private static readonly Guid Vehicle1Id = Guid.Parse("33333333-3333-4333-8333-333333333333");
        private static readonly Guid Vehicle2Id = Guid.Parse("44444444-4444-4444-8444-444444444444");
        private static readonly Guid Vehicle3Id = Guid.Parse("55555555-5555-4555-8555-555555555555");

        // Fuel entries (3 per vehicle)
        private static readonly Guid FuelEntry1Id = Guid.Parse("66666666-6666-4666-8666-666666666661");
        private static readonly Guid FuelEntry2Id = Guid.Parse("66666666-6666-4666-8666-666666666662");
        private static readonly Guid FuelEntry3Id = Guid.Parse("66666666-6666-4666-8666-666666666663");

        private static readonly Guid FuelEntry4Id = Guid.Parse("77777777-7777-4777-8777-777777777771");
        private static readonly Guid FuelEntry5Id = Guid.Parse("77777777-7777-4777-8777-777777777772");
        private static readonly Guid FuelEntry6Id = Guid.Parse("77777777-7777-4777-8777-777777777773");

        private static readonly Guid FuelEntry7Id = Guid.Parse("88888888-8888-4888-8888-888888888881");
        private static readonly Guid FuelEntry8Id = Guid.Parse("88888888-8888-4888-8888-888888888882");
        private static readonly Guid FuelEntry9Id = Guid.Parse("88888888-8888-4888-8888-888888888883");

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed vehicles
            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "UserId", "Name", "Make", "Model", "Year", "FuelType" },
                values: new object[,]
                {
                    { Vehicle1Id, SeedUserId, "Daily Driver - Civic", "Honda", "Civic", 2018, "Gasoline" },
                    { Vehicle2Id, SeedUserId, "Family SUV - RAV4",  "Toyota", "RAV4",  2022, "Hybrid"    },
                    { Vehicle3Id, SeedUserId, "Work Truck - F-150",  "Ford",   "F-150", 2016, "Diesel"    },
                }
            );

            // Seed fuel entries
            migrationBuilder.InsertData(
                table: "FuelEntries",
                columns: new[]
                {
                    "Id","UserId","VehicleId","Date","OdometerKm","VolumeL","TotalCost","Station","Brand","Grade","Notes"
                },
                values: new object[,]
                {
                    // Civic
                    { FuelEntry1Id, SeedUserId, Vehicle1Id, new DateTime(2025, 01, 05, 12, 00, 00, DateTimeKind.Utc), 15234.5, 42.3,  65.40m, "Main St Station", "Shell",    "Regular", "City driving" },
                    { FuelEntry2Id, SeedUserId, Vehicle1Id, new DateTime(2025, 02, 10, 12, 00, 00, DateTimeKind.Utc), 15678.2, 40.1,  62.10m, "Broadway Fuel",  "BP",       "Regular", "Mixed driving" },
                    { FuelEntry3Id, SeedUserId, Vehicle1Id, new DateTime(2025, 03, 12, 12, 00, 00, DateTimeKind.Utc), 16105.9, 43.0,  67.75m, "Lakeside Gas",   "Chevron",  "Regular", "Highway trip" },

                    // RAV4
                    { FuelEntry4Id, SeedUserId, Vehicle2Id, new DateTime(2025, 01, 15, 09, 30, 00, DateTimeKind.Utc),  8250.0, 32.5,  54.90m, "North End",      "Costco",   "Regular", "Hybrid efficiency" },
                    { FuelEntry5Id, SeedUserId, Vehicle2Id, new DateTime(2025, 02, 16, 10, 15, 00, DateTimeKind.Utc),  8675.4, 31.8,  52.35m, "Parkway Fuel",   "Shell",    "Regular", "School runs" },
                    { FuelEntry6Id, SeedUserId, Vehicle2Id, new DateTime(2025, 03, 18, 11, 45, 00, DateTimeKind.Utc),  9059.7, 33.2,  56.10m, "Express Mart",   "Exxon",    "Regular", "Weekend trip" },

                    // F-150
                    { FuelEntry7Id, SeedUserId, Vehicle3Id, new DateTime(2025, 01, 20, 08, 00, 00, DateTimeKind.Utc), 45210.3, 70.0, 120.00m, "Highway Plaza",  "Shell",    "Diesel",  "Towing trailer" },
                    { FuelEntry8Id, SeedUserId, Vehicle3Id, new DateTime(2025, 02, 22, 08, 30, 00, DateTimeKind.Utc), 45895.8, 68.7, 118.25m, "Depot Station",  "BP",       "Diesel",  "Work commute" },
                    { FuelEntry9Id, SeedUserId, Vehicle3Id, new DateTime(2025, 03, 25, 07, 50, 00, DateTimeKind.Utc), 46520.1, 72.3, 124.90m, "Westside Fuel",  "Chevron",  "Diesel",  "Loaded haul" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove fuel entries
            migrationBuilder.DeleteData(table: "FuelEntries", keyColumn: "Id", keyValue: FuelEntry1Id);
            migrationBuilder.DeleteData(table: "FuelEntries", keyColumn: "Id", keyValue: FuelEntry2Id);
            migrationBuilder.DeleteData(table: "FuelEntries", keyColumn: "Id", keyValue: FuelEntry3Id);
            migrationBuilder.DeleteData(table: "FuelEntries", keyColumn: "Id", keyValue: FuelEntry4Id);
            migrationBuilder.DeleteData(table: "FuelEntries", keyColumn: "Id", keyValue: FuelEntry5Id);
            migrationBuilder.DeleteData(table: "FuelEntries", keyColumn: "Id", keyValue: FuelEntry6Id);
            migrationBuilder.DeleteData(table: "FuelEntries", keyColumn: "Id", keyValue: FuelEntry7Id);
            migrationBuilder.DeleteData(table: "FuelEntries", keyColumn: "Id", keyValue: FuelEntry8Id);
            migrationBuilder.DeleteData(table: "FuelEntries", keyColumn: "Id", keyValue: FuelEntry9Id);

            // Remove vehicles
            migrationBuilder.DeleteData(table: "Vehicles", keyColumn: "Id", keyValue: Vehicle1Id);
            migrationBuilder.DeleteData(table: "Vehicles", keyColumn: "Id", keyValue: Vehicle2Id);
            migrationBuilder.DeleteData(table: "Vehicles", keyColumn: "Id", keyValue: Vehicle3Id);
        }
    }
}
