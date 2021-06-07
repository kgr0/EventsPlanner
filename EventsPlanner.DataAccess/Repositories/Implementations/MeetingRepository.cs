using EventsPlanner.DataAccess.Context;
using EventsPlanner.DataAccess.Repositories.Interfaces;
using EventsPlanner.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsPlanner.DataAccess.Repositories.Implementations
{
    public class MeetingRepository : BaseRepository<Meeting, int, EventsPlannerContext>, IMeetingRepository
    {
        public MeetingRepository(EventsPlannerContext context) : base(context)
        {
        }
        public new async Task<Meeting> GetByIdAsync(int id)
        {
            var result = await _dbSet.Include(x => x.Users).FirstOrDefaultAsync(x => x.Id.Equals(id));
            return result;
        }
        public new async Task<IEnumerable<Meeting>> GetAllAsync()
        {
            var result = await _dbSet.Include(x => x.Users).ToListAsync();
            return result;
        }
    }
}
