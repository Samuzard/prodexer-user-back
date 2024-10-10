using Microsoft.EntityFrameworkCore;
using PriceAggregator.Core.Entities;
using PriceAggregator.Core.IRepository;

namespace PriceAggregator.Infrastructure.Repository;

public class FeatureRepository(ApplicationDbContext dbContext) : Repository<Feature>(dbContext), IFeatureRepository
{
    public async Task<Feature> AddFeature(IEnumerable<int> productIds, string name)
    {
        var feature = new Feature();

        var products = await DbContext.Product
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync();

        feature.Name = name;
        feature.Products = products;

        await DbContext.Feature.AddAsync(feature);

        await DbContext.SaveChangesAsync();

        return feature;
    }
}