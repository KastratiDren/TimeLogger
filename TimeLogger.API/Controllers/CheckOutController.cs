using TimeLogger.Application.Features.Checkouts.Commands;
using TimeLogger.Application.Features.Checkouts.Dtos;
using TimeLogger.Application.Features.Checkouts.Queries;

namespace TimeLogger.API.Controllers
{
    [Route("api/checkouts")]
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CheckOutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut([FromBody] CheckOutDto checkOutDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new UserCheckOut(checkOutDto);
            var result = await _mediator.Send(command);

            if (!result)
                return BadRequest(new { Message = "Check-out failed." });

            return Ok(new { Message = "Check-out successful." });
        }

        [HttpGet("{userId}/average-checkout-time")]
        public async Task<IActionResult> GetAverageUserCheckOutTime(string userId)
        {
            var query = new GetUserAverageCheckOutTime(userId);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound(new { Message = "No check-outs found for the specified user." });

            var formattedResult = result.Value.ToString(@"hh\:mm");

            return Ok(new { AverageCheckOutTime = formattedResult });
        }
    }
}
