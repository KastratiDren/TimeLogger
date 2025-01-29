using TimeLogger.Application.Features.RoomBookings.Dtos;

namespace TimeLogger.Application.Features.RoomBookings.Queries
{
    public class GetRoomBookingsByRoomIdHandler : IRequestHandler<GetRoomBookingsByRoomId, IEnumerable<RoomBookingsDto>>
    {
        private readonly IRoomBookingRepository _roomBookingRepository;
        private readonly IMapper _mapper;

        public GetRoomBookingsByRoomIdHandler(IRoomBookingRepository roomBookingRepository, IMapper mapper)
        {
            _roomBookingRepository = roomBookingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomBookingsDto>> Handle(GetRoomBookingsByRoomId request, CancellationToken cancellationToken)
        {
            var roomBookings = await _roomBookingRepository.GetRoomBookingByRoomId(request.RoomId);

            var roomBookingDetailsDtos = _mapper.Map<IEnumerable<RoomBookingsDto>>(roomBookings);

            return roomBookingDetailsDtos;
        }
    }
}
