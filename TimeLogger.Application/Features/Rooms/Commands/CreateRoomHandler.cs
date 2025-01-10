using AutoMapper;
using MediatR;
using TimeLogger.Application.Features.Rooms.Dtos;
using TimeLogger.Application.IRepositories;
using TimeLogger.Domain.Entites;

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
            // Map DTO to Entity
            var room = _mapper.Map<Room>(request.RoomDto);

            // Add to repository
            await _roomRepository.AddAsync(room);

            // Map Entity back to DTO
            var responseDto = _mapper.Map<RoomDto>(room);

            return responseDto;
        }
    }
}
