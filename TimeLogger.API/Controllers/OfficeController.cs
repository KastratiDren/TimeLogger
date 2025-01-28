using Microsoft.AspNetCore.Authorization;
using TimeLogger.Application.Features.Offices.Commands;
using TimeLogger.Application.Features.Offices.Dtos;
using TimeLogger.Application.Features.Offices.Queries;

namespace TimeLogger.API.Controllers
{
    [Route("api/offices")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfficeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateOffice([FromBody] OfficeDto officeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateOffice(officeDto);
            var responseDto = await _mediator.Send(command);

            return Ok(responseDto);
        }

        [HttpGet("{officeId}")]
        [Authorize]
        public async Task<IActionResult> GetOfficeById(int officeId)
        {
            if (officeId <= 0)
                return BadRequest(new { Message = "Invalid Office ID." });

            var query = new GetOfficeById(officeId);
            var officeDto = await _mediator.Send(query);

            if (officeDto == null)
                return NotFound(new { Message = $"Office with ID {officeId} was not found." });

            return Ok(officeDto);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllOffices()
        {
            var query = new GetAllOffices();
            var officesDto = await _mediator.Send(query);

            return Ok(officesDto);
        }
    }
}
