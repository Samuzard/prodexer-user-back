using PriceAggregator.Core.Entities;
using System.Linq.Expressions;

namespace PriceAggregator.Core.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProducts(Expression<Func<Product, bool>> filter = null); 
    }
}
