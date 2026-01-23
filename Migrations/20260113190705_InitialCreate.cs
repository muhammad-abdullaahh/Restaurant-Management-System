using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodHeaven.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdminResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespondedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoyaltyAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false),
                    MembershipTier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LunchPunchCount = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastActivityDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoyaltyAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ReviewCount = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtotal = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    DeliveryFee = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PromoCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    SpecialInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    PartySize = table.Column<int>(type: "int", nullable: false),
                    TableNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialRequests = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoyaltyTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoyaltyAccountId = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoyaltyTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoyaltyTransactions_LoyaltyAccounts_LoyaltyAccountId",
                        column: x => x.LoyaltyAccountId,
                        principalTable: "LoyaltyAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Customization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "LastLoginAt", "PasswordHash", "ProfileImageUrl", "Username" },
                values: new object[] { 1, new DateTime(2026, 1, 14, 0, 7, 3, 656, DateTimeKind.Local).AddTicks(3551), "admin@foodheaven.com", "Admin User", true, null, "$2a$11$3qcw9IwtH0lKQgOgYhOLVerLvPILU7GtuopBQGAYABv4g1NNByILG", null, "admin" });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "Rating", "ReviewCount", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Mains", new DateTime(2026, 1, 14, 0, 7, 3, 221, DateTimeKind.Local).AddTicks(5588), "Creamy arborio rice with fresh black truffles and parmesan crisp.", "https://lh3.googleusercontent.com/aida-public/AB6AXuDd5A8E-n6CDlwtG-N9oKQBMrUU1ai9o8SrRvuciT7E6GHZVkZkh5-Zt16VeeNLYfVxEu31DlDNC0y1J4pW0-Z_pesr0YnifLq1es_rlR6cClkAqzAv-llsK4xuC4E2fg2lgfKdutgFROr7vmqj5z1GhIsp2C1u1qY8KKKYDoiCJ2KOYxa8-3VMtrGx2-dBCdswgHoluVdp0sywvXab14VKNb8E2C5CVi6aRH3v3GTeedd-ZjalrEO5Rk0ACBhwwF2Vm8nvzJO89A", true, "Truffle Risotto", 24.00m, 4.9000000000000004, 128, null },
                    { 2, "Mains", new DateTime(2026, 1, 14, 0, 7, 3, 221, DateTimeKind.Local).AddTicks(5622), "Atlantic salmon with lemon butter sauce and grilled asparagus.", "https://lh3.googleusercontent.com/aida-public/AB6AXuDNrvAofLcEQx3a1ZXD2766HUT65ZwhGPi1k1AXhl64HEavGi8nxRyffeK2LQ1oxPd2l434Oa94YXAZT12CMqKjQTBF2Jb-8E5dAceM7FJUcelHF-6c4q15awtGEgO3PLu8mQM5UI5IuBTsZxo8YpUNEtR4k4Z2U6u_W2XctSp_0D7ecrWJK422mSw0xZv6oUUGBnX3XTr0Y3po6FEJ-BVMbMMnqK4FYYNU0u4RQkSQXKzN3eFrWYD2bhYIjwKQERuzO1vUb6O07Q", true, "Pan-Seared Salmon", 28.00m, 4.7000000000000002, 85, null },
                    { 3, "Mains", new DateTime(2026, 1, 14, 0, 7, 3, 221, DateTimeKind.Local).AddTicks(5631), "Premium wagyu beef patty, aged cheddar, truffle mayo on brioche.", "https://lh3.googleusercontent.com/aida-public/AB6AXuCM8hth0W3ku6qprVWh1xDrJa96eDN2uJmaZhbfS7fRSEtLCI-EERTrdz-BRL9C8iHTTzjwDGDgWK6nzG7Zb-vTaz1LfTdwSREAtcsSBRZaO65TT3FBbJzniQHpeLnSCr7i4N755p3ym6gs7_N88CDD-p3XzQMkOjMCfLXpN6LAqnkeQMmtNvMGxA6uCkhJHvyGPIetRUXkjSf1XYDFL7WTIQpwCDWBSJ_aseXlg37sX-Ou2BWSObQzQn6bbuVbmvonnP15BXnnHg", true, "Royal Wagyu Burger", 22.00m, 4.7999999999999998, 210, null },
                    { 4, "Mains", new DateTime(2026, 1, 14, 0, 7, 3, 221, DateTimeKind.Local).AddTicks(5637), "Wagyu beef with truffle oil", "https://lh3.googleusercontent.com/aida-public/AB6AXuBShoqREj7Eta_asAkNTcCkk1CwuLWx_4mOsHB8W55cJus6vpIIVRedhO4m-xZHdV5U0KMmMwTM42xaZeGGtPGWWMW7SvOt8PEIaawXWyqY8_8hW6iVa9A9T4-xPiT3VtdlQBZCysVUjAStZN9Efm14MlHdnBz3ixPdg-wZY_ogVvqanOLkQqSYS1-jHMF7vUjKhwbFFhYNSMCHVPLcFVB8jJHN48-sWUpg0p4dLQUwOhxpfB43UnWXnd0zinLRewiAp-7okfgv1w", true, "Golden Truffle Burger", 18.50m, 4.7999999999999998, 95, null },
                    { 5, "Mains", new DateTime(2026, 1, 14, 0, 7, 3, 221, DateTimeKind.Local).AddTicks(5643), "Fresh basil, chili, garlic", "https://lh3.googleusercontent.com/aida-public/AB6AXuDfWitYE4hwDczx9Z-VIscp8kFY3t1c7tJueP_sW0XkR6EW2YM0vC1M4_LrFzbnykXuUg7lmcsy1nz-rL4x03gJfzB9iXMzCFJtTORYym8uJDHJbCoEygHqUJcYT59qBjkpnS3np4Zwu_KX8k8v1wrgeaTcao1EbDmNjz-ij4cjZFHcM-yo-cJIeTFaj2BOvoxkNCp5lu566DDOVAcqyZHIolGrMV4W-f9hRXH5a9eBfPjt2axi-Nvk3uFpAfFKy36vLmF4e1HOPQ", true, "Spicy Thai Basil Pasta", 14.00m, 4.5, 67, null },
                    { 6, "Starters", new DateTime(2026, 1, 14, 0, 7, 3, 221, DateTimeKind.Local).AddTicks(5650), "Sourdough, lemon, chili flakes", "https://lh3.googleusercontent.com/aida-public/AB6AXuBOYQsBHIeCElObTIakyCRsUiWO6QpGn8r5oKaPTUg_WX1cNHiP0BFfIJ5HzdQO6No_7FGp14RCR6HZdWMUfcS6ndRpkmTFEcZCc6Vt2QUW4T7dOhil7MZLzI2Hh3bxHP7g_DFXGqwnB7_CulVLuE0qLiBvf1cw7k3HlWBxyW1OAWpdQ7GPM4R-mwOfCuni5crv1N0AT8WkSWowiW0dMKAJ1Ch1XIl-zEenjKvNoVHBxMkV7YGhwKjuOFOE6b7r02APVomuCJGDEQ", true, "Creamy Avocado Toast", 12.00m, 4.9000000000000004, 143, null },
                    { 7, "Drinks", new DateTime(2026, 1, 14, 0, 7, 3, 221, DateTimeKind.Local).AddTicks(5657), "Blueberry, banana, chia seeds", "https://lh3.googleusercontent.com/aida-public/AB6AXuB6wcyAKmNM9_xGQUed-hjbJioT5oPF1lfh6_YbyCXMg1W1ZmaCd888UKjOvluITeTAyZPMtsQLFPWIjDmcTA5L7-RIWceRR39xPbsEcpOodl0BlxDfLK7a83dW2hL-Qx5i1NIThF5cd7UWbJ-VPAHuHxYYpDg4vf7OvTOKGaOFEve1TWfFYLyjCXLKVbvORWtJXkb9sNMimTocvC86q0GPyCW192ZYAIMFQGCWGruiREfd_yXW2Sd6Szt5uHjg3W8cNgX14E-L_A", true, "Berry Smoothie", 9.50m, 4.7000000000000002, 88, null },
                    { 8, "Healthy", new DateTime(2026, 1, 14, 0, 7, 3, 221, DateTimeKind.Local).AddTicks(5664), "Quinoa, chickpeas, tahini", "https://lh3.googleusercontent.com/aida-public/AB6AXuAOWTa96d3PDsIuBSmkXVzVmNNqgO6qTsZbDREDQrB5WGTILshF9ZltdJbzZgh2JmYs1b04ng6cxGTfbFaI6Ov9Sri1Kj1a5dbbTs-az4YbGwjlttdjz8EwCI7kfNvUrLK0lG7Sa8ZA_38oTTK34NMlzahtTxf8D1IJC5nDJTxZ36ZoDhEiiZJJ0JNaI0FaLiI_2YGLWW27ocmtwBl9atsG6F9G4toUYoKJWYWsPljAHz2nAT4qcw7o4AF4UVQeXiKuN2p4bh79zQ", true, "Buddha Bowl", 11.00m, 4.5999999999999996, 72, null },
                    { 9, "Desserts", new DateTime(2026, 1, 14, 0, 7, 3, 221, DateTimeKind.Local).AddTicks(5670), "Maple syrup, fresh berries", "https://lh3.googleusercontent.com/aida-public/AB6AXuCJvopTQKId10fdUeMQuzlDbtvQ85tOjc6J4seYPjUawtAwEOKW0aMGXn1NC9fNWkMCe2GRhfET_cT4XmlZ6EeCIjOYqTU6nu8vcjeTETKNInnqkK75Aj4b-ceSA-bRgA3giVhp1rOdts1cps7OkBLsawGk8QEPgrVvfwRHbAm6kl7U-rtuPd2pa8QM9FFZihGy8G0lO0OQFXL2SWo5O5A4EIYyRFta6n5z5HZ6922sa9KQVl549BbGT5PVVFvYeR3Zh6iPMRGQpQ", true, "Fluffy Pancakes", 13.50m, 5.0, 156, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoyaltyTransactions_LoyaltyAccountId",
                table: "LoyaltyTransactions",
                column: "LoyaltyAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItemId",
                table: "OrderItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "ContactMessages");

            migrationBuilder.DropTable(
                name: "LoyaltyTransactions");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "LoyaltyAccounts");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
