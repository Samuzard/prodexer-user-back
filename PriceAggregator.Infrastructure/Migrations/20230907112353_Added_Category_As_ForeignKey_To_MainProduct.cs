using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriceAggregator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_Category_As_ForeignKey_To_MainProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MainProduct_CatrgoryID",
                table: "MainProduct",
                column: "CatrgoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_MainProduct_Category_CatrgoryID",
                table: "MainProduct",
                column: "CatrgoryID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainProduct_Category_CatrgoryID",
                table: "MainProduct");

            migrationBuilder.DropIndex(
                name: "IX_MainProduct_CatrgoryID",
                table: "MainProduct");
        }
    }
}
