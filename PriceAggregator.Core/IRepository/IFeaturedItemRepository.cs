using System.Linq.Expressions;
using PriceAggregator.Core.Entities;

namespace PriceAggregator.Core.IRepository;

public interface IFeaturedItemRepository : IRepository<FeaturedItem>
{
    Task<IEnumerable<FeaturedItem>> GetFeaturedItems(Expression<Func<FeaturedItem, bool>> filter = null, bool isTracked = true);
    Task<FeaturedItem> AddFeaturedProducts(long[] productIds, string name);
    Task<bool> DeleteFeaturedItem(long id);
    Task<FeaturedItem> UpdateFeaturedProduct(long id, string name, long[] productIds);
}