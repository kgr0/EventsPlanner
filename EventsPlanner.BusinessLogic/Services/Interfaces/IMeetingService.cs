using EventsPlanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsPlanner.BusinessLogic.Services.Interfaces
{
    public interface IMeetingService
    {
        Task<Meeting> CreateMeetingAsync(string name, DateTime time, string description);
        Task DeleteMeetingAsync(int id);
        Task<IEnumerable<Meeting>> GetMeetingsAsync();
        Task<IEnumerable<Meeting>> GetFutureMeetingsAsync();
        Task AddUserToMeetingAsync(int meetingId, string userName, string userEmail);
    }
}
