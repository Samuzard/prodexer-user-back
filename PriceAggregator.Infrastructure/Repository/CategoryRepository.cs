using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PriceAggregator.Core.Entities;
using PriceAggregator.Core.IRepository;

namespace PriceAggregator.Infrastructure.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Category>> GetCategories(Expression<Func<Category, bool>> filter = null, bool isTracked = true)
    {
        var query = _dbContext.Categories.AsQueryable();
        
        if(filter != null)
            query = query.Where(filter);

        if (!isTracked)
            query = query.AsNoTracking();
        
        return await query.ToListAsync();
    }
}