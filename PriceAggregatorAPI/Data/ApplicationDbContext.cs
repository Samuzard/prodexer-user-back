using Microsoft.EntityFrameworkCore;
using PricAggregatorAPI.Models;

namespace PricAggregatorAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(new Product
                {
                    Id = 1,
                    Name = "Sony PlayStation 5 PS5 - 825GB - Disc Edition Gaming Console (No Controller)",
                    CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    ImageUrl = "https://i.ebayimg.com/images/g/8D4AAOSwD5Zk0Zmq/s-l1600.jpg",
                    Store = "Ebay",
                    Url = "https://www.ebay.com/p/19040936896?iid=385876940689",
                    Description = "3D audio via built-in TV speakers or analog/USB stereo headphones.",
                    Price = 347.99M,
                    Currency = "Dollar",
                    State = "Used",
                    Ratings = 4.85
                });
        }
    }
}
