using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PriceAggregator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MainCategory",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "IsActive", "Name", "Sort", "UpdateDate", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3366), true, "Clothes", 1, null, null },
                    { 2, "admin", new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3370), true, "Laptops", 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "IconPath", "Name", "UpdateDate", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3212), "PlaceholderPath", "Amazon", null, null },
                    { 2, "admin", new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3226), "PlaceholderPath", "Stirling Sports", null, null },
                    { 3, "admin", new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3228), "PlaceholderPath", "BestBuyu", null, null }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "IsActive", "MainCatrgoryId", "Name", "Sort", "UpdateDate", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3388), true, 1, "Shoes", 1, null, null },
                    { 2, "admin", new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3391), true, 1, "Shirts", 1, null, null },
                    { 3, "admin", new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3393), true, 1, "Shirts", 1, null, null },
                    { 4, "admin", new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3394), true, 2, "Gaming", 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "MainProduct",
                columns: new[] { "Id", "CatrgoryID", "CreatedBy", "CreationDate", "Description", "ImagePath", "Name", "UpdateDate", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 1, "admin", new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3408), "They say, \"Don't fix what works.\" We say, \"Perfect it.\" The classic, streetwear superstar gets rethought with the Nike Blazer Low '77 Jumbo. Harnessing the old-school look you love, it now features an oversized Swoosh design and jumbo laces. Its plush foam tongue and thicker stitching embolden the iconic look that's been praised by the streets since '77.", "https://m.media-amazon.com/images/I/71SncdCQuhL._AC_UX679_.jpg", "Nike Blazer Low '77 Jumbo", null, null },
                    { 2, 2, "admin", new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3410), "Layer this adidas originals Adventure Volcano Long Sleeve under a lightweight jacket, then head outside and let the cool air energise your day. Made from 100% cotton, this soft and comfortable tee is perfect for wandering. Whether you want to hit the trails up in the mountains, go fishing by the lake, or simply head to the market.", "https://www.stirlingsports.co.nz/productimages/medium/1/104252_621324_95281.jpg", "Adventure Volcano Long Sleeve Tee", null, null },
                    { 3, 4, "admin", new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3412), "World's leading brand of the best gaming laptops and creator laptops. Produce the thinnest, lightest, and high-performance laptops for gamers and creators.", "https://static.gigabyte.com/StaticFile/Image/Global/22b8f47f1c21f48fa1a296eaa3565fed/Product/36557/webp/300", "GIGABYTE", null, null }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "MainProductId", "Price", "PriceUnit", "StoreId", "UpdateDate", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3422), 1, 79.98m, "$", 1, null, null, "https://www.amazon.com/Nike-Blazer-Jumbo-DN2158-White/dp/B09Q91N4Q7" },
                    { 2, "admin", new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3427), 1, 180.00m, "$", 2, null, null, "https://www.stirlingsports.co.nz/new/blazer-low-77-jumbo-mens-dn2158-101" },
                    { 3, "admin", new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3429), 2, 100.00m, "$", 2, null, null, "https://www.stirlingsports.co.nz/mens/clothing/tees-and-singlets/IL5172/Adventure-Volcano-Long-Sleeve-Tee.html" },
                    { 4, "admin", new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3431), 2, 70.00m, "$", 1, null, null, "https://www.amazon.com/Volcano-Adventure-Climate-Premium-T-Shirt/dp/B0BH88FLPM?customId=B0753883B1&customizationToken=MC_Assembly_1%23B0753883B1&th=1" },
                    { 5, "admin", new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3433), 3, 879.00m, "$", 1, null, null, "https://www.amazon.com/GIGABYTE-G5-1920x1080-i5-12500H-KF-E3US333SH/dp/B0BVRGF3MR/ref=sr_1_8?keywords=gigabyte&qid=1694092757&s=pc&sprefix=gigabyte%2Caps%2C190&sr=1-8" },
                    { 6, "admin", new DateTime(2023, 9, 7, 14, 36, 35, 531, DateTimeKind.Local).AddTicks(3435), 3, 7287.15m, "$", 3, null, null, "https://www.bestbuy.ca/en-ca/product/custom-gigabyte-aorus-15-laptop-intel-i7-12700h-32gb-ram-4tb-pcie-ssd-nvidia-rtx-3070-ti-15-6-win-10-pro/15997948" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MainProduct",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MainProduct",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MainProduct",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MainCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MainCategory",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
