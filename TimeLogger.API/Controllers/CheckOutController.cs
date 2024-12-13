using MediatR;
using Microsoft.AspNetCore.Mvc;
using TimeLogger.Application.Features.Checkouts.Commands;
using TimeLogger.Application.Features.Checkouts.Dtos;
using TimeLogger.Application.Features.Checkouts.Queries;

namespace TimeLogger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CheckOutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Checkout")]
        public async Task<IActionResult> Checkout(CheckOutDto checkOutDto)
        {
            var command = new UserCheckOut(checkOutDto);
            var result = await _mediator.Send(command);

            if (result == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("AverageCheckOutTime/{userId}")]
        public async Task<IActionResult> GetUserAverageCheckOutTime(string userId)
        {
            var query = new GetUserAverageCheckOutTime(userId);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound("No check-outs found for the user.");

            // Format the TimeSpan to include only hours and minutes
            var formattedResult = result.Value.ToString(@"hh\:mm");

            return Ok(formattedResult);
        }
    }
}
