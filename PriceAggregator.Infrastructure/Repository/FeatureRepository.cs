using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PriceAggregator.Core.Entities;
using PriceAggregator.Core.IRepository;

namespace PriceAggregator.Infrastructure.Repository;

public class FeatureRepository(ApplicationDbContext dbContext) : Repository<Feature>(dbContext), IFeatureRepository
{
    public async Task<Feature> GetFeatureById(int id)
    {
        return await DbContext.Feature.FindAsync(id);
    }

    public async Task<IEnumerable<Feature>> GetAllFeatures(Expression<Func<Feature, bool>> filter)
    {
        IQueryable<Feature> query = DbContext.Feature;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.ToListAsync();
    }
    
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

    public async Task<bool> DeleteFeature(int id)
    {
        var associatedProducts = await DbContext.Product
            .Where(p => p.FeatureId == id)
            .ToListAsync();

        foreach (var product in associatedProducts)
        {
            product.FeatureId = null;
        }

        var feature = await DbContext.Feature.FindAsync(id);
        if (feature == null) return false;

        DbContext.Feature.Remove(feature);

        await DbContext.SaveChangesAsync();

        return true;
    }
}