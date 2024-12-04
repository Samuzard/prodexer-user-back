using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PriceAggregator.Core.Entities;
using PriceAggregator.Core.IRepository;

namespace PriceAggregator.Infrastructure.Repository;

public class FeaturedItemRepository(ApplicationDbContext dbContext) : Repository<FeaturedItem>(dbContext), IFeaturedItemRepository
{
    public async Task<IEnumerable<FeaturedItem>> GetFeaturedItems(Expression<Func<FeaturedItem, bool>> filter, bool isTracked = true)
    {
        IQueryable<FeaturedItem> query = DbContext.FeaturedItems;

        query = query
            .Include(f => f.Products.OrderBy(product => product.Price))
            .ThenInclude(p => p.Store)
            .Include(f => f.Products)
            .ThenInclude(p => p.Category)
            .Include(f => f.Stores)
            .Include(f => f.Categories);
       
        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (!isTracked)
            query = query.AsNoTracking();

        return await query.ToListAsync();
    }

    public async Task<FeaturedItem> AddFeaturedProducts(long[] productIds, string name)
    {
        var feature = new FeaturedItem();

        var products = await DbContext.Products
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync();

        feature.Name = name;
        feature.Products = products;

        await DbContext.FeaturedItems.AddAsync(feature);

        await SaveAsync();

        return feature;
    }

    public async Task<FeaturedItem> AddFeaturedCategories(long[] categoriesIds, string name)
    {
        var feature = new FeaturedItem();

        var categories = await DbContext.Categories
            .Where(p => categoriesIds.Contains(p.Id))
            .ToListAsync();

        feature.Name = name;
        feature.Categories = categories;

        await DbContext.FeaturedItems.AddAsync(feature);

        await SaveAsync();

        return feature;
    }
    
    public async Task<bool> DeleteFeaturedItem(long featureId)
    {
        var feature = await GetAsync(f => f.Id == featureId);
        if (feature == null)
            return false;

        var associatedProducts = await DbContext.Products
            .Where(p => p.FeatureId == featureId)
            .ToListAsync();

        foreach (var product in associatedProducts)
        {
            product.FeatureId = null;
        }

        DbContext.FeaturedItems.Remove(feature);

        await SaveAsync();

        return true;
    }

    public async Task<FeaturedItem> UpdateFeaturedProduct(long featureId, string name, long[] productIds)
    {
        var feature = await DbContext.FeaturedItems
            .Include(f => f.Products)
            .FirstOrDefaultAsync(f => f.Id == featureId);

        if (feature == null)
            return null;

        feature.Products.Clear();

        var products = await DbContext.Products
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