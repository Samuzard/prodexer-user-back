using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriceAggregator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateAndSeedIconPathIconAltColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconAlt",
                table: "Categories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IconPath",
                table: "Categories",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "IconAlt", "IconPath" },
                values: new object[] { "Scissors icon", "/images/category_icons/scissors.svg" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "IconAlt", "IconPath" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "IconAlt", "IconPath" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "IconAlt", "IconPath" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "IconAlt", "IconPath" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "IconAlt", "IconPath" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "IconAlt", "IconPath" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "IconAlt", "IconPath" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "IconAlt", "IconPath" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconAlt",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IconPath",
                table: "Categories");
        }
    }
}
