using TimeLogger.Application.Features.RoomBookings.Dtos;

namespace TimeLogger.Application.Features.RoomBookings.Queries
{
    public record GetAllRoomBookings : IRequest<IEnumerable<RoomBookingsDto>>;
}
