using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceProject.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionsAndUserPermissionssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c323777-d891-420e-800a-035cb7562889");

            migrationBuilder.AlterColumn<int>(
                name: "PermissionId",
                table: "UserPermissions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserPermissions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9def8c5-2498-487d-a5af-6e18f01faf6b");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "PermissionId",
                table: "UserPermissions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserPermissions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 0);

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

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7132), new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7133) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7139), new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7139) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7140), new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7140) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7141), new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7141) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7142), new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7142) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7143), new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7144) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7145), new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7146) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7146), new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7147) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7148), new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7148) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7149), new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7149) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7150), new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7151), new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7151) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7152), new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7152) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7153), new DateTime(2024, 10, 26, 14, 37, 35, 362, DateTimeKind.Utc).AddTicks(7154) });
        }
    }
}
