using Microsoft.EntityFrameworkCore;
using PriceAggregator.Core.Entities;

namespace PriceAggregator.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
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
                    //CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 1,
                    Name = "Amazon",
                    IconPath = "PlaceholderPath"

                },
                new Store
                {
                    //CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 2,
                    Name = "Stirling Sports",
                    IconPath = "PlaceholderPath"

                },
                new Store
                {
                    //CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 3,
                    Name = "BestBuy",
                    IconPath = "PlaceholderPath"

                });

            modelBuilder.Entity<Category>()
                .HasData(new Category
                {
                    //CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 1,
                    Name = "Shoes",
                    TreeLevel = 0,

                },
                new Category
                {
                    //CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 2,
                    Name = "Womens Shoes",
                    TreeLevel = 1,
                    ParentId = 1
                },
                new Category
                {
                    //CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 3,
                    Name = "Mens Shoes",
                    TreeLevel = 2,
                    ParentId = 1
                },
                new Category
                {
                    //CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 4,
                    Name = "Shirts",
                    TreeLevel = 0,
                },
                new Category
                {
                    //CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 5,
                    Name = "Womens Shirts",
                    TreeLevel = 1,
                    ParentId = 3
                },
                new Category
                {
                    //CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 6,
                    Name = "Mens Shirts",
                    TreeLevel = 2,
                    ParentId = 3
                },
                new Category
                {
                    //CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 7,
                    Name = "Jackets",

                },
                new Category
                {
                    //CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 8,
                    Name = "Gaming",
                }
                );


            modelBuilder.Entity<Product>()
               .HasData(new Product
               {
                   Name = "ADIDAS",
                   //CreationDate = DateTime.Now,
                   CreatedBy = "admin",
                   Id = 1,
                   StoreId = 1,
                   Url = "https://www.amazon.com/Nike-Blazer-Jumbo-DN2158-White/dp/B09Q91N4Q7",
                   Price = 79.98M,
                   PriceUnit = "$",
                   CatrgoryID = 2
               },
               new Product
               {
                   Name = "NIKE",
                   //CreationDate = DateTime.Now,
                   CreatedBy = "admin",
                   Id = 2,
                   StoreId = 2,
                   Url = "https://www.stirlingsports.co.nz/new/blazer-low-77-jumbo-mens-dn2158-101",
                   Price = 180.00M,
                   PriceUnit = "$",
                   CatrgoryID = 3
               },
               new Product
               {
                   Name = "ZEN",
                   //CreationDate = DateTime.Now,
                   CreatedBy = "admin",
                   Id = 3,
                   StoreId = 2,
                   Url = "https://www.stirlingsports.co.nz/mens/clothing/tees-and-singlets/IL5172/Adventure-Volcano-Long-Sleeve-Tee.html",
                   Price = 100.00M,
                   PriceUnit = "$",
                   CatrgoryID = 5
               },
               new Product
               {
                   Name = "PUMA",
                   //CreationDate = DateTime.Now,
                   CreatedBy = "admin",
                   Id = 4,
                   StoreId = 1,
                   Url = "https://www.amazon.com/Volcano-Adventure-Climate-Premium-T-Shirt/dp/B0BH88FLPM?customId=B0753883B1&customizationToken=MC_Assembly_1%23B0753883B1&th=1",
                   Price = 70.00M,
                   PriceUnit = "$",
                   CatrgoryID = 6

               },new Product
               {
                   Name = "HENI",
                   //CreationDate = DateTime.Now,
                   CreatedBy = "admin",
                   Id = 5,
                   StoreId = 1,
                   Url = "https://www.amazon.com/GIGABYTE-G5-1920x1080-i5-12500H-KF-E3US333SH/dp/B0BVRGF3MR/ref=sr_1_8?keywords=gigabyte&qid=1694092757&s=pc&sprefix=gigabyte%2Caps%2C190&sr=1-8",
                   Price = 879.00M,
                   PriceUnit = "$",
                   CatrgoryID = 7

               },
               
               new Product
               {
                   Name = "ASUS",
                   //CreationDate = DateTime.Now,
                   CreatedBy = "admin",
                   Id = 6,
                   StoreId = 1,
                   Url = "https://www.amazon.com/GIGABYTE-G5-1920x1080-i5-12500H-KF-E3US333SH/dp/B0BVRGF3MR/ref=sr_1_8?keywords=gigabyte&qid=1694092757&s=pc&sprefix=gigabyte%2Caps%2C190&sr=1-8",
                   Price = 879.00M,
                   PriceUnit = "$",
                   CatrgoryID = 8

               },
               new Product
               {
                   Name = "HP",
                   //CreationDate = DateTime.Now,
                   CreatedBy = "admin",
                   Id = 7,
                   StoreId = 3,
                   Url = "https://www.bestbuy.ca/en-ca/product/custom-gigabyte-aorus-15-laptop-intel-i7-12700h-32gb-ram-4tb-pcie-ssd-nvidia-rtx-3070-ti-15-6-win-10-pro/15997948",
                   Price = 7287.15M,
                   PriceUnit = "$",
                   CatrgoryID = 8

               });
        }
    }
}
