using TimeLogger.Application.Features.Authentication.Commands;
using TimeLogger.Application.Features.Authentication.Dtos;

namespace TimeLogger.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new RegisterUser(registerDto);
            var userDto = await _mediator.Send(command);

            return Ok(new { Message = "User registered successfully.", User = userDto });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new LoginUser(loginDto);
            var userDto = await _mediator.Send(command);

            if (userDto == null)
                return Unauthorized(new { Message = "Invalid login credentials." });

            return Ok(new { Message = "Login successful.", User = userDto });
        }
    }
}
