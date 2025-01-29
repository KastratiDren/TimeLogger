using TimeLogger.Application.Features.Rooms.Dtos;

namespace TimeLogger.Application.Features.Rooms.Commands
{
    public record CreateRoom(RoomDto RoomDto) : IRequest<RoomDto>;
}
