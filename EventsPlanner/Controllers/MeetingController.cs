using EventsPlanner.BusinessLogic.Services.Interfaces;
using EventsPlanner.Domain.Models;
using EventsPlanner.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsPlanner.Controllers
{
    [Route("api/meetings")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService _meetingService;
        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpPost]
        public async Task<ActionResult<Meeting>> CreateMeeting([FromBody] PostMeetingDto meetingDto)
        {
            var insertedMeeting = await _meetingService.CreateMeetingAsync(meetingDto.Name, meetingDto.Time, meetingDto.Description);
            return insertedMeeting;
        }

        [HttpDelete("{id:int}")]
        public async Task DeleteEmployee(int id)
        {
             await _meetingService.DeleteMeetingAsync(id);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meeting>>> GetMeetings()
        {
            var result = await _meetingService.GetMeetingsAsync();
            return Ok(result);
        }
        [HttpGet("coming")]
        public async Task<ActionResult<IEnumerable<Meeting>>> GetFutureMeetings()
        {
            var result = await _meetingService.GetFutureMeetingsAsync();
            return Ok(result);
        }
        [HttpPost("{meetingId}")]
        public async Task<ActionResult> AddUserToMeeting([FromBody] PostUserDto userDto, int meetingId)
        {
            await _meetingService.AddUserToMeetingAsync(meetingId, userDto.Name, userDto.Email);
            return Ok();
        }
    }

}
