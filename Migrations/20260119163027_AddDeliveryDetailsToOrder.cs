using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHeaven.Migrations
{
    /// <inheritdoc />
    public partial class AddDeliveryDetailsToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 19, 21, 30, 26, 499, DateTimeKind.Local).AddTicks(5827), "$2a$11$gGVjOrhUL2K/5lbG/94PluhG5JpRgrzNwEewQDuNdCFZxIxSU.H4." });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 21, 30, 26, 348, DateTimeKind.Local).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 21, 30, 26, 348, DateTimeKind.Local).AddTicks(9441));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 21, 30, 26, 348, DateTimeKind.Local).AddTicks(9444));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 21, 30, 26, 348, DateTimeKind.Local).AddTicks(9446));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 21, 30, 26, 348, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 21, 30, 26, 348, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 21, 30, 26, 348, DateTimeKind.Local).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 21, 30, 26, 348, DateTimeKind.Local).AddTicks(9497));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 21, 30, 26, 348, DateTimeKind.Local).AddTicks(9499));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 18, 2, 0, 19, 992, DateTimeKind.Local).AddTicks(9163), "$2a$11$1tg6Ps6OgOKiwsM4RuKIy.DgPos5GzDjpG7eKPpNI4IyYXA8E4GZO" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 18, 2, 0, 19, 676, DateTimeKind.Local).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 18, 2, 0, 19, 676, DateTimeKind.Local).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 18, 2, 0, 19, 676, DateTimeKind.Local).AddTicks(7574));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 18, 2, 0, 19, 676, DateTimeKind.Local).AddTicks(7579));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 18, 2, 0, 19, 676, DateTimeKind.Local).AddTicks(7583));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 18, 2, 0, 19, 676, DateTimeKind.Local).AddTicks(7588));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 18, 2, 0, 19, 676, DateTimeKind.Local).AddTicks(7765));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 18, 2, 0, 19, 676, DateTimeKind.Local).AddTicks(7891));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 18, 2, 0, 19, 676, DateTimeKind.Local).AddTicks(7899));
        }
    }
}
