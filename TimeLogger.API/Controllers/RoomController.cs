using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeLogger.Application.Features.Rooms.Commands;
using TimeLogger.Application.Features.Rooms.Dtos;
using TimeLogger.Application.Features.Rooms.Queries;

namespace TimeLogger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateRoom")]
        public async Task<IActionResult> CreateRoom([FromBody] RoomDto roomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateRoom(roomDto);
            var responseDto = await _mediator.Send(command);

            return Ok(responseDto);
        }

        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetRoomById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Room Id");

            var query = new GetRoomById(id);
            var roomDetailsDto = await _mediator.Send(query);

            if (roomDetailsDto == null)
                return NotFound($"Room with Id {id} was not found.");

            return Ok(roomDetailsDto);
        }

    }
}
