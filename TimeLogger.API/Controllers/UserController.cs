using TimeLogger.Application.Features.Users.Commands;
using TimeLogger.Application.Features.Users.Queries;

namespace TimeLogger.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetAllUsers();
            var usersDtos = await _mediator.Send(query);

            if (usersDtos == null || !usersDtos.Any())
                return NotFound(new { Message = "No users found." });

            return Ok(usersDtos);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var query = new GetUserById(id);
            var userDto = await _mediator.Send(query);

            if (userDto == null)
                return NotFound(new { Message = $"User with ID {id} not found." });

            return Ok(userDto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var command = new DeleteUser(id);
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound(new { Message = $"User with ID {id} not found or could not be deleted." });

            return Ok(new { Message = "User deleted successfully." });
        }
    }
}
