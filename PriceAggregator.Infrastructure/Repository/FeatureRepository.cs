using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PriceAggregator.Core.Entities;
using PriceAggregator.Core.IRepository;

namespace PriceAggregator.Infrastructure.Repository;

public class FeatureRepository(ApplicationDbContext dbContext) : Repository<Feature>(dbContext), IFeatureRepository
{
    public async Task<IEnumerable<Feature>> GetFeatures(Expression<Func<Feature, bool>> filter, bool isTracked = true)
    {
        IQueryable<Feature> query = DbContext.Feature; 
         
        query = query.Include(p=>p.Products)
                .ThenInclude(s=>s.Store)
            .Include(p=>p.Products)
                .ThenInclude(c => c.Category);

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (!isTracked)
            query = query.AsNoTracking();
        
        return await query.ToListAsync();
    }
    
    public async Task<Feature> AddFeatureWithProducts(int[] productIds, string name)
    {
        var feature = new Feature();

        var products = await DbContext.Product
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync();
    
        feature.Name = name;
        feature.Products = products;
    
        await DbContext.Feature.AddAsync(feature);

        await SaveAsync();

        return feature;
    }
    
    public async Task<bool> DeleteFeature(int featureId)
    {
        var feature = await GetAsync(f => f.Id == featureId);
        if (feature == null)
            return false;

        var associatedProducts = await DbContext.Product
            .Where(p => p.FeatureId == featureId)
            .ToListAsync();

        foreach (var product in associatedProducts)
        {
            product.FeatureId = null;
        }

        DbContext.Feature.Remove(feature);

        await SaveAsync();

        return true;
    }

    public async Task<Feature> UpdateFeatureWithProducts(int featureId, string name, int[] productIds)
    {
        var feature = await DbContext.Feature
            .Include(f => f.Products)
            .FirstOrDefaultAsync(f => f.Id == featureId);

        if (feature == null)
            return null;

        feature.Products.Clear();
        
        var products = await DbContext.Product
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync();
        
        if (!string.IsNullOrEmpty(name))
        {
            feature.Name = name;
        }
        
        feature.Products = products;
        
        await SaveAsync();

        return feature;
    }
}