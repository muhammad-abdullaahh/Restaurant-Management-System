using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHeaven.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMenuImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 17, 19, 45, 22, 828, DateTimeKind.Local).AddTicks(5159), "$2a$11$2uTJL3KrhtqjxSgeDapfH.1hqK/XpRjH78OBd3WeVQBWmv1ivWhJO" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 1, 17, 19, 45, 22, 686, DateTimeKind.Local).AddTicks(357), "/images/truffle_risotto.png" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 19, 45, 22, 686, DateTimeKind.Local).AddTicks(379));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 1, 17, 19, 45, 22, 686, DateTimeKind.Local).AddTicks(382), "/images/wagyu_burger.png" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 1, 17, 19, 45, 22, 686, DateTimeKind.Local).AddTicks(384), "/images/truffle_burger.png" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 19, 45, 22, 686, DateTimeKind.Local).AddTicks(386));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 1, 17, 19, 45, 22, 686, DateTimeKind.Local).AddTicks(388), "/images/avocado_toast.png" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 19, 45, 22, 686, DateTimeKind.Local).AddTicks(390));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 19, 45, 22, 686, DateTimeKind.Local).AddTicks(392));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 1, 17, 19, 45, 22, 686, DateTimeKind.Local).AddTicks(394), "/images/fluffy_pancakes.png" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 1, 16, 19, 6, 12, 530, DateTimeKind.Local).AddTicks(3207), "https://lh3.googleusercontent.com/aida-public/AB6AXuDd5A8E-n6CDlwtG-N9oKQBMrUU1ai9o8SrRvuciT7E6GHZVkZkh5-Zt16VeeNLYfVxEu31DlDNC0y1J4pW0-Z_pesr0YnifLq1es_rlR6cClkAqzAv-llsK4xuC4E2fg2lgfKdutgFROr7vmqj5z1GhIsp2C1u1qY8KKKYDoiCJ2KOYxa8-3VMtrGx2-dBCdswgHoluVdp0sywvXab14VKNb8E2C5CVi6aRH3v3GTeedd-ZjalrEO5Rk0ACBhwwF2Vm8nvzJO89A" });

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
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 1, 16, 19, 6, 12, 530, DateTimeKind.Local).AddTicks(3227), "https://lh3.googleusercontent.com/aida-public/AB6AXuCM8hth0W3ku6qprVWh1xDrJa96eDN2uJmaZhbfS7fRSEtLCI-EERTrdz-BRL9C8iHTTzjwDGDgWK6nzG7Zb-vTaz1LfTdwSREAtcsSBRZaO65TT3FBbJzniQHpeLnSCr7i4N755p3ym6gs7_N88CDD-p3XzQMkOjMCfLXpN6LAqnkeQMmtNvMGxA6uCkhJHvyGPIetRUXkjSf1XYDFL7WTIQpwCDWBSJ_aseXlg37sX-Ou2BWSObQzQn6bbuVbmvonnP15BXnnHg" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 1, 16, 19, 6, 12, 530, DateTimeKind.Local).AddTicks(3229), "https://lh3.googleusercontent.com/aida-public/AB6AXuBShoqREj7Eta_asAkNTcCkk1CwuLWx_4mOsHB8W55cJus6vpIIVRedhO4m-xZHdV5U0KMmMwTM42xaZeGGtPGWWMW7SvOt8PEIaawXWyqY8_8hW6iVa9A9T4-xPiT3VtdlQBZCysVUjAStZN9Efm14MlHdnBz3ixPdg-wZY_ogVvqanOLkQqSYS1-jHMF7vUjKhwbFFhYNSMCHVPLcFVB8jJHN48-sWUpg0p4dLQUwOhxpfB43UnWXnd0zinLRewiAp-7okfgv1w" });

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
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 1, 16, 19, 6, 12, 530, DateTimeKind.Local).AddTicks(3233), "https://lh3.googleusercontent.com/aida-public/AB6AXuBOYQsBHIeCElObTIakyCRsUiWO6QpGn8r5oKaPTUg_WX1cNHiP0BFfIJ5HzdQO6No_7FGp14RCR6HZdWMUfcS6ndRpkmTFEcZCc6Vt2QUW4T7dOhil7MZLzI2Hh3bxHP7g_DFXGqwnB7_CulVLuE0qLiBvf1cw7k3HlWBxyW1OAWpdQ7GPM4R-mwOfCuni5crv1N0AT8WkSWowiW0dMKAJ1Ch1XIl-zEenjKvNoVHBxMkV7YGhwKjuOFOE6b7r02APVomuCJGDEQ" });

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
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 1, 16, 19, 6, 12, 530, DateTimeKind.Local).AddTicks(3238), "https://lh3.googleusercontent.com/aida-public/AB6AXuCJvopTQKId10fdUeMQuzlDbtvQ85tOjc6J4seYPjUawtAwEOKW0aMGXn1NC9fNWkMCe2GRhfET_cT4XmlZ6EeCIjOYqTU6nu8vcjeTETKNInnqkK75Aj4b-ceSA-bRgA3giVhp1rOdts1cps7OkBLsawGk8QEPgrVvfwRHbAm6kl7U-rtuPd2pa8QM9FFZihGy8G0lO0OQFXL2SWo5O5A4EIYyRFta6n5z5HZ6922sa9KQVl549BbGT5PVVFvYeR3Zh6iPMRGQpQ" });
        }
    }
}
