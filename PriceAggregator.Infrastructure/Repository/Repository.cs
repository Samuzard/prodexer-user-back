using Microsoft.EntityFrameworkCore;
using PriceAggregator.Core.IRepository;
using System.Linq.Expressions;

namespace PriceAggregator.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        internal readonly ApplicationDbContext DbContext;
        public Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _dbSet;

            if(filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = _dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if(filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
    }
}
