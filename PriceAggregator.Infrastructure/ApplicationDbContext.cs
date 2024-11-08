using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PriceAggregator.Core.Entities;
using PriceAggregator.Infrastructure.Utils.SeedHelpers;

namespace PriceAggregator.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; init; }
        public DbSet<Category> Categories { get; init; }
        public DbSet<Store> Stores { get; init; }
        public DbSet<FeaturedItem> FeaturedItems { get; init; }
        private readonly IConfiguration _configuration;
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            StoreSeedHelper.SeedStores(modelBuilder);
            CategorySeedHelper.SeedCategories(modelBuilder);
            ProductSeedHelper.SeedProducts(modelBuilder);
        }
    }
}
