using AutoMapper;
using MediatR;
using TimeLogger.Application.Features.RoomBookings.Dtos;
using TimeLogger.Application.IRepositories;

namespace TimeLogger.Application.Features.RoomBookings.Queries
{
    public class GetRoomBookingsHandler : IRequestHandler<GetRoomBookings, IEnumerable<RoomBookingsDto>>
    {
        private readonly IRoomBookingRepository _roomBookingRepository;
        private readonly IMapper _mapper;

        public GetRoomBookingsHandler(IRoomBookingRepository roomBookingRepository, IMapper mapper)
        {
            _roomBookingRepository = roomBookingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomBookingsDto>> Handle(GetRoomBookings request, CancellationToken cancellationToken)
        {
            // Fetch room bookings by RoomId
            var roomBookings = await _roomBookingRepository.GetRoomBookingByRoomId(request.RoomId);

            // Map entities to DTOs
            var roomBookingDetailsDtos = _mapper.Map<IEnumerable<RoomBookingsDto>>(roomBookings);

            return roomBookingDetailsDtos;
        }
    }
}
