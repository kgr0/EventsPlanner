using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsPlanner.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T, TKey> where T : Domain.Interfaces.IEntity<TKey>
    {
        IUnitOfWork UnitOfWork { get; }
        Task<T> GetByIdAsync(TKey id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> InsertAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);

    }

}
