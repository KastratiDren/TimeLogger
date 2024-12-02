using MediatR;
using Microsoft.AspNetCore.Mvc;
using TimeLogger.Application.Features.Offices.Commands;
using TimeLogger.Application.Features.Offices.Dtos;
using TimeLogger.Application.Features.Offices.Queries;

namespace TimeLogger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfficeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateOffice")]
        public async Task<IActionResult> CreateOffice([FromBody] OfficeDto officeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateOffice(officeDto);
            var responseDto = await _mediator.Send(command);

            return Ok(responseDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfficeById(int id)
        {
            var query = new GetOfficeById(id);
            var officeDto = await _mediator.Send(query);

            if (officeDto == null)
                return NotFound();

            return Ok(officeDto);
        }

    }
}
