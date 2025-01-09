using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceProject.Migrations
{
    /// <inheritdoc />
    public partial class ImageModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 1, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 2, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 3, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 4, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 5, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 6, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 7, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 8, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 9, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 10, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 11, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 12, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 13, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" });

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumns: new[] { "PermissionId", "UserId" },
                keyValues: new object[] { 14, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a19a84f-b911-48bf-bc90-ff7a0d972e22");

            migrationBuilder.DropColumn(
                name: "ImageUrls",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    filename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "CreatedAt", "PermissionName", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3995), "View User", new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(3996) });

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

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "PermissionName", "UpdatedAt" },
                values: new object[,]
                {
                    { 15, new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4424), "Create User", new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4425) },
                    { 16, new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4427), "View Category", new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4428) },
                    { 17, new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4430), "View Subcategory", new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4431) },
                    { 18, new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4438), "View Product", new DateTime(2024, 12, 29, 15, 2, 9, 95, DateTimeKind.Utc).AddTicks(4439) }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

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

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrls",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5482176B-6706-476D-A273-1EA9AD5AD217",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 11, 19, 36, 51, 942, DateTimeKind.Utc).AddTicks(8246), new DateTime(2024, 12, 11, 19, 36, 51, 942, DateTimeKind.Utc).AddTicks(8246) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B993F718-51B6-4FBE-9F17-037FA1585827",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 11, 19, 36, 51, 942, DateTimeKind.Utc).AddTicks(8231), new DateTime(2024, 12, 11, 19, 36, 51, 942, DateTimeKind.Utc).AddTicks(8232) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C0CF4D0F-9BC6-4B70-BAED-2CA10F1AAA30",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 11, 19, 36, 51, 942, DateTimeKind.Utc).AddTicks(8238), new DateTime(2024, 12, 11, 19, 36, 51, 942, DateTimeKind.Utc).AddTicks(8239) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "RoleId", "SecurityStamp", "Slug", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "9a19a84f-b911-48bf-bc90-ff7a0d972e22", 0, "36f52ced-2f3b-4ca0-864e-792a4abbca76", new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(2874), "mahitoshgiri287@gmail.com", true, false, null, null, null, "AQAAAAIAAYagAAAAEBjwEyQqUqdn+8ype+mjQSG1gXm+RElU67JjfRNrSJskBUsyZ+wy0lBZt8Nce2Zx/Q==", null, false, "SomeDummyTokenValue3543564", null, "B993F718-51B6-4FBE-9F17-037FA1585827", "0811918d-bbf4-4268-b61e-4f2645459aaa", "admin-user", false, new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(2879), "adminUser" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3055), new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3056) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3066), new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3067) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3070), new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3071) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3074), new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3075) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PermissionName", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3077), "Manage Users", new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3078) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3098), new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3099) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3101), new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3102) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3192), new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3193) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3196), new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3197) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3203), new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3204) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3206), new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3207) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3210), new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3211) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3213), new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3214) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3217), new DateTime(2024, 12, 11, 19, 36, 52, 119, DateTimeKind.Utc).AddTicks(3218) });

            migrationBuilder.InsertData(
                table: "UserPermissions",
                columns: new[] { "PermissionId", "UserId" },
                values: new object[,]
                {
                    { 1, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" },
                    { 2, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" },
                    { 3, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" },
                    { 4, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" },
                    { 5, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" },
                    { 6, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" },
                    { 7, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" },
                    { 8, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" },
                    { 9, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" },
                    { 10, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" },
                    { 11, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" },
                    { 12, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" },
                    { 13, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" },
                    { 14, "9a19a84f-b911-48bf-bc90-ff7a0d972e22" }
                });
        }
    }
}
