using TimeLogger.Application.Features.Rooms.Commands;
using TimeLogger.Application.Features.Rooms.Dtos;
using TimeLogger.Application.Features.Rooms.Queries;

namespace TimeLogger.API.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] RoomDto roomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateRoom(roomDto);
            var responseDto = await _mediator.Send(command);

            return Ok(responseDto);
        }

        [HttpGet("{roomId}")]
        public async Task<IActionResult> GetRoomById(int roomId)
        {
            if (roomId <= 0)
                return BadRequest(new { Message = "Invalid Room ID." });

            var query = new GetRoomById(roomId);
            var roomDetailsDto = await _mediator.Send(query);

            if (roomDetailsDto == null)
                return NotFound(new { Message = $"Room with ID {roomId} was not found." });

            return Ok(roomDetailsDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var query = new GetAllRooms();
            var roomListDtos = await _mediator.Send(query);

            return Ok(roomListDtos);
        }
    }
}
