using TimeLogger.Application.Features.RoomBookings.Dtos;

namespace TimeLogger.Application.Features.RoomBookings.Commands
{
    public record CreateRoomBooking(RoomBookingsDto RoomBookingsDto) : IRequest<bool>;
}
