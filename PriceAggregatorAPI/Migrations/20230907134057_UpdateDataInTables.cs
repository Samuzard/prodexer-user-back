using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PricAggregatorAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataInTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 40, 56, 914, DateTimeKind.Local).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 40, 56, 914, DateTimeKind.Local).AddTicks(2109));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2023, 9, 7, 14, 40, 56, 914, DateTimeKind.Local).AddTicks(2111), "Jackets" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 40, 56, 914, DateTimeKind.Local).AddTicks(2113));

            migrationBuilder.UpdateData(
                table: "MainCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 40, 56, 914, DateTimeKind.Local).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "MainCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 40, 56, 914, DateTimeKind.Local).AddTicks(2095));

            migrationBuilder.UpdateData(
                table: "MainProduct",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 40, 56, 914, DateTimeKind.Local).AddTicks(2163));

            migrationBuilder.UpdateData(
                table: "MainProduct",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 40, 56, 914, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "MainProduct",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 40, 56, 914, DateTimeKind.Local).AddTicks(2167));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 40, 56, 914, DateTimeKind.Local).AddTicks(2177));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 40, 56, 914, DateTimeKind.Local).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 40, 56, 914, DateTimeKind.Local).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 40, 56, 914, DateTimeKind.Local).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 40, 56, 914, DateTimeKind.Local).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 40, 56, 914, DateTimeKind.Local).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 40, 56, 914, DateTimeKind.Local).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 40, 56, 914, DateTimeKind.Local).AddTicks(1984));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2023, 9, 7, 14, 40, 56, 914, DateTimeKind.Local).AddTicks(1986), "BestBuy" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3388));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3391));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3393), "Shirts" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3394));

            migrationBuilder.UpdateData(
                table: "MainCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3366));

            migrationBuilder.UpdateData(
                table: "MainCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3370));

            migrationBuilder.UpdateData(
                table: "MainProduct",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3408));

            migrationBuilder.UpdateData(
                table: "MainProduct",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3410));

            migrationBuilder.UpdateData(
                table: "MainProduct",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3412));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3422));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3427));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3429));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3431));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3212));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3226));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3228), "BestBuyu" });
        }
    }
}
