using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeLogger.Application.Features.RoomBookings.Commands;
using TimeLogger.Application.Features.RoomBookings.Dtos;
using TimeLogger.Application.Features.RoomBookings.Queries;

namespace TimeLogger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomBookingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomBookingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoomBookings()
        {
            var query = new GetAllRoomBookings();
            var roomBookingListDtos = await _mediator.Send(query);

            return Ok(roomBookingListDtos);
        }

        [HttpGet("GetRoomBookingsByRoomId/{roomId}")]
        public async Task<IActionResult> GetRoomBookingsByRoomId(int roomId)
        {
            if (roomId <= 0)
                return BadRequest("Invalid Room Id");

            var query = new GetRoomBookings(roomId);
            var roomBookingDetailsDtos = await _mediator.Send(query);

            if (roomBookingDetailsDtos == null || !roomBookingDetailsDtos.Any())
                return NotFound($"No bookings found for Room with Id {roomId}.");

            return Ok(roomBookingDetailsDtos);
        }

        [HttpPost("CreateRoomBooking")]
        public async Task<IActionResult> CreateRoomBooking([FromBody] RoomBookingsDto roomBookingsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateRoomBooking(roomBookingsDto);
            var success = await _mediator.Send(command);

            if (!success)
                return BadRequest("Room booking could not be created.");

            return Ok("Room booking created successfully.");
        }


    }
}
