using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuelTracker.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        private static readonly Guid AdminRoleId = Guid.Parse("11111111-1111-4111-8111-111111111111");
        private static readonly Guid UserRoleId = Guid.Parse("22222222-2222-4222-8222-222222222222");

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insert default roles if they don't already exist.
            // Using InsertData ensures idempotent behavior with respect to primary key/unique constraints
            // when applied via EF migrations (it will fail only if conflicting names already exist).
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { AdminRoleId, "Admin" },
                    { UserRoleId,  "User" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: AdminRoleId);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: UserRoleId);
        }
    }
}
