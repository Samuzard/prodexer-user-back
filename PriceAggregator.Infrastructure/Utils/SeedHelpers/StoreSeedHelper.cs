using Microsoft.EntityFrameworkCore;
using PriceAggregator.Core.Entities;

namespace PriceAggregator.Infrastructure.Utils.SeedHelpers;

public static class StoreSeedHelper
{
    public static void SeedStores(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Store>()
            .HasData(new Store
                {
                    //CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 1,
                    Name = "Amazon",
                    IconPath = "/images/store_icons/amazon_logo.png"
                },
                new Store
                {
                    //CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 2,
                    Name = "Stirling Sports",
                    IconPath = "/images/store_icons/stirling_sports.png"
                },
                new Store
                {
                    //CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 3,
                    Name = "BestBuy",
                    IconPath = "/images/store_icons/best_buy_logo.png"
                },
                new Store
                {
                    //CreationDate = DateTime.Now,
                    CreatedBy = "admin",
                    Id = 4,
                    Name = "AliExpress",
                    IconPath = "/images/store_icons/ali_express_logo.png"
                }
            );
    }
}