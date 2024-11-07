using System.Linq.Expressions;
using PriceAggregator.Core.Entities;

namespace PriceAggregator.Core.IRepository;

public interface IFeaturedItemRepository : IRepository<FeaturedItem>
{
    Task<IEnumerable<FeaturedItem>> GetFeaturedItems(Expression<Func<FeaturedItem, bool>> filter = null, bool isTracked = true);
    Task<FeaturedItem> AddFeaturedProducts(int[] productIds, string name);
    Task<bool> DeleteFeaturedItem(int id);
    Task<FeaturedItem> UpdateFeaturedProduct(int id, string name, int[] productIds);
}