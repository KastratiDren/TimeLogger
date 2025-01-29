using TimeLogger.Application.Features.Rooms.Dtos;

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
            var rooms = await _roomRepository.GetAllRooms();

            var roomListDtos = _mapper.Map<IEnumerable<RoomDto>>(rooms);

            return roomListDtos;
        }
    }
}
