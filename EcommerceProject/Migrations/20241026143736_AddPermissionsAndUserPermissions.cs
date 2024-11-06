using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceProject.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionsAndUserPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0750196e-10d3-4b13-bc11-a6856c557d52");

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => new { x.UserId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_UserPermissions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5482176B-6706-476D-A273-1EA9AD5AD217",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 26, 14, 37, 35, 302, DateTimeKind.Utc).AddTicks(3461), new DateTime(2024, 10, 26, 14, 37, 35, 302, DateTimeKind.Utc).AddTicks(3461) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B993F718-51B6-4FBE-9F17-037FA1585827",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 26, 14, 37, 35, 302, DateTimeKind.Utc).AddTicks(3454), new DateTime(2024, 10, 26, 14, 37, 35, 302, DateTimeKind.Utc).AddTicks(3455) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C0CF4D0F-9BC6-4B70-BAED-2CA10F1AAA30",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 26, 14, 37, 35, 302, DateTimeKind.Utc).AddTicks(3458), new DateTime(2024, 10, 26, 14, 37, 35, 302, DateTimeKind.Utc).AddTicks(3458) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Slug", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "3c323777-d891-420e-800a-035cb7562889", 0, "5ec7f727-913b-440a-b8bd-83d03db4adab", new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(6797), "mahitoshgiri287@gmail.com", true, false, null, null, null, "AQAAAAIAAYagAAAAEH6GsYkUUiSBY+t8Sf8DTu9/2CR3Wkai+sZzG8vajg4rPdKrR9a1JpnwYcXOFlEJ2w==", null, false, "8db8d7a6-25c4-4e61-90e2-a4d5405e88b4", "admin-user", false, new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(6800), "adminUser" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "PermissionName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7132), "Create Product", new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7133) },
                    { 2, new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7139), "Edit Product", new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7139) },
                    { 3, new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7140), "Delete Product", new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7140) },
                    { 4, new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7141), "View Orders", new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7141) },
                    { 5, new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7142), "Manage Users", new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7142) },
                    { 6, new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7143), "Access Admin Dashboard", new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7144) },
                    { 7, new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7145), "Edit User", new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7146) },
                    { 8, new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7146), "Delete User", new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7147) },
                    { 9, new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7148), "Create Category", new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7148) },
                    { 10, new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7149), "Edit Category", new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7149) },
                    { 11, new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7150), "Delete Category", new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7150) },
                    { 12, new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7151), "Create Subcategory", new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7151) },
                    { 13, new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7152), "Edit Subcategory", new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7152) },
                    { 14, new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7153), "Delete Subcategory", new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7154) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_PermissionId",
                table: "UserPermissions",
                column: "PermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c323777-d891-420e-800a-035cb7562889");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5482176B-6706-476D-A273-1EA9AD5AD217",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 20, 7, 30, 529, DateTimeKind.Utc).AddTicks(8901), new DateTime(2024, 10, 21, 20, 7, 30, 529, DateTimeKind.Utc).AddTicks(8902) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B993F718-51B6-4FBE-9F17-037FA1585827",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 20, 7, 30, 529, DateTimeKind.Utc).AddTicks(8882), new DateTime(2024, 10, 21, 20, 7, 30, 529, DateTimeKind.Utc).AddTicks(8884) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C0CF4D0F-9BC6-4B70-BAED-2CA10F1AAA30",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 21, 20, 7, 30, 529, DateTimeKind.Utc).AddTicks(8892), new DateTime(2024, 10, 21, 20, 7, 30, 529, DateTimeKind.Utc).AddTicks(8893) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Slug", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "0750196e-10d3-4b13-bc11-a6856c557d52", 0, "03cee5a6-af0b-4aad-8df8-deb10378b97e", new DateTime(2024, 10, 21, 20, 7, 30, 701, DateTimeKind.Utc).AddTicks(7493), "admin@example.com", true, false, null, null, null, "AQAAAAIAAYagAAAAEFm4pb5Xhe8GnGGD6+D498H84coF/1UA+m18tzrSFxObbtDVlwyGyM6cVOdz4IC0bw==", null, false, "374ec2a9-c6f5-4e20-ae48-8b9bf9a1089a", "admin-user", false, new DateTime(2024, 10, 21, 20, 7, 30, 701, DateTimeKind.Utc).AddTicks(7499), "adminUser" });
        }
    }
}
