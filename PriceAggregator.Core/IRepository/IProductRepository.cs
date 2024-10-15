using PriceAggregator.Core.Entities;
using System.Linq.Expressions;

namespace PriceAggregator.Core.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProducts(Expression<Func<Product, bool>> filter = null, bool isTracked = true);
        Task<IEnumerable<Product>> UpdateProductWithFeatureId(int featureId, int[] productIds);
    }
}
