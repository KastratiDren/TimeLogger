using Microsoft.AspNetCore.Authorization;
using TimeLogger.Application.Features.Attendances.Queries;

namespace TimeLogger.API.Controllers
{
    [Route("api/attendances")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttendanceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("user/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetAttendanceByUserId(string userId)
        {
            var query = new GetAttendanceByUserId(userId);
            var result = await _mediator.Send(query);

            if (result == null || result.Count == 0)
            {
                return NotFound(new { Message = "No attendance records found for the specified user." });
            }

            return Ok(result);
        }

        [HttpGet("date/{date}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAttendanceByDate(DateOnly date)
        {
            var query = new GetAttendanceByDate(date);
            var result = await _mediator.Send(query);

            if (result == null || result.Count == 0)
            {
                return NotFound(new { Message = "No attendance records found for the specified date." });
            }

            return Ok(result);
        }

        [HttpGet("{userId}/daily-work-duration")]
        [Authorize]
        public async Task<IActionResult> GetDailyWorkDuration(string userId)
        {
            var query = new GetDailyWorkHours(userId);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound(new { Message = "User hasn't logged in any office today." });

            var formattedResult = result.Value.ToString(@"hh\:mm");

            return Ok(new { DailyWorkDuration = formattedResult });
        }

        [HttpGet("{userId}/weekly-work-duration")]
        [Authorize]
        public async Task<IActionResult> GetWeeklyWorkDuration(string userId)
        {
            var query = new GetWeeklyWorkHours(userId);
            var result = await _mediator.Send(query);

            if (result == TimeSpan.Zero)
            {
                return NotFound(new { Message = "No work hours found for the specified user this week." });
            }

            var formattedResult = result.ToString(@"hh\:mm");

            return Ok(new { WeeklyWorkDuration = formattedResult });
        }

        [HttpGet("{userId}/monthly-work-duration")]
        [Authorize]
        public async Task<IActionResult> GetMonthlyWorkDuration(string userId)
        {
            var query = new GetMonthlyWorkDuration(userId);
            var result = await _mediator.Send(query);

            if (result == TimeSpan.Zero)
            {
                return NotFound(new { Message = "User hasn't logged any office this month." });
            }

            var formattedResult = result.ToString(@"hh\:mm");

            return Ok(new { MonthlyWorkDuration = formattedResult });
        }
    }
}
