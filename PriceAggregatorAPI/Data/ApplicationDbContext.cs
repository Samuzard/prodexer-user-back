using Microsoft.EntityFrameworkCore;
using PricAggregatorAPI.Models;
using PriceAggregatorAPI.Models;

namespace PricAggregatorAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MainProduct> MainProduct { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<MainCategory> MainCategory { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Store> Store { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                .HasData(new Store
                {
                    CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 1,
                    Name = "Amazon",
                    IconPath = "PlaceholderPath"

                },
                new Store
                {
                    CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 2,
                    Name = "Stirling Sports",
                    IconPath = "PlaceholderPath"

                },
                new Store
                {
                    CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 3,
                    Name = "BestBuy",
                    IconPath = "PlaceholderPath"

                });

            modelBuilder.Entity<MainCategory>()
                .HasData(new MainCategory
                {
                    CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 1,
                    Name = "Clothes",
                    IsActive = true,
                    Sort = 1

                },
                new MainCategory
                {
                    CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 2,
                    Name = "Laptops",
                    IsActive = true,
                    Sort = 1

                });

            modelBuilder.Entity<Category>()
                .HasData(new Category
                {
                    CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 1,
                    Name = "Shoes",
                    MainCatrgoryId = 1,
                    IsActive = true,
                    Sort = 1

                },
                new Category
                {
                    CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 2,
                    Name = "Shirts",
                    MainCatrgoryId = 1,
                    IsActive = true,
                    Sort = 1

                },
                new Category
                {
                    CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 3,
                    Name = "Jackets",
                    MainCatrgoryId = 1,
                    IsActive = true,
                    Sort = 1

                },
                new Category
                {
                    CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 4,
                    Name = "Gaming",
                    MainCatrgoryId = 2,
                    IsActive = true,
                    Sort = 1

                }
                );

            modelBuilder.Entity<MainProduct>()
                .HasData(new MainProduct
                {
                    CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 1,
                    Name = "Nike Blazer Low '77 Jumbo",
                    Description = "They say, \"Don't fix what works.\" We say, \"Perfect it.\" The classic, " +
                    "streetwear superstar gets rethought with the Nike Blazer Low '77 Jumbo. " +
                    "Harnessing the old-school look you love, it now features an oversized Swoosh design and jumbo laces." +
                    " Its plush foam tongue and thicker stitching embolden the iconic look that's been praised" +
                    " by the streets since '77.",
                    ImagePath = "https://m.media-amazon.com/images/I/71SncdCQuhL._AC_UX679_.jpg",
                    CatrgoryID = 1,

                },
                new MainProduct
                {
                    CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 2,
                    Name = "Adventure Volcano Long Sleeve Tee",
                    Description = "Layer this adidas originals Adventure Volcano Long Sleeve under a lightweight jacket," +
                    " then head outside and let the cool air energise your day. Made from 100% cotton," +
                    " this soft and comfortable tee is perfect for wandering." +
                    " Whether you want to hit the trails up in the mountains," +
                    " go fishing by the lake, or simply head to the market.",
                    ImagePath = "https://www.stirlingsports.co.nz/productimages/medium/1/104252_621324_95281.jpg",
                    CatrgoryID = 2,

                },
                new MainProduct
                {
                    CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 3,
                    Name = "GIGABYTE",
                    Description = "World's leading brand of the best gaming laptops and creator laptops." +
                    " Produce the thinnest, lightest, and high-performance laptops for gamers and creators.",
                    ImagePath = "https://static.gigabyte.com/StaticFile/Image/Global/22b8f47f1c21f48fa1a296eaa3565fed/Product/36557/webp/300",
                    CatrgoryID = 4,

                });

            modelBuilder.Entity<Product>()
               .HasData(new Product
               {
                   CreationDate = DateTime.Now,
                   CreatedBy = "admin",
                   Id = 1,
                   MainProductId = 1,
                   StoreId = 1,
                   Url = "https://www.amazon.com/Nike-Blazer-Jumbo-DN2158-White/dp/B09Q91N4Q7",
                   Price = 79.98M,
                   PriceUnit = "$"

               },
               new Product
               {
                   CreationDate = DateTime.Now,
                   CreatedBy = "admin",
                   Id = 2,
                   MainProductId = 1,
                   StoreId = 2,
                   Url = "https://www.stirlingsports.co.nz/new/blazer-low-77-jumbo-mens-dn2158-101",
                   Price = 180.00M,
                   PriceUnit = "$"

               },
               new Product
               {
                   CreationDate = DateTime.Now,
                   CreatedBy = "admin",
                   Id = 3,
                   MainProductId = 2,
                   StoreId = 2,
                   Url = "https://www.stirlingsports.co.nz/mens/clothing/tees-and-singlets/IL5172/Adventure-Volcano-Long-Sleeve-Tee.html",
                   Price = 100.00M,
                   PriceUnit = "$"

               },
               new Product
               {
                   CreationDate = DateTime.Now,
                   CreatedBy = "admin",
                   Id = 4,
                   MainProductId = 2,
                   StoreId = 1,
                   Url = "https://www.amazon.com/Volcano-Adventure-Climate-Premium-T-Shirt/dp/B0BH88FLPM?customId=B0753883B1&customizationToken=MC_Assembly_1%23B0753883B1&th=1",
                   Price = 70.00M,
                   PriceUnit = "$"

               },
               new Product
               {
                   CreationDate = DateTime.Now,
                   CreatedBy = "admin",
                   Id = 5,
                   MainProductId = 3,
                   StoreId = 1,
                   Url = "https://www.amazon.com/GIGABYTE-G5-1920x1080-i5-12500H-KF-E3US333SH/dp/B0BVRGF3MR/ref=sr_1_8?keywords=gigabyte&qid=1694092757&s=pc&sprefix=gigabyte%2Caps%2C190&sr=1-8",
                   Price = 879.00M,
                   PriceUnit = "$"

               },
               new Product
               {
                   CreationDate = DateTime.Now,
                   CreatedBy = "admin",
                   Id = 6,
                   MainProductId = 3,
                   StoreId = 3,
                   Url = "https://www.bestbuy.ca/en-ca/product/custom-gigabyte-aorus-15-laptop-intel-i7-12700h-32gb-ram-4tb-pcie-ssd-nvidia-rtx-3070-ti-15-6-win-10-pro/15997948",
                   Price = 7287.15M,
                   PriceUnit = "$"

               });
        }
    }
}
