using TimeLogger.Application.Features.RoomBookings.Dtos;

namespace TimeLogger.Application.Features.RoomBookings.Queries
{
    public record GetRoomBookingsByRoomId(int RoomId) : IRequest<IEnumerable<RoomBookingsDto>>;
}
