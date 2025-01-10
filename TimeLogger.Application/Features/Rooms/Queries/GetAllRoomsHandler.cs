using AutoMapper;
using MediatR;
using TimeLogger.Application.Features.Rooms.Dtos;
using TimeLogger.Application.IRepositories;

namespace TimeLogger.Application.Features.Rooms.Queries
{
    public class GetAllRoomsHandler : IRequestHandler<GetAllRooms, IEnumerable<RoomDto>>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public GetAllRoomsHandler(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomDto>> Handle(GetAllRooms request, CancellationToken cancellationToken)
        {
            // Fetch all rooms
            var rooms = await _roomRepository.GetAllAsync();

            // Map entities to DTOs
            var roomListDtos = _mapper.Map<IEnumerable<RoomDto>>(rooms);

            return roomListDtos;
        }
    }
}
