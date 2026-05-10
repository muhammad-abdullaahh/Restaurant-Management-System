using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodHeaven.Migrations
{
    /// <inheritdoc />
    public partial class AddDesiAndPizzaDeals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(3143));

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(3149));

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(3152));

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(3154));

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(3156));

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(3158));

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(3161));

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(3163));

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(3165));

            migrationBuilder.InsertData(
                table: "Deals",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "IsActive", "OriginalPrice", "Price", "Tag", "Title" },
                values: new object[,]
                {
                    { 10, new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(3167), "Chicken Biryani (Full), Mutton Karahi (Half), 4 Roti/Naan, and a bottle of Coke (1.5L).", "https://images.unsplash.com/photo-1517244683847-7456b63c5969?w=800&q=80", true, 68.00m, 54.99m, "Desi Special", "Desi Royal Feast" },
                    { 11, new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(3169), "2 Large Pizzas of your choice, 1 portion of Chicken Wings (10pcs), and 1 large Salad bowl.", "https://images.unsplash.com/photo-1513104890138-7c749659a591?w=800&q=80", true, 58.50m, 44.99m, "Party Time", "Pizza Party Pack" }
                });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(2907));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(2926));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(2929));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(2931));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(2933));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(2974));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(2978));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 16, 2, 50, 847, DateTimeKind.Local).AddTicks(2983));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(2207));

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(2211));

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(2214));

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(2218));

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(2222));

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(2226));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(1906));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(1910));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(1917));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(1923));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(1926));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(1929));
        }
    }
}
