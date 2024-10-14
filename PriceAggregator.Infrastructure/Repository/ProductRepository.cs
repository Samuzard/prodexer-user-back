using Microsoft.EntityFrameworkCore;
using PriceAggregator.Core.Entities;
using PriceAggregator.Core.IRepository;
using System.Linq.Expressions;

namespace PriceAggregator.Infrastructure.Repository
{
    public class ProductRepository(ApplicationDbContext dbContext) 
        : Repository<Product>(dbContext), IProductRepository
    {
        public async Task<IEnumerable<Product>> GetProducts(Expression<Func<Product, bool>> filter = null, bool isTracked = true)
        {
            IQueryable<Product> query = DbContext.Product;
            
            query = query.Include(p => p.Category)
                .Include(p => p.Store);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!isTracked)
                query = query.AsNoTracking();

            var result = await query.ToListAsync();

            return result;
        }
    }
}
