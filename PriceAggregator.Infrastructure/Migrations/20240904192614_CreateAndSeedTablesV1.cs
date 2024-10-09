using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PriceAggregator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateAndSeedTablesV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    TreeLevel = table.Column<int>(type: "integer", nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IconPath = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
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
                    StoreId = table.Column<int>(type: "integer", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    PriceUnit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    CatrgoryID = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CatrgoryID",
                        column: x => x.CatrgoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "Name", "ParentId", "TreeLevel", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "admin", "Shoes", 0, 0, null },
                    { 2, "admin", "Womens Shoes", 1, 1, null },
                    { 3, "admin", "Mens Shoes", 1, 2, null },
                    { 4, "admin", "Shirts", 0, 0, null },
                    { 5, "admin", "Womens Shirts", 3, 1, null },
                    { 6, "admin", "Mens Shirts", 3, 2, null },
                    { 7, "admin", "Jackets", 0, 0, null },
                    { 8, "admin", "Gaming", 0, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "CreatedBy", "IconPath", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "admin", "PlaceholderPath", "Amazon", null },
                    { 2, "admin", "PlaceholderPath", "Stirling Sports", null },
                    { 3, "admin", "PlaceholderPath", "BestBuy", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CatrgoryID", "CreatedBy", "Description", "ImagePath", "Name", "Price", "PriceUnit", "StoreId", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { 1, 2, "admin", null, null, "ADIDAS", 79.98m, "$", 1, null, "https://www.amazon.com/Nike-Blazer-Jumbo-DN2158-White/dp/B09Q91N4Q7" },
                    { 2, 3, "admin", null, null, "NIKE", 180.00m, "$", 2, null, "https://www.stirlingsports.co.nz/new/blazer-low-77-jumbo-mens-dn2158-101" },
                    { 3, 5, "admin", null, null, "ZEN", 100.00m, "$", 2, null, "https://www.stirlingsports.co.nz/mens/clothing/tees-and-singlets/IL5172/Adventure-Volcano-Long-Sleeve-Tee.html" },
                    { 4, 6, "admin", null, null, "PUMA", 70.00m, "$", 1, null, "https://www.amazon.com/Volcano-Adventure-Climate-Premium-T-Shirt/dp/B0BH88FLPM?customId=B0753883B1&customizationToken=MC_Assembly_1%23B0753883B1&th=1" },
                    { 5, 7, "admin", null, null, "HENI", 879.00m, "$", 1, null, "https://www.amazon.com/GIGABYTE-G5-1920x1080-i5-12500H-KF-E3US333SH/dp/B0BVRGF3MR/ref=sr_1_8?keywords=gigabyte&qid=1694092757&s=pc&sprefix=gigabyte%2Caps%2C190&sr=1-8" },
                    { 6, 8, "admin", null, null, "ASUS", 879.00m, "$", 1, null, "https://www.amazon.com/GIGABYTE-G5-1920x1080-i5-12500H-KF-E3US333SH/dp/B0BVRGF3MR/ref=sr_1_8?keywords=gigabyte&qid=1694092757&s=pc&sprefix=gigabyte%2Caps%2C190&sr=1-8" },
                    { 7, 8, "admin", null, null, "HP", 7287.15m, "$", 3, null, "https://www.bestbuy.ca/en-ca/product/custom-gigabyte-aorus-15-laptop-intel-i7-12700h-32gb-ram-4tb-pcie-ssd-nvidia-rtx-3070-ti-15-6-win-10-pro/15997948" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CatrgoryID",
                table: "Products",
                column: "CatrgoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_StoreId",
                table: "Products",
                column: "StoreId");
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
        }
    }
}
