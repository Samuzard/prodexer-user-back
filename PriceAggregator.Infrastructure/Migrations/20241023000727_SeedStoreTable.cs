using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PriceAggregator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedStoreTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                UPDATE ""Store"" 
                SET ""IconPath"" = CASE ""Id""
                    WHEN 1 THEN '/usr/local/build/prodexer_images/stores_icons/amazon_logo.png'
                    WHEN 2 THEN '/usr/local/build/prodexer_images/stores_icons/stirling_sports_logo.png'
                    WHEN 3 THEN '/usr/local/build/prodexer_images/stores_icons/best_buy_logo.png'
                    WHEN 4 THEN '/usr/local/build/prodexer_images/stores_icons/ali_express_logo.png'
                END,
                ""UpdatedBy"" = 'admin'
                WHERE ""Id"" IN (1, 2, 3, 4)
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Optionally, you can revert to the old values in the Down method
            migrationBuilder.Sql(@"
                UPDATE ""Store"" 
                SET ""IconPath"" = NULL,
                    ""UpdatedBy"" = NULL
                WHERE ""Id"" IN (1, 2, 3, 4)
            ");
        }
    }
}
