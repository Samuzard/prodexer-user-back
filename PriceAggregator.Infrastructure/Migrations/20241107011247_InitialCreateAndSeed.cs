using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PriceAggregator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeaturedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturedItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    TreeLevel = table.Column<int>(type: "integer", nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: false),
                    FeatureId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_FeaturedItems_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "FeaturedItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IconPath = table.Column<string>(type: "text", nullable: true),
                    FeatureId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_FeaturedItems_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "FeaturedItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImagePath = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    PriceUnit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Rating = table.Column<decimal>(type: "numeric", nullable: true),
                    StoreIconPath = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    StoreId = table.Column<int>(type: "integer", nullable: false),
                    FeatureId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_FeaturedItems_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "FeaturedItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "FeatureId", "Name", "ParentId", "TreeLevel", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "admin", null, "Shoes", 0, 0, null },
                    { 2, "admin", null, "Women's Shoes", 1, 1, null },
                    { 3, "admin", null, "Mens Shoes", 1, 2, null },
                    { 4, "admin", null, "Shirts", 0, 0, null },
                    { 5, "admin", null, "Women's Shirts", 3, 1, null },
                    { 6, "admin", null, "Mens Shirts", 3, 2, null },
                    { 7, "admin", null, "Jackets", 0, 0, null },
                    { 8, "admin", null, "Gaming", 0, 0, null },
                    { 9, "admin", null, "Smartphones", 0, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "CreatedBy", "FeatureId", "IconPath", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "admin", null, "/images/store_icons/amazon_logo.png", "Amazon", null },
                    { 2, "admin", null, "/images/store_icons/stirling_sports.png", "Stirling Sports", null },
                    { 3, "admin", null, "/images/store_icons/best_buy_logo.png", "BestBuy", null },
                    { 4, "admin", null, "/images/store_icons/ali_express_logo.png", "AliExpress", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "Description", "FeatureId", "ImagePath", "Name", "Price", "PriceUnit", "Rating", "StoreIconPath", "StoreId", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { 1, 2, "admin", null, null, null, "ADIDAS", 79.98m, "$", null, null, 1, null, "https://www.amazon.com/Nike-Blazer-Jumbo-DN2158-White/dp/B09Q91N4Q7" },
                    { 2, 3, "admin", null, null, null, "NIKE", 180.00m, "$", null, null, 2, null, "https://www.stirlingsports.co.nz/new/blazer-low-77-jumbo-mens-dn2158-101" },
                    { 3, 5, "admin", null, null, null, "ZEN", 100.00m, "$", null, null, 2, null, "https://www.stirlingsports.co.nz/mens/clothing/tees-and-singlets/IL5172/Adventure-Volcano-Long-Sleeve-Tee.html" },
                    { 4, 6, "admin", null, null, null, "PUMA", 70.00m, "$", null, null, 1, null, "https://www.amazon.com/Volcano-Adventure-Climate-Premium-T-Shirt/dp/B0BH88FLPM?customId=B0753883B1&customizationToken=MC_Assembly_1%23B0753883B1&th=1" },
                    { 5, 7, "admin", null, null, null, "HENI", 879.00m, "$", null, null, 1, null, "https://www.amazon.com/GIGABYTE-G5-1920x1080-i5-12500H-KF-E3US333SH/dp/B0BVRGF3MR/ref=sr_1_8?keywords=gigabyte&qid=1694092757&s=pc&sprefix=gigabyte%2Caps%2C190&sr=1-8" },
                    { 6, 8, "admin", null, null, null, "ASUS", 879.00m, "$", null, null, 1, null, "https://www.amazon.com/GIGABYTE-G5-1920x1080-i5-12500H-KF-E3US333SH/dp/B0BVRGF3MR/ref=sr_1_8?keywords=gigabyte&qid=1694092757&s=pc&sprefix=gigabyte%2Caps%2C190&sr=1-8" },
                    { 7, 8, "admin", null, null, null, "HP", 7287.15m, "$", null, null, 3, null, "https://www.bestbuy.ca/en-ca/product/custom-gigabyte-aorus-15-laptop-intel-i7-12700h-32gb-ram-4tb-pcie-ssd-nvidia-rtx-3070-ti-15-6-win-10-pro/15997948" },
                    { 8, 9, "admin", null, null, "https://cdn.mos.cms.futurecdn.net/yDn3ZSXu9eSBxmXQDZ4PCF-650-80.jpg.webp", "Apple - iPhone 15 128GB - Blue (AT&T)", 729.99m, "$", null, null, 3, null, "https://www.bestbuy.com/site/apple-iphone-15-128gb-blue-at-t/6417993.p?skuId=6417993" },
                    { 9, 9, "admin", null, null, "https://media.cnn.com/api/v1/images/stellar/prod/230919073346-iphone-15-review-cnnu-1.jpg?c=16x9", "Apple iphone 15 (128gb) - black ", 720m, "$", null, null, 1, null, "https://www.amazon.fr/Apple-iPhone-15-128-Go/dp/B0CHXFCYCR?language=en_GB" },
                    { 10, 9, "admin", null, null, "https://ae-pic-a1.aliexpress-media.com/kf/See613671846f48ccba7a890a8efbe7a05/iPhone-15-Pro-Max-256GB-512GB-1TB-Dual-eSIM-6-7-Genuine-LTPO-Super-Retina-XDR.jpg", "iPhone 15 Pro Max 256GB/512GB/1TB Dual eSIM 6.7\" Genuine LTPO Super Retina XDR OLED Face ID NFC A17Pro 8GB 98% New 5G Cell Phone", 709m, "$", null, null, 4, null, "https://www.aliexpress.com/item/1005007893612979.html?spm=a2g0o.productlist.main.25.eb42291ejzuZZJ&algo_pvid=243f2f67-93b3-436e-b290-e9eb57e49582&algo_exp_id=243f2f67-93b3-436e-b290-e9eb57e49582-12&pdp_npi=4%40dis%21TND%213862.560%213167.299%21%21%211248.00%211023.36%21%402141122217309344674181553e7a2d%2112000042744921902%21sea%21TN%210%21ABX&curPageLogUid=i7MgtMiDzT4s&utparam-url=scene%3Asearch%7Cquery_from%3A" },
                    { 11, 9, "admin", null, null, "https://m.media-amazon.com/images/G/08/apparel/rcxgs/tile._CB483369919_.gif", "Apple iPhone 12, 256GB, White - (Refurbished) ", 709m, "$", null, null, 4, null, "https://www.amazon.fr/-/en/dp/B08PCC743H/ref=sr_1_2?crid=1A6VUNFFEGUH&dib=eyJ2IjoiMSJ9.1pxt4S85q2lJWGtflE7yJHGBbd0LNA8qqu712gdan0UMhfFxGb4K0XeAaRjjHtNX-2HvFAqwbcNgbS68deV2LcHOdpN-IfNo9PxvZPDGO_5tRt_PYm5qCZahsxV8TLamYQmlzXIipx5S3plK3NnosvM9qoMClfNvK9z4jWdj_28NC7sfjoyVIvfzoGIqnhtqSyEl4d3OpT9Ztk3g-jVYcUu1IwkhLWy-CrBxVwl8ob8te0Mc-D9WdZzNutm0cXAHx2guk_O9AcnW_D59Kli2vicnmsKNvVK67NxGTfNLpMk.ZNfVCpdxi4gtp87BDncK0ovvfeGJaPigS0IfCjB8L8M&dib_tag=se&keywords=Iphone%2B15&qid=1730941701&sprefix=iphone%2B15%2Caps%2C180&sr=8-2&th=1" },
                    { 12, 9, "admin", null, null, "https://m.media-amazon.com/images/I/71WcjsOVOmL.__AC_SX300_SY300_QL70_FMwebp_.jpg", "Samsung 24 Ultra", 1012.14m, "$", null, null, 1, null, "https://www.amazon.com/SAMSUNG-Smartphone-Unlocked-Android-Titanium/dp/B0CMDM65JH" },
                    { 13, 9, "admin", null, null, "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6569/6569875_sd.jpg;maxHeight=640;maxWidth=550;format=webp", "Samsung 24 Ultra", 1091.99m, "$", null, null, 3, null, "https://www.bestbuy.com/site/samsung-galaxy-s24-ultra-512gb-unlocked-titanium-black/6569875.p?skuId=6569875" },
                    { 14, 9, "admin", null, null, "https://www.ooredoo.tn/Personal/9085-large_default/portable-samsung-galaxy-s24-ultra.jpg", "Samsung 24 Ultra", 960.61m, "$", null, null, 4, null, "https://www.aliexpress.com/item/1005006524667199.html" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_FeatureId",
                table: "Categories",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FeatureId",
                table: "Products",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId",
                table: "Products",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_FeatureId",
                table: "Stores",
                column: "FeatureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "FeaturedItems");
        }
    }
}
