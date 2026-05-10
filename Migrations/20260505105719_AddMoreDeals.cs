using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodHeaven.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreDeals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Deals",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "IsActive", "OriginalPrice", "Price", "Tag", "Title" },
                values: new object[,]
                {
                    { 4, new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(2207), "Mixed grill selection, 4 pieces of Seekh Kabab, 4 Tikka pieces, and 2 Garlic Naans.", "https://images.unsplash.com/photo-1544025162-d76694265947?w=800&q=80", true, 45.00m, 34.99m, "Hot Seller", "BBQ Lovers Platter" },
                    { 5, new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(2211), "Grilled Salmon, Golden Calamari, and Prawn Cocktail with a side of herb butter rice.", "https://images.unsplash.com/photo-1519708227418-c8fd9a32b7a2?w=800&q=80", true, 65.00m, 49.99m, "Premium", "Seafood Extravaganza" },
                    { 6, new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(2214), "2 Continental Breakfast platters, 2 Iced Coffees, and 1 Dessert sampler.", "https://images.unsplash.com/photo-1533089860892-a7c6f0a88666?w=800&q=80", true, 52.00m, 39.99m, "Weekend Only", "Weekend Brunch for Two" },
                    { 7, new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(2218), "Choose any 3 Pasta dishes and get a large Garlic Bread Supreme for free.", "https://images.unsplash.com/photo-1473093226795-af9932fe5856?w=800&q=80", true, 55.00m, 42.00m, "Value Deal", "Pasta Party Bundle" },
                    { 8, new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(2222), "3 Classic Cheeseburgers, 3 Masala Fries, and 3 Coca Cola drinks.", "https://images.unsplash.com/photo-1561758033-d89a9ad46330?w=800&q=80", true, 38.00m, 29.99m, "Fast & Tasty", "Burger Madness" },
                    { 9, new DateTime(2026, 5, 5, 15, 57, 18, 103, DateTimeKind.Local).AddTicks(2226), "Molten Lava Cake, Triple Chocolate Cake, and 2 Vanilla Bean Ice Cream scoops.", "https://images.unsplash.com/photo-1551024601-bec78aea704b?w=800&q=80", true, 28.50m, 22.00m, "Dessert King", "Sweet Tooth Combo" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(8384));

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(7987));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(8003));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(8006));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(8013));
        }
    }
}
