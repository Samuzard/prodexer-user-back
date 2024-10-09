using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PriceAggregator.Infrastructure.Migrations
{
    public partial class CreateFeatureTable : Migration
    {
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

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "Store",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "Product",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "Category",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Store_FeatureId",
                table: "Store",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_FeatureId",
                table: "Product",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_FeatureId",
                table: "Category",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Feature_FeatureId",
                table: "Store",
                column: "FeatureId",
                principalTable: "Feature",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Feature_FeatureId",
                table: "Product",
                column: "FeatureId",
                principalTable: "Feature",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Feature_FeatureId",
                table: "Category",
                column: "FeatureId",
                principalTable: "Feature",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Store_Feature_FeatureId",
                table: "Store");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Feature_FeatureId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Feature_FeatureId",
                table: "Category");

            migrationBuilder.DropTable(
                name: "Feature");

            migrationBuilder.DropIndex(
                name: "IX_Store_FeatureId",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Product_FeatureId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Category_FeatureId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Category");
        }
    }
}