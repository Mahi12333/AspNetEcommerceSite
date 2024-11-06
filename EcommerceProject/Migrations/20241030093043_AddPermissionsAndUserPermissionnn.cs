using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceProject.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionsAndUserPermissionnn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9def8c5-2498-487d-a5af-6e18f01faf6b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5482176B-6706-476D-A273-1EA9AD5AD217",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 9, 30, 42, 708, DateTimeKind.Utc).AddTicks(9292), new DateTime(2024, 10, 30, 9, 30, 42, 708, DateTimeKind.Utc).AddTicks(9292) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B993F718-51B6-4FBE-9F17-037FA1585827",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 9, 30, 42, 708, DateTimeKind.Utc).AddTicks(9282), new DateTime(2024, 10, 30, 9, 30, 42, 708, DateTimeKind.Utc).AddTicks(9283) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C0CF4D0F-9BC6-4B70-BAED-2CA10F1AAA30",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 9, 30, 42, 708, DateTimeKind.Utc).AddTicks(9287), new DateTime(2024, 10, 30, 9, 30, 42, 708, DateTimeKind.Utc).AddTicks(9287) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "Slug", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612", 0, "e23d1a45-fc62-45d8-842a-ab25a1b58047", new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5582), "admin@example.com", true, false, null, null, null, "AQAAAAIAAYagAAAAEDNSX6o8n4LasUdtYw/pSU4Dj6WzL53kEBTrw0JWUg2BepsQxRg/UhCCTV52jI9FaQ==", null, false, "B993F718-51B6-4FBE-9F17-037FA1585827", "87283a0e-49a5-45a1-b99b-9f7788384ba5", "admin-user", false, new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5589), "adminUser" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5711), new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5711) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5717), new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5718) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5719), new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5719) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5720), new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5720) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5721), new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5721) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5737), new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5737) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5738), new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5738) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5739), new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5739) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5740), new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5741) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5742), new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5743) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5743), new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5744) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5745), new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5745) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5746), new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5746) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5747), new DateTime(2024, 10, 30, 9, 30, 42, 769, DateTimeKind.Utc).AddTicks(5747) });

            migrationBuilder.InsertData(
                table: "UserPermissions",
                columns: new[] { "PermissionId", "UserId" },
                values: new object[,]
                {
                    { 1, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" },
                    { 2, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" },
                    { 3, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" },
                    { 4, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" },
                    { 5, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" },
                    { 6, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" },
                    { 7, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" },
                    { 8, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" },
                    { 9, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" },
                    { 10, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" },
                    { 11, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" },
                    { 12, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" },
                    { 13, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" },
                    { 14, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 1, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 2, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 3, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 4, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 5, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 6, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 7, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 8, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 9, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 10, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 11, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 12, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 13, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 14, "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc2ad2c5-7532-40e3-9af8-f19fb8e3f612");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5482176B-6706-476D-A273-1EA9AD5AD217",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 27, 19, 18, 58, 211, DateTimeKind.Utc).AddTicks(1622), new DateTime(2024, 10, 27, 19, 18, 58, 211, DateTimeKind.Utc).AddTicks(1623) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B993F718-51B6-4FBE-9F17-037FA1585827",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 27, 19, 18, 58, 211, DateTimeKind.Utc).AddTicks(1602), new DateTime(2024, 10, 27, 19, 18, 58, 211, DateTimeKind.Utc).AddTicks(1604) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C0CF4D0F-9BC6-4B70-BAED-2CA10F1AAA30",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 27, 19, 18, 58, 211, DateTimeKind.Utc).AddTicks(1613), new DateTime(2024, 10, 27, 19, 18, 58, 211, DateTimeKind.Utc).AddTicks(1614) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "Slug", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "a9def8c5-2498-487d-a5af-6e18f01faf6b", 0, "e11bfe26-1c25-4be9-8abb-d544d798d923", new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(5533), "admin@example.com", true, false, null, null, null, "AQAAAAIAAYagAAAAEPUo5gPyluF+hWIQMdOhFAu4R9yNm8FoM9zNfTtGROxpNMO4KsuD8+m2J2VeNdZxiA==", null, false, "B993F718-51B6-4FBE-9F17-037FA1585827", "c5f87886-8623-4733-ab7f-4d46a16c5236", "admin-user", false, new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(5537), "adminUser" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6146), new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6147) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6154), new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6155) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6157), new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6157) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6159), new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6160) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6162), new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6163) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6165), new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6165) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6167), new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6168) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6170), new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6170) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6172), new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6173) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6175), new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6176) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6177), new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6178) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6180), new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6181) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6182), new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6183) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6185), new DateTime(2024, 10, 27, 19, 18, 58, 345, DateTimeKind.Utc).AddTicks(6201) });
        }
    }
}
