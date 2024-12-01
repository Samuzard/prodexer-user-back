using Microsoft.EntityFrameworkCore;
using PriceAggregator.Core.Entities;

namespace PriceAggregator.Infrastructure.Utils.SeedHelpers;

public static class CategorySeedHelper
{
    public static void SeedCategories(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasData(new Category
                {
                    //CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 1,
                    Name = "Shoes",
                    TreeLevel = 0,
                    IconPath = "/images/category_icons/scissors.svg",
                    IconAlt = "Scissors icon"
                },
                new Category
                {
                    //CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 2,
                    Name = "Women's Shoes",
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
                    Name = "Women's Shirts",
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
                },
                new Category
                {
                    //CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 9,
                    Name = "Smartphones"
                }
            );
    }
}