using Microsoft.AspNetCore.Authorization;
using TimeLogger.Application.Features.RoomBookings.Commands;
using TimeLogger.Application.Features.RoomBookings.Dtos;
using TimeLogger.Application.Features.RoomBookings.Queries;

namespace TimeLogger.API.Controllers
{
    [Route("api/room-bookings")]
    [ApiController]
    public class RoomBookingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomBookingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllRoomBookings()
        {
            var query = new GetAllRoomBookings();
            var roomBookingListDtos = await _mediator.Send(query);

            if (roomBookingListDtos == null || !roomBookingListDtos.Any())
                return NotFound(new { Message = "No room bookings found." });

            return Ok(roomBookingListDtos);
        }

        [HttpGet("room/{roomId}")]
        [Authorize]
        public async Task<IActionResult> GetRoomBookingsByRoomId(int roomId)
        {
            if (roomId <= 0)
                return BadRequest(new { Message = "Invalid Room ID." });

            var query = new GetRoomBookings(roomId);
            var roomBookingDetailsDtos = await _mediator.Send(query);

            if (roomBookingDetailsDtos == null || !roomBookingDetailsDtos.Any())
                return NotFound(new { Message = $"No bookings found for the room with ID {roomId}." });

            return Ok(roomBookingDetailsDtos);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateRoomBooking([FromBody] RoomBookingsDto roomBookingsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateRoomBooking(roomBookingsDto);
            var success = await _mediator.Send(command);

            if (!success)
                return BadRequest(new { Message = "Room booking could not be created." });

            return Ok(new { Message = "Room booking created successfully." });
        }
    }
}
