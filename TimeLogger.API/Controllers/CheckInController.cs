using MediatR;
using Microsoft.AspNetCore.Mvc;
using TimeLogger.Application.Features.Checkins.Commands;
using TimeLogger.Application.Features.Checkins.Dto;
using TimeLogger.Application.Features.Checkins.Queries;

namespace TimeLogger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckInController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CheckInController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Checkin")]
        public async Task<IActionResult> Checkin(CheckInDto checkInDto)
        {
            var command = new UserCheckIn(checkInDto);
            var result = await _mediator.Send(command);

            if(result == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("AverageCheckInTime/{userId}")]
        public async Task<IActionResult> GetUserAverageCheckInTime(string userId)
        {
            var query = new GetUserAverageCheckInTime(userId);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound("No check-ins found for the user.");

            // Format the TimeSpan to include only hours and minutes
            var formattedResult = result.Value.ToString(@"hh\:mm");

            return Ok(formattedResult);
        }

    }
}
