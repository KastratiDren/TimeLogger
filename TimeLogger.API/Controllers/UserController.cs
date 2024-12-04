using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeLogger.Application.Features.Users.Commands;
using TimeLogger.Application.Features.Users.Queries;

namespace TimeLogger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetAllUsers();
            var usersDtos = await _mediator.Send(query);

            if(usersDtos == null)
                return NotFound();

            return Ok(usersDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var query = new GetUserById(id);
            var userDto = await _mediator.Send(query);

            if(userDto == null)
                return NotFound();

            return Ok(userDto); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var command = new DeleteUser(id);
            var result = await _mediator.Send(command);

            if(result == false)
                return NotFound();

            return Ok(result);
        }
    }
}
