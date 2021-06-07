using EventsPlanner.BusinessLogic.Exceptions;
using EventsPlanner.BusinessLogic.Services.Interfaces;
using EventsPlanner.DataAccess.Repositories.Interfaces;
using EventsPlanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlanner.BusinessLogic.Services.Implementations
{
    public class MeetingService : IMeetingService
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IUserRepository _userRepository;

        public MeetingService(IMeetingRepository meetingRepository, IUserRepository userRepository)
        {
            _meetingRepository = meetingRepository;
            _userRepository = userRepository;
        }
        public async Task<Meeting> CreateMeetingAsync(string name, DateTime time, string description)
        {
            var meeting = new Meeting
            {
                Name = name,
                Time = time,
                Description = description
            };
            var insertedMeeting = await _meetingRepository.InsertAsync(meeting);
            await _meetingRepository.UnitOfWork.SaveChangesAsync();
            return insertedMeeting;
        }
        public async Task DeleteMeetingAsync(int id)
        {
            try
            {
                var meetingToDelete = await _meetingRepository.GetByIdAsync(id);

                if (meetingToDelete == null)
                {
                    throw new MeetingNotFoundException(id);
                }
                if (! (meetingToDelete.Users is null))
                {
                    foreach (var u in meetingToDelete.Users)
                    {
                        var userToDelete = await _userRepository.GetByIdAsync(u.Id);
                        await _userRepository.DeleteAsync(userToDelete);
                        await _userRepository.UnitOfWork.SaveChangesAsync();
                    }
                }
                await _meetingRepository.DeleteAsync(meetingToDelete);
                await _meetingRepository.UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting data", ex);
            }
        }
        public async Task<IEnumerable<Meeting>> GetMeetingsAsync()
        {
            var meeetings = await _meetingRepository.GetAllAsync();
            return meeetings;
        }
        public async Task<IEnumerable<Meeting>> GetFutureMeetingsAsync()
        {
            var meeetings = await _meetingRepository.GetAllAsync();
            return meeetings.Where(x => x.Time >= DateTime.Now);
        }
        public async Task AddUserToMeetingAsync(int meetingId, string userName, string userEmail)
        {
            var meeting = await _meetingRepository.GetByIdAsync(meetingId);
            var user = new User
            {
                Name = userName,
                Email = userEmail
            };
            if (meeting.Users is null)
            {
                meeting.Users = new List<User>
                {
                   user
                };
            }
            else if(meeting.Users.Count < 25)
            {
                meeting.Users.Add(user);
            }
            else
            {
                throw new LimitOfParticipantsException();
            }
            
            await _meetingRepository.UpdateAsync(meeting);
            await _meetingRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}
