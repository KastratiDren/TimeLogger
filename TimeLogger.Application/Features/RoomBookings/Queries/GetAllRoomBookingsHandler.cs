using AutoMapper;
using MediatR;
using TimeLogger.Application.Features.RoomBookings.Dtos;
using TimeLogger.Application.IRepositories;

namespace TimeLogger.Application.Features.RoomBookings.Queries
{
    public class GetAllRoomBookingsHandler : IRequestHandler<GetAllRoomBookings, IEnumerable<RoomBookingsDto>>
    {
        private readonly IRoomBookingRepository _roomBookingRepository;
        private readonly IMapper _mapper;

        public GetAllRoomBookingsHandler(IRoomBookingRepository roomBookingRepository, IMapper mapper)
        {
            _roomBookingRepository = roomBookingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomBookingsDto>> Handle(GetAllRoomBookings request, CancellationToken cancellationToken)
        {
            var roomBookings = await _roomBookingRepository.GetAllRoomBookings();

            var roomBookingListDtos = _mapper.Map<IEnumerable<RoomBookingsDto>>(roomBookings);

            return roomBookingListDtos;
        }
    }
}
