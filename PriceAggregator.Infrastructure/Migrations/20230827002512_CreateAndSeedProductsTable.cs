using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace PriceAggregator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateAndSeedProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true),
                    Store = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    State = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Ratings = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "Currency", "Description", "ImageUrl", "Name", "Price", "Ratings", "State", "Store", "UpdateDate", "UpdatedBy", "Url" },
                values: new object[] { 1, "admin", new DateTime(2023, 8, 27, 1, 25, 12, 506, DateTimeKind.Local).AddTicks(5622), "Dollar", "3D audio via built-in TV speakers or analog/USB stereo headphones.", "https://i.ebayimg.com/images/g/8D4AAOSwD5Zk0Zmq/s-l1600.jpg", "Sony PlayStation 5 PS5 - 825GB - Disc Edition Gaming Console (No Controller)", 347.99m, 4.8499999999999996, "Used", "Ebay", null, null, "https://www.ebay.com/p/19040936896?iid=385876940689" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
