using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHeaven.Migrations
{
    /// <inheritdoc />
    public partial class AddPremiumFieldsFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "EstimatedCost",
                table: "Reservations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsPremiumTable",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 16, 19, 6, 12, 748, DateTimeKind.Local).AddTicks(8038), "$2a$11$u5uEe3sVoX5v/b07GpQaL.23yGkPSgL9EcEqvR2cQ7szYzPzY.9kO" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 16, 19, 6, 12, 530, DateTimeKind.Local).AddTicks(3207));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 16, 19, 6, 12, 530, DateTimeKind.Local).AddTicks(3224));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 16, 19, 6, 12, 530, DateTimeKind.Local).AddTicks(3227));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 16, 19, 6, 12, 530, DateTimeKind.Local).AddTicks(3229));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 16, 19, 6, 12, 530, DateTimeKind.Local).AddTicks(3231));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 16, 19, 6, 12, 530, DateTimeKind.Local).AddTicks(3233));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 16, 19, 6, 12, 530, DateTimeKind.Local).AddTicks(3235));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 16, 19, 6, 12, 530, DateTimeKind.Local).AddTicks(3237));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 16, 19, 6, 12, 530, DateTimeKind.Local).AddTicks(3238));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedCost",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "IsPremiumTable",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 16, 16, 10, 15, 746, DateTimeKind.Local).AddTicks(7485), "$2a$11$s6lmBG4UgUB1DJFhttmfNe7dyAUB1s1khkBJRES5lQV/nZyu0MTPq" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 16, 16, 10, 15, 499, DateTimeKind.Local).AddTicks(7319));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 16, 16, 10, 15, 499, DateTimeKind.Local).AddTicks(7336));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 16, 16, 10, 15, 499, DateTimeKind.Local).AddTicks(7339));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 16, 16, 10, 15, 499, DateTimeKind.Local).AddTicks(7341));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 16, 16, 10, 15, 499, DateTimeKind.Local).AddTicks(7343));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 16, 16, 10, 15, 499, DateTimeKind.Local).AddTicks(7345));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 16, 16, 10, 15, 499, DateTimeKind.Local).AddTicks(7347));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 16, 16, 10, 15, 499, DateTimeKind.Local).AddTicks(7349));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 16, 16, 10, 15, 499, DateTimeKind.Local).AddTicks(7351));
        }
    }
}
