using Microsoft.AspNetCore.Authorization;
using TimeLogger.Application.Features.Checkins.Commands;
using TimeLogger.Application.Features.Checkins.Dto;
using TimeLogger.Application.Features.Checkins.Queries;

namespace TimeLogger.API.Controllers
{
    [Route("api/checkins")]
    [ApiController]
    public class CheckInController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CheckInController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CheckIn([FromBody] CheckInDto checkInDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new UserCheckIn(checkInDto);
            var result = await _mediator.Send(command);

            if (!result)
                return BadRequest(new { Message = "Check-in failed." });

            return Ok(new { Message = "Check-in successful." });
        }

        [HttpGet("{userId}/average-checkin-time")]
        [Authorize]
        public async Task<IActionResult> GetUserAverageCheckInTime(string userId)
        {
            var query = new GetUserAverageCheckInTime(userId);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound(new { Message = "No check-ins found for the specified user." });

            var formattedResult = result.Value.ToString(@"hh\:mm");

            return Ok(new { AverageCheckInTime = formattedResult });
        }
    }
}
