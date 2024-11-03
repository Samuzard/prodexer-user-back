using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PriceAggregator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTablesAndSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feature",
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
                    table.PrimaryKey("PK_Feature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
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
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Feature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Feature",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Store",
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
                    table.PrimaryKey("PK_Store", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Store_Feature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Feature",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImagePath = table.Column<string>(type: "text", nullable: true),
                    StoreId = table.Column<int>(type: "integer", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Rating = table.Column<decimal>(type: "numeric", nullable: true),
                    PriceUnit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    FeatureId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Feature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Feature",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "FeatureId", "Name", "ParentId", "TreeLevel", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "admin", null, "Shoes", 0, 0, null },
                    { 2, "admin", null, "Womens Shoes", 1, 1, null },
                    { 3, "admin", null, "Mens Shoes", 1, 2, null },
                    { 4, "admin", null, "Shirts", 0, 0, null },
                    { 5, "admin", null, "Womens Shirts", 3, 1, null },
                    { 6, "admin", null, "Mens Shirts", 3, 2, null },
                    { 7, "admin", null, "Jackets", 0, 0, null },
                    { 8, "admin", null, "Gaming", 0, 0, null },
                    { 9, "admin", null, "Smartphones", 0, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "CreatedBy", "FeatureId", "IconPath", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "admin", null, "PlaceholderPath", "Amazon", null },
                    { 2, "admin", null, "PlaceholderPath", "Stirling Sports", null },
                    { 3, "admin", null, "PlaceholderPath", "BestBuy", null },
                    { 4, "admin", null, "PlaceholderPath", "AliExpress", null }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "Description", "FeatureId", "ImagePath", "Name", "Price", "PriceUnit", "StoreId", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { 1, 2, "admin", null, null, null, "ADIDAS", 79.98m, "$", 1, null, "https://www.amazon.com/Nike-Blazer-Jumbo-DN2158-White/dp/B09Q91N4Q7" },
                    { 2, 3, "admin", null, null, null, "NIKE", 180.00m, "$", 2, null, "https://www.stirlingsports.co.nz/new/blazer-low-77-jumbo-mens-dn2158-101" },
                    { 3, 5, "admin", null, null, null, "ZEN", 100.00m, "$", 2, null, "https://www.stirlingsports.co.nz/mens/clothing/tees-and-singlets/IL5172/Adventure-Volcano-Long-Sleeve-Tee.html" },
                    { 4, 6, "admin", null, null, null, "PUMA", 70.00m, "$", 1, null, "https://www.amazon.com/Volcano-Adventure-Climate-Premium-T-Shirt/dp/B0BH88FLPM?customId=B0753883B1&customizationToken=MC_Assembly_1%23B0753883B1&th=1" },
                    { 5, 7, "admin", null, null, null, "HENI", 879.00m, "$", 1, null, "https://www.amazon.com/GIGABYTE-G5-1920x1080-i5-12500H-KF-E3US333SH/dp/B0BVRGF3MR/ref=sr_1_8?keywords=gigabyte&qid=1694092757&s=pc&sprefix=gigabyte%2Caps%2C190&sr=1-8" },
                    { 6, 8, "admin", null, null, null, "ASUS", 879.00m, "$", 1, null, "https://www.amazon.com/GIGABYTE-G5-1920x1080-i5-12500H-KF-E3US333SH/dp/B0BVRGF3MR/ref=sr_1_8?keywords=gigabyte&qid=1694092757&s=pc&sprefix=gigabyte%2Caps%2C190&sr=1-8" },
                    { 7, 8, "admin", null, null, null, "HP", 7287.15m, "$", 3, null, "https://www.bestbuy.ca/en-ca/product/custom-gigabyte-aorus-15-laptop-intel-i7-12700h-32gb-ram-4tb-pcie-ssd-nvidia-rtx-3070-ti-15-6-win-10-pro/15997948" },
                    { 8, 9, "admin", null, null, "https://cdn.mos.cms.futurecdn.net/yDn3ZSXu9eSBxmXQDZ4PCF-650-80.jpg.webp", "IPhone 15", 729.99m, "$", 3, null, "https://www.bestbuy.com/site/apple-iphone-15-128gb-blue-at-t/6417993.p?skuId=6417993" },
                    { 9, 9, "admin", null, null, "https://cdn.mos.cms.futurecdn.net/yDn3ZSXu9eSBxmXQDZ4PCF-650-80.jpg.webp", "IPhone 15", 720m, "$", 1, null, "https://www.amazon.fr/Apple-iPhone-15-128-Go/dp/B0CHXFCYCR?language=en_GB" },
                    { 10, 9, "admin", null, null, "https://cdn.mos.cms.futurecdn.net/yDn3ZSXu9eSBxmXQDZ4PCF-650-80.jpg.webp", "IPhone 15", 709m, "$", 4, null, "https://www.amazon.fr/Apple-iPhone-15-128-Go/dp/B0CHXFCYCR?language=en_GB" },
                    { 11, 9, "admin", null, null, "https://www.samsungshop.tn/26760-large_default/galaxy-s24-ultra-prix-tunisie.jpg", "Samsung 24 Ultra", 1012.14m, "$", 1, null, "https://www.amazon.com/SAMSUNG-Smartphone-Unlocked-Android-Titanium/dp/B0CMDM65JH" },
                    { 12, 9, "admin", null, null, "https://www.samsungshop.tn/26760-large_default/galaxy-s24-ultra-prix-tunisie.jpg", "Samsung 24 Ultra", 1091.99m, "$", 3, null, "https://www.bestbuy.com/site/samsung-galaxy-s24-ultra-512gb-unlocked-titanium-black/6569875.p?skuId=6569875" },
                    { 13, 9, "admin", null, null, "https://www.samsungshop.tn/26760-large_default/galaxy-s24-ultra-prix-tunisie.jpg", "Samsung 24 Ultra", 960.61m, "$", 4, null, "https://www.aliexpress.com/item/1005006524667199.html" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_FeatureId",
                table: "Category",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_FeatureId",
                table: "Product",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_StoreId",
                table: "Product",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_FeatureId",
                table: "Store",
                column: "FeatureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Feature");
        }
    }
}
