using Microsoft.EntityFrameworkCore;
using PricAggregatorAPI.Data;
using PricAggregatorAPI.Data.Repository;
using PricAggregatorAPI.Models;
using PriceAggregatorAPI.Data.Repository.IRepository;
using System.Linq.Expressions;

namespace PriceAggregatorAPI.Data
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProducts(Expression<Func<Product, bool>> filter = null)
        {
            IQueryable<Product> query = DbContext.Product;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var result = await query.Include(x=>x.MainProduct).ToListAsync();

            return result;
        }
    }
}
