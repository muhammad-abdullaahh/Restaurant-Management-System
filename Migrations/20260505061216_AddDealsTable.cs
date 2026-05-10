using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodHeaven.Migrations
{
    /// <inheritdoc />
    public partial class AddDealsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Deals",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "IsActive", "OriginalPrice", "Price", "Tag", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(8370), "2 Royal Wagyu Burgers, 2 Spicy Thai Basil Pastas, and 4 Berry Smoothies.", "https://images.unsplash.com/photo-1555939594-58d7cb561ad1?w=800&q=80", true, 82.00m, 59.99m, "Family Choice", "Family Feast Bundle" },
                    { 2, new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(8384), "2 Truffle Risottos, 1 bottle of sparkling juice, and Fluffy Pancakes for two.", "https://images.unsplash.com/photo-1543007630-9710e4a00a20?w=800&q=80", true, 61.50m, 45.00m, "Popular", "Date Night Special" },
                    { 3, new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(8390), "Creamy Avocado Toast paired with a giant Berry Smoothie.", "https://images.unsplash.com/photo-1525351484163-7529414344d8?w=800&q=80", true, 21.50m, 18.00m, "Chef Special", "Healthy Morning Kick" }
                });

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
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(7987), "/images/platter_seafood.jpg" });

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
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(7999), "/images/platter_italian.jpg" });

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
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(8006), "/images/berry_smoothie.jpg" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(8010), "/images/platter_health.jpg" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 5, 11, 12, 15, 552, DateTimeKind.Local).AddTicks(8013));


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deals");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 23, 20, 42, 47, 899, DateTimeKind.Local).AddTicks(3692));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 1, 23, 20, 42, 47, 899, DateTimeKind.Local).AddTicks(3712), "https://lh3.googleusercontent.com/aida-public/AB6AXuDNrvAofLcEQx3a1ZXD2766HUT65ZwhGPi1k1AXhl64HEavGi8nxRyffeK2LQ1oxPd2l434Oa94YXAZT12CMqKjQTBF2Jb-8E5dAceM7FJUcelHF-6c4q15awtGEgO3PLu8mQM5UI5IuBTsZxo8YpUNEtR4k4Z2U6u_W2XctSp_0D7ecrWJK422mSw0xZv6oUUGBnX3XTr0Y3po6FEJ-BVMbMMnqK4FYYNU0u4RQkSQXKzN3eFrWYD2bhYIjwKQERuzO1vUb6O07Q" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 23, 20, 42, 47, 899, DateTimeKind.Local).AddTicks(3715));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 23, 20, 42, 47, 899, DateTimeKind.Local).AddTicks(3716));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 1, 23, 20, 42, 47, 899, DateTimeKind.Local).AddTicks(3719), "https://lh3.googleusercontent.com/aida-public/AB6AXuDfWitYE4hwDczx9Z-VIscp8kFY3t1c7tJueP_sW0XkR6EW2YM0vC1M4_LrFzbnykXuUg7lmcsy1nz-rL4x03gJfzB9iXMzCFJtTORYym8uJDHJbCoEygHqUJcYT59qBjkpnS3np4Zwu_KX8k8v1wrgeaTcao1EbDmNjz-ij4cjZFHcM-yo-cJIeTFaj2BOvoxkNCp5lu566DDOVAcqyZHIolGrMV4W-f9hRXH5a9eBfPjt2axi-Nvk3uFpAfFKy36vLmF4e1HOPQ" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 23, 20, 42, 47, 899, DateTimeKind.Local).AddTicks(3721));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 1, 23, 20, 42, 47, 899, DateTimeKind.Local).AddTicks(3723), "https://lh3.googleusercontent.com/aida-public/AB6AXuB6wcyAKmNM9_xGQUed-hjbJioT5oPF1lfh6_YbyCXMg1W1ZmaCd888UKjOvluITeTAyZPMtsQLFPWIjDmcTA5L7-RIWceRR39xPbsEcpOodl0BlxDfLK7a83dW2hL-Qx5i1NIThF5cd7UWbJ-VPAHuHxYYpDg4vf7OvTOKGaOFEve1TWfFYLyjCXLKVbvORWtJXkb9sNMimTocvC86q0GPyCW192ZYAIMFQGCWGruiREfd_yXW2Sd6Szt5uHjg3W8cNgX14E-L_A" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 1, 23, 20, 42, 47, 899, DateTimeKind.Local).AddTicks(3725), "https://lh3.googleusercontent.com/aida-public/AB6AXuAOWTa96d3PDsIuBSmkXVzVmNNqgO6qTsZbDREDQrB5WGTILshF9ZltdJbzZgh2JmYs1b04ng6cxGTfbFaI6Ov9Sri1Kj1a5dbbTs-az4YbGwjlttdjz8EwCI7kfNvUrLK0lG7Sa8ZA_38oTTK34NMlzahtTxf8D1IJC5nDJTxZ36ZoDhEiiZJJ0JNaI0FaLiI_2YGLWW27ocmtwBl9atsG6F9G4toUYoKJWYWsPljAHz2nAT4qcw7o4AF4UVQeXiKuN2p4bh79zQ" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 23, 20, 42, 47, 899, DateTimeKind.Local).AddTicks(3727));
        }
    }
}
