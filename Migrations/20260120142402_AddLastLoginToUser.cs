using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHeaven.Migrations
{
    /// <inheritdoc />
    public partial class AddLastLoginToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 20, 19, 24, 1, 629, DateTimeKind.Local).AddTicks(6640), "$2a$11$kTsbZMbK5VwY1pz1uieYO.CHmSpAhnKzBluz2C5vs4aosKXxnYkKe" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 19, 24, 1, 432, DateTimeKind.Local).AddTicks(1218));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 19, 24, 1, 432, DateTimeKind.Local).AddTicks(1240));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 19, 24, 1, 432, DateTimeKind.Local).AddTicks(1244));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 19, 24, 1, 432, DateTimeKind.Local).AddTicks(1247));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 19, 24, 1, 432, DateTimeKind.Local).AddTicks(1250));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 19, 24, 1, 432, DateTimeKind.Local).AddTicks(1252));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 19, 24, 1, 432, DateTimeKind.Local).AddTicks(1254));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 19, 24, 1, 432, DateTimeKind.Local).AddTicks(1256));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 19, 24, 1, 432, DateTimeKind.Local).AddTicks(1258));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLoginAt",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 20, 16, 13, 20, 306, DateTimeKind.Local).AddTicks(2485), "$2a$11$V4Kqzi6qwWoolduBN/LunuRw0W2oHvWbxF6TognuR3bKDpdab6alG" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 13, 20, 118, DateTimeKind.Local).AddTicks(8896));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 13, 20, 118, DateTimeKind.Local).AddTicks(8917));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 13, 20, 118, DateTimeKind.Local).AddTicks(9145));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 13, 20, 118, DateTimeKind.Local).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 13, 20, 118, DateTimeKind.Local).AddTicks(9152));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 13, 20, 118, DateTimeKind.Local).AddTicks(9155));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 13, 20, 118, DateTimeKind.Local).AddTicks(9158));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 13, 20, 118, DateTimeKind.Local).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 13, 20, 118, DateTimeKind.Local).AddTicks(9165));
        }
    }
}
