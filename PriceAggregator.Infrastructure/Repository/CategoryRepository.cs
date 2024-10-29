using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PriceAggregator.Core.Entities;
using PriceAggregator.Core.IRepository;

namespace PriceAggregator.Infrastructure.Repository;

public class CategoryRepository(ApplicationDbContext  dbContext) : Repository<Category>(dbContext), ICategoryRepository
{
    public async Task<IEnumerable<Category>> GetCategories(Expression<Func<Category, bool>> filter = null, bool isTracked = true)
    {
        var query = dbContext.Category.AsQueryable();
        
        if(filter != null)
            query = query.Where(filter);

        if (!isTracked)
            query = query.AsNoTracking();
        
        return await query.ToListAsync();
    }
}