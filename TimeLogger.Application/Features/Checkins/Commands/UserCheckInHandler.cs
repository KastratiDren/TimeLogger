using AutoMapper;
using MediatR;
using TimeLogger.Application.IRepositories;
using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.Features.Checkins.Commands
{
    public class UserCheckInHandler : IRequestHandler<UserCheckIn, bool>
    {
        private readonly ICheckInRepository _checkInRepository;
        private readonly IMapper _mapper;

        public UserCheckInHandler(ICheckInRepository checkInRepository, IMapper mapper)
        {
            _checkInRepository = checkInRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UserCheckIn request, CancellationToken cancellationToken)
        {
            var today = DateTime.Today;
            var userId = request.CheckInDto.UserId;
            var officeId = request.CheckInDto.OfficeId;

            var existingCheckIn = await _checkInRepository.GetByUserIdAsync(userId);
            if (existingCheckIn.Any(c => c.CheckInTime.Date == today && c.OfficeId == officeId))
                return false;

            var checkIn = _mapper.Map<CheckIn>(request.CheckInDto);
            checkIn.CheckInTime = DateTime.Now;

            await _checkInRepository.AddAsync(checkIn);
            return true;
        }
    }
}
