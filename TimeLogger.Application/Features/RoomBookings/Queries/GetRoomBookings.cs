using MediatR;
using TimeLogger.Application.Features.RoomBookings.Dtos;

namespace TimeLogger.Application.Features.RoomBookings.Queries
{
    public record GetRoomBookings(int RoomId) : IRequest<IEnumerable<RoomBookingsDto>>;
}
