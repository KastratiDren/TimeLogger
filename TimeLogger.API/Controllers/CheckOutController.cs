using MediatR;
using Microsoft.AspNetCore.Mvc;
using TimeLogger.Application.Features.Checkouts.Commands;
using TimeLogger.Application.Features.Checkouts.Dtos;

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
    }
}
