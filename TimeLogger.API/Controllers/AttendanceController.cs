using MediatR;
using Microsoft.AspNetCore.Mvc;
using TimeLogger.Application.Features.Attendances.Queries;
using TimeLogger.Application.Features.Attendances.Dto;
using TimeLogger.Domain.Entites;

namespace TimeLogger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttendanceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Attendance>>> GetAttendanceByUserId(string userId)
        {
            var query = new GetAttendanceByUserId(userId);

            var attendance = await _mediator.Send(query);

            if (attendance == null || attendance.Count == 0)
            {
                return NotFound(new { Message = "No attendance records found for the specified user." });
            }

            return Ok(attendance);
        }

        [HttpGet("date/{date}")]
        public async Task<ActionResult<List<Attendance>>> GetAttendanceByDate(DateOnly date)
        {
            var query = new GetAttendanceByDate(date);

            var attendance = await _mediator.Send(query);

            if (attendance == null || attendance.Count == 0)
            {
                return NotFound(new { Message = "No attendance records found for the specified date." });
            }

            return Ok(attendance);
        }

        // New Endpoint: Get daily work hours
        [HttpGet("DailyWorkHours")]
        public async Task<ActionResult<TimeSpan?>> GetDailyWorkHours([FromQuery] AttendanceDto attendanceDto)
        {
            var query = new GetDailyWorkHours(attendanceDto);

            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound(new { Message = "Unable to calculate work hours (missing CheckIn or CheckOut)." });
            }

            var formattedResult = result.Value.ToString(@"hh\:mm");

            return Ok(formattedResult);
        }

        [HttpGet("{userId}/WeeklyWorkHours")]
        public async Task<ActionResult<TimeSpan>> GetWeeklyWorkHours(string userId)
        {
            var query = new GetWeeklyWorkHours(userId);

            var result = await _mediator.Send(query);

            if (result == TimeSpan.Zero)
            {
                return NotFound(new { Message = "No work hours found for the specified user this week." });
            }

            var formattedResult = result.ToString(@"hh\:mm");

            return Ok(new { WeeklyWorkHours = formattedResult });
        }
    }
}
