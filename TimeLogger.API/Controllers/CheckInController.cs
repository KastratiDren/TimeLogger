using MediatR;
using Microsoft.AspNetCore.Mvc;
using TimeLogger.Application.Features.Checkins.Commands;
using TimeLogger.Application.Features.Checkins.Dto;

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
    }
}
