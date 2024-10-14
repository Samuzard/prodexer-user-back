using Microsoft.EntityFrameworkCore;
using PriceAggregator.Core.IRepository;
using System.Linq.Expressions;

namespace PriceAggregator.Infrastructure.Repository
{
    public class Repository<T>(ApplicationDbContext dbContext) : IRepository<T>
        where T : class
    {
        private readonly DbSet<T> _dbSet = dbContext.Set<T>();
        internal readonly ApplicationDbContext DbContext = dbContext;

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _dbSet;

            if(filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool isTracked = true)
        {
            IQueryable<T> query = _dbSet;

            if(filter != null)
            {
                query = query.Where(filter);
            }

            if (!isTracked)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
    }
}
