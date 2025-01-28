using AutoMapper;
using MediatR;
using TimeLogger.Application.Features.Rooms.Dtos;
using TimeLogger.Application.IRepositories;

namespace TimeLogger.Application.Features.Rooms.Queries
{
    public class GetRoomByIdHandler : IRequestHandler<GetRoomById, RoomDto>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public GetRoomByIdHandler(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<RoomDto?> Handle(GetRoomById request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomById(request.Id);

            if (room == null)
                return null; 

            var roomDetailsDto = _mapper.Map<RoomDto>(room);

            return roomDetailsDto;
        }
    }
}
