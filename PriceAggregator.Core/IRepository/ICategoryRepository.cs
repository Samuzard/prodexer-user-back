using System.Linq.Expressions;
using PriceAggregator.Core.Entities;

namespace PriceAggregator.Core.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
    Task<IEnumerable<Category>> GetCategories(Expression<Func<Category, bool>> filter = null, bool isTracked = true);
}