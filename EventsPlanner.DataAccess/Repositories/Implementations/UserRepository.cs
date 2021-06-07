using EventsPlanner.DataAccess.Context;
using EventsPlanner.DataAccess.Repositories.Interfaces;
using EventsPlanner.Domain.Models;

namespace EventsPlanner.DataAccess.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User, int, EventsPlannerContext>, IUserRepository
    {
        public UserRepository(EventsPlannerContext context) : base(context)
        {

        }
    }
}
