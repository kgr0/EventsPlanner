using Microsoft.EntityFrameworkCore;
using EventsPlanner.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsPlanner.DataAccess.Repositories.Implementations
{
    public class BaseRepository<T, TKey, TContext> : IRepository<T, TKey>
        where T : class, Domain.Interfaces.IEntity<TKey>
        where TContext : DbContext, IUnitOfWork
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly TContext _context;

        public BaseRepository(TContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;
        public async Task<T> GetByIdAsync(TKey id)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return result;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public Task<T> InsertAsync(T item)
        {
            var entity = _dbSet.Add(item);
            return Task.FromResult(entity.Entity);
        }

        public Task UpdateAsync(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(T item)
        {
            var result = await _dbSet
                .FirstOrDefaultAsync(e => e.Id.Equals(item.Id));
            if (result != null)
            {
                _dbSet.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }

}
