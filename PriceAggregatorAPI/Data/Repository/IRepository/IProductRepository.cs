using PricAggregatorAPI.Data.Repository.IRepository;
using PricAggregatorAPI.Models;
using System.Linq.Expressions;

namespace PriceAggregatorAPI.Data.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProducts(Expression<Func<Product, bool>> filter = null); 
    }
}
