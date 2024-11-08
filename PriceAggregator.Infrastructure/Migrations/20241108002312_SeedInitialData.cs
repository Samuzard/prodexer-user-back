using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PriceAggregator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "FeatureId", "IsActive", "Name", "ParentId", "TreeLevel", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, "admin", null, false, "Shoes", 0L, 0L, null },
                    { 2L, "admin", null, false, "Women's Shoes", 1L, 1L, null },
                    { 3L, "admin", null, false, "Mens Shoes", 1L, 2L, null },
                    { 4L, "admin", null, false, "Shirts", 0L, 0L, null },
                    { 5L, "admin", null, false, "Women's Shirts", 3L, 1L, null },
                    { 6L, "admin", null, false, "Mens Shirts", 3L, 2L, null },
                    { 7L, "admin", null, false, "Jackets", 0L, 0L, null },
                    { 8L, "admin", null, false, "Gaming", 0L, 0L, null },
                    { 9L, "admin", null, false, "Smartphones", 0L, 0L, null }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "CreatedBy", "FeatureId", "IconPath", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, "admin", null, "/images/store_icons/amazon_logo.png", "Amazon", null },
                    { 2L, "admin", null, "/images/store_icons/stirling_sports.png", "Stirling Sports", null },
                    { 3L, "admin", null, "/images/store_icons/best_buy_logo.png", "BestBuy", null },
                    { 4L, "admin", null, "/images/store_icons/ali_express_logo.png", "AliExpress", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "Description", "FeatureId", "ImagePath", "Name", "Price", "PriceUnit", "Rating", "StoreIconPath", "StoreId", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { 1L, 2L, "admin", null, null, null, "ADIDAS", 79.98m, "$", null, null, 1L, null, "https://www.amazon.com/Nike-Blazer-Jumbo-DN2158-White/dp/B09Q91N4Q7" },
                    { 2L, 3L, "admin", null, null, null, "NIKE", 180.00m, "$", null, null, 2L, null, "https://www.stirlingsports.co.nz/new/blazer-low-77-jumbo-mens-dn2158-101" },
                    { 3L, 5L, "admin", null, null, null, "ZEN", 100.00m, "$", null, null, 2L, null, "https://www.stirlingsports.co.nz/mens/clothing/tees-and-singlets/IL5172/Adventure-Volcano-Long-Sleeve-Tee.html" },
                    { 4L, 6L, "admin", null, null, null, "PUMA", 70.00m, "$", null, null, 1L, null, "https://www.amazon.com/Volcano-Adventure-Climate-Premium-T-Shirt/dp/B0BH88FLPM?customId=B0753883B1&customizationToken=MC_Assembly_1%23B0753883B1&th=1" },
                    { 5L, 7L, "admin", null, null, null, "HENI", 879.00m, "$", null, null, 1L, null, "https://www.amazon.com/GIGABYTE-G5-1920x1080-i5-12500H-KF-E3US333SH/dp/B0BVRGF3MR/ref=sr_1_8?keywords=gigabyte&qid=1694092757&s=pc&sprefix=gigabyte%2Caps%2C190&sr=1-8" },
                    { 6L, 8L, "admin", null, null, null, "ASUS", 879.00m, "$", null, null, 1L, null, "https://www.amazon.com/GIGABYTE-G5-1920x1080-i5-12500H-KF-E3US333SH/dp/B0BVRGF3MR/ref=sr_1_8?keywords=gigabyte&qid=1694092757&s=pc&sprefix=gigabyte%2Caps%2C190&sr=1-8" },
                    { 7L, 8L, "admin", null, null, null, "HP", 7287.15m, "$", null, null, 3L, null, "https://www.bestbuy.ca/en-ca/product/custom-gigabyte-aorus-15-laptop-intel-i7-12700h-32gb-ram-4tb-pcie-ssd-nvidia-rtx-3070-ti-15-6-win-10-pro/15997948" },
                    { 8L, 9L, "admin", null, null, "https://cdn.mos.cms.futurecdn.net/yDn3ZSXu9eSBxmXQDZ4PCF-650-80.jpg.webp", "Apple - iPhone 15 128GB - Blue (AT&T)", 729.99m, "$", null, null, 3L, null, "https://www.bestbuy.com/site/apple-iphone-15-128gb-blue-at-t/6417993.p?skuId=6417993" },
                    { 9L, 9L, "admin", null, null, "https://media.cnn.com/api/v1/images/stellar/prod/230919073346-iphone-15-review-cnnu-1.jpg?c=16x9", "Apple iphone 15 (128gb) - black ", 720m, "$", null, null, 1L, null, "https://www.amazon.fr/Apple-iPhone-15-128-Go/dp/B0CHXFCYCR?language=en_GB" },
                    { 10L, 9L, "admin", null, null, "https://ae-pic-a1.aliexpress-media.com/kf/See613671846f48ccba7a890a8efbe7a05/iPhone-15-Pro-Max-256GB-512GB-1TB-Dual-eSIM-6-7-Genuine-LTPO-Super-Retina-XDR.jpg", "iPhone 15 Pro Max 256GB/512GB/1TB Dual eSIM 6.7\" Genuine LTPO Super Retina XDR OLED Face ID NFC A17Pro 8GB 98% New 5G Cell Phone", 709m, "$", null, null, 4L, null, "https://www.aliexpress.com/item/1005007893612979.html?spm=a2g0o.productlist.main.25.eb42291ejzuZZJ&algo_pvid=243f2f67-93b3-436e-b290-e9eb57e49582&algo_exp_id=243f2f67-93b3-436e-b290-e9eb57e49582-12&pdp_npi=4%40dis%21TND%213862.560%213167.299%21%21%211248.00%211023.36%21%402141122217309344674181553e7a2d%2112000042744921902%21sea%21TN%210%21ABX&curPageLogUid=i7MgtMiDzT4s&utparam-url=scene%3Asearch%7Cquery_from%3A" },
                    { 11L, 9L, "admin", null, null, "https://m.media-amazon.com/images/I/711wsjBtWeL._AC_SL1500_.jpg", "Apple iPhone 12, 256GB, White - (Refurbished) ", 709m, "$", null, null, 4L, null, "https://www.amazon.fr/-/en/dp/B08PCC743H/ref=sr_1_2?crid=1A6VUNFFEGUH&dib=eyJ2IjoiMSJ9.1pxt4S85q2lJWGtflE7yJHGBbd0LNA8qqu712gdan0UMhfFxGb4K0XeAaRjjHtNX-2HvFAqwbcNgbS68deV2LcHOdpN-IfNo9PxvZPDGO_5tRt_PYm5qCZahsxV8TLamYQmlzXIipx5S3plK3NnosvM9qoMClfNvK9z4jWdj_28NC7sfjoyVIvfzoGIqnhtqSyEl4d3OpT9Ztk3g-jVYcUu1IwkhLWy-CrBxVwl8ob8te0Mc-D9WdZzNutm0cXAHx2guk_O9AcnW_D59Kli2vicnmsKNvVK67NxGTfNLpMk.ZNfVCpdxi4gtp87BDncK0ovvfeGJaPigS0IfCjB8L8M&dib_tag=se&keywords=Iphone%2B15&qid=1730941701&sprefix=iphone%2B15%2Caps%2C180&sr=8-2&th=1" },
                    { 12L, 9L, "admin", null, null, "https://m.media-amazon.com/images/I/71WcjsOVOmL.__AC_SX300_SY300_QL70_FMwebp_.jpg", "Samsung 24 Ultra", 1012.14m, "$", null, null, 1L, null, "https://www.amazon.com/SAMSUNG-Smartphone-Unlocked-Android-Titanium/dp/B0CMDM65JH" },
                    { 13L, 9L, "admin", null, null, "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6569/6569875_sd.jpg;maxHeight=640;maxWidth=550;format=webp", "Samsung 24 Ultra", 1091.99m, "$", null, null, 3L, null, "https://www.bestbuy.com/site/samsung-galaxy-s24-ultra-512gb-unlocked-titanium-black/6569875.p?skuId=6569875" },
                    { 14L, 9L, "admin", null, null, "https://www.ooredoo.tn/Personal/9085-large_default/portable-samsung-galaxy-s24-ultra.jpg", "Samsung 24 Ultra", 960.61m, "$", null, null, 4L, null, "https://www.aliexpress.com/item/1005006524667199.html" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
