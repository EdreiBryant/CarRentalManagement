using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalManagement.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultDataAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", null, "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "89d75e9a-8b50-4134-8bc3-0a5ca13a4344", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAECObAYDSjqr6H/p3t6h+P5mz5Q0lAOoEV7s5Y+Qr9pYkNj+rZLORG0XF137ni8kwCQ==", null, false, "af572764-7c11-49f0-8d9d-8b9ff3d03e18", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 11, 28, 10, 48, 6, 402, DateTimeKind.Local).AddTicks(3160), new DateTime(2023, 11, 28, 10, 48, 6, 402, DateTimeKind.Local).AddTicks(3171), "Black", "System" },
                    { 2, "System", new DateTime(2023, 11, 28, 10, 48, 6, 402, DateTimeKind.Local).AddTicks(3172), new DateTime(2023, 11, 28, 10, 48, 6, 402, DateTimeKind.Local).AddTicks(3173), "Blue", "System" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 11, 28, 10, 48, 6, 402, DateTimeKind.Local).AddTicks(3569), new DateTime(2023, 11, 28, 10, 48, 6, 402, DateTimeKind.Local).AddTicks(3569), "BMW", "System" },
                    { 2, "System", new DateTime(2023, 11, 28, 10, 48, 6, 402, DateTimeKind.Local).AddTicks(3571), new DateTime(2023, 11, 28, 10, 48, 6, 402, DateTimeKind.Local).AddTicks(3572), "Toyota", "System" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 11, 28, 10, 48, 6, 402, DateTimeKind.Local).AddTicks(3734), new DateTime(2023, 11, 28, 10, 48, 6, 402, DateTimeKind.Local).AddTicks(3735), "3 Series", "System" },
                    { 2, "System", new DateTime(2023, 11, 28, 10, 48, 6, 402, DateTimeKind.Local).AddTicks(3736), new DateTime(2023, 11, 28, 10, 48, 6, 402, DateTimeKind.Local).AddTicks(3736), "X5", "System" },
                    { 3, "System", new DateTime(2023, 11, 28, 10, 48, 6, 402, DateTimeKind.Local).AddTicks(3737), new DateTime(2023, 11, 28, 10, 48, 6, 402, DateTimeKind.Local).AddTicks(3738), "Prius", "System" },
                    { 4, "System", new DateTime(2023, 11, 28, 10, 48, 6, 402, DateTimeKind.Local).AddTicks(3739), new DateTime(2023, 11, 28, 10, 48, 6, 402, DateTimeKind.Local).AddTicks(3739), "Rav4", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");
        }
    }
}
