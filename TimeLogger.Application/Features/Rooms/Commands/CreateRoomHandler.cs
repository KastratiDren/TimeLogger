using TimeLogger.Application.Features.Rooms.Dtos;

namespace TimeLogger.Application.Features.Rooms.Commands
{
    public class CreateRoomHandler : IRequestHandler<CreateRoom, RoomDto>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public CreateRoomHandler(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<RoomDto> Handle(CreateRoom request, CancellationToken cancellationToken)
        {
            var room = _mapper.Map<Room>(request.RoomDto);

            await _roomRepository.CreateRoom(room);

            var responseDto = _mapper.Map<RoomDto>(room);

            return responseDto;
        }
    }
}
