using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceProject.Migrations
{
    /// <inheritdoc />
    public partial class ProductModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 1, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 2, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 3, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 4, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 5, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 6, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 7, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 8, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 9, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 10, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 11, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 12, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 13, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 14, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 15, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 16, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 17, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 18, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "finalPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "slug",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5482176B-6706-476D-A273-1EA9AD5AD217",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 624, DateTimeKind.Utc).AddTicks(704), new DateTime(2024, 12, 30, 14, 3, 13, 624, DateTimeKind.Utc).AddTicks(704) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B993F718-51B6-4FBE-9F17-037FA1585827",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 624, DateTimeKind.Utc).AddTicks(698), new DateTime(2024, 12, 30, 14, 3, 13, 624, DateTimeKind.Utc).AddTicks(698) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C0CF4D0F-9BC6-4B70-BAED-2CA10F1AAA30",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 624, DateTimeKind.Utc).AddTicks(701), new DateTime(2024, 12, 30, 14, 3, 13, 624, DateTimeKind.Utc).AddTicks(701) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "RoleId", "SecurityStamp", "Slug", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "ecc0548c-b9fe-429f-af0b-8b7aafd10138", 0, "c4bb190a-0d01-4e71-a353-ce8be06dda4f", new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4022), "mahitoshgiri287@gmail.com", true, false, null, null, null, "AQAAAAIAAYagAAAAEBRROp0pdSdUbGsU5a1vneMvuveDHPL96V929WBVBNPPaNj/JSBT/KN5mWX57V10Mg==", null, false, "SomeDummyTokenValue3543564", null, "B993F718-51B6-4FBE-9F17-037FA1585827", "b7d927e2-4617-49da-8447-b2cf424d9efb", "admin-user", false, new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4029), "adminUser" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4163), new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4164) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4173), new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4173) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4175), new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4175) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4176), new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4177) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4178), new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4178) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4192), new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4192) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4195), new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4195) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4196), new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4197) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4198), new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4198) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4200), new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4201) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4202), new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4203) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4204), new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4204) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4205), new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4206) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4207), new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4207) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4208), new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4210), new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4210) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4212), new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4212) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4214), new DateTime(2024, 12, 30, 14, 3, 13, 701, DateTimeKind.Utc).AddTicks(4215) });

            migrationBuilder.InsertData(
                table: "UserPermissions",
                columns: new[] { "PermissionId", "UserId" },
                values: new object[,]
                {
                    { 1, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" },
                    { 2, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" },
                    { 3, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" },
                    { 4, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" },
                    { 5, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" },
                    { 6, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" },
                    { 7, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" },
                    { 8, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" },
                    { 9, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" },
                    { 10, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" },
                    { 11, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" },
                    { 12, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" },
                    { 13, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" },
                    { 14, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" },
                    { 15, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" },
                    { 16, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" },
                    { 17, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" },
                    { 18, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 1, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 2, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 3, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 4, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 5, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 6, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 7, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 8, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 9, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 10, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 11, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 12, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 13, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 14, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 15, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 16, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 17, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 18, "ecc0548c-b9fe-429f-af0b-8b7aafd10138" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ecc0548c-b9fe-429f-af0b-8b7aafd10138");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "finalPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "slug",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5482176B-6706-476D-A273-1EA9AD5AD217",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 8, 913, DateTimeKind.Utc).AddTicks(4487), new DateTime(2024, 12, 29, 15, 2, 8, 913, DateTimeKind.Utc).AddTicks(4488) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B993F718-51B6-4FBE-9F17-037FA1585827",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 8, 913, DateTimeKind.Utc).AddTicks(4467), new DateTime(2024, 12, 29, 15, 2, 8, 913, DateTimeKind.Utc).AddTicks(4469) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C0CF4D0F-9BC6-4B70-BAED-2CA10F1AAA30",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 8, 913, DateTimeKind.Utc).AddTicks(4478), new DateTime(2024, 12, 29, 15, 2, 8, 913, DateTimeKind.Utc).AddTicks(4479) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "RoleId", "SecurityStamp", "Slug", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45", 0, "38a9d2ce-b568-4574-a675-9dca224953ba", new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3590), "mahitoshgiri287@gmail.com", true, false, null, null, null, "AQAAAAIAAYagAAAAECSTyLdRjAYnMQB9UJQ2/upUVKc0GZ+uQiURAfF6SGvhENXJ7Coa9OVwgwR/r6v0tg==", null, false, "SomeDummyTokenValue3543564", null, "B993F718-51B6-4FBE-9F17-037FA1585827", "433760df-e061-44dd-a81c-bd499270fe16", "admin-user", false, new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3598), "adminUser" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3968), new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3970) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3984), new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3985) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3988), new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3989) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3992), new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3992) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3995), new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3996) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4013), new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4013) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4016), new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4017) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4020), new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4023), new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4023) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4028), new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4029) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4032), new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4033) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4035), new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4036) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4039), new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4039) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4391), new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4421) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4424), new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4425) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4427), new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4428) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4430), new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4431) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4438), new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4439) });

            migrationBuilder.InsertData(
                table: "UserPermissions",
                columns: new[] { "PermissionId", "UserId" },
                values: new object[,]
                {
                    { 1, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" },
                    { 2, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" },
                    { 3, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" },
                    { 4, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" },
                    { 5, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" },
                    { 6, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" },
                    { 7, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" },
                    { 8, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" },
                    { 9, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" },
                    { 10, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" },
                    { 11, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" },
                    { 12, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" },
                    { 13, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" },
                    { 14, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" },
                    { 15, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" },
                    { 16, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" },
                    { 17, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" },
                    { 18, "c6fda8d7-acc0-4bff-bd21-3c2c1000cc45" }
                });
        }
    }
}
