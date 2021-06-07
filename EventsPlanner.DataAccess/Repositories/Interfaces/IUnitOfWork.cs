using System.Threading;
using System.Threading.Tasks;

namespace EventsPlanner.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
