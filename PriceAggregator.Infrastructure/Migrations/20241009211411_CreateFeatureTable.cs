using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PriceAggregator.Infrastructure.Migrations
{
    public partial class CreateFeatureTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
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
                table: "Stores",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "Categories",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Store_FeatureId",
                table: "Stores",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_FeatureId",
                table: "Products",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_FeatureId",
                table: "Categories",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Feature_FeatureId",
                table: "Stores",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Feature_FeatureId",
                table: "Products",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Feature_FeatureId",
                table: "Categories",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Store_Feature_FeatureId",
                table: "Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Feature_FeatureId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Feature_FeatureId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Store_FeatureId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Product_FeatureId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Category_FeatureId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Categories");
        }
    }
}