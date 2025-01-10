using MediatR;
using TimeLogger.Application.Features.Rooms.Dtos;

namespace TimeLogger.Application.Features.Rooms.Queries
{
    public record GetAllRooms : IRequest<IEnumerable<RoomDto>>;
}
