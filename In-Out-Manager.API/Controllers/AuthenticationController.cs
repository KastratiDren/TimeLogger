using In_Out_Manager.Application.Features.Authentication.Commands;
using In_Out_Manager.Application.Features.Authentication.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace In_Out_Manager.API.Controllers
{
    [Route("api/[controller]")]
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
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new RegisterUser(registerDto);
            var userDto = await _mediator.Send(command);

            return Ok(userDto);
        }
    }
}
