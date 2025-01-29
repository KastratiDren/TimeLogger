using TimeLogger.Application.Features.Rooms.Dtos;

namespace TimeLogger.Application.Features.Rooms.Queries
{
    public record GetRoomById(int Id) : IRequest<RoomDto>;
}
