using MediatR;
using Microsoft.AspNetCore.Mvc;
using TimeLogger.Application.Features.Attendances.Queries;
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
    }
}
