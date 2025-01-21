using AutoMapper;
using MediatR;
using TimeLogger.Application.IRepositories;
using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.Features.Checkouts.Commands
{
    public class UserCheckOutHandler : IRequestHandler<UserCheckOut, bool>
    {
        private readonly ICheckInRepository _checkInRepository;
        private readonly ICheckOutRepository _checkOutRepository;
        private readonly IMapper _mapper;

        public UserCheckOutHandler(
            ICheckInRepository checkInRepository,
            ICheckOutRepository checkOutRepository,
            IMapper mapper)
        {
            _checkInRepository = checkInRepository;
            _checkOutRepository = checkOutRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UserCheckOut request, CancellationToken cancellationToken)
        {
            var today = DateTime.Today;
            var userId = request.CheckOutDto.UserId;
            var officeId = request.CheckOutDto.OfficeId;

            var todayCheckInForOffice = (await _checkInRepository.GetCheckInsByUserId(userId))
                .FirstOrDefault(c => c.CheckInTime.Date == today && c.OfficeId == officeId);

            if (todayCheckInForOffice == null)
                return false; 

            var todayCheckOutForOffice = (await _checkOutRepository.GetByUserIdAsync(userId))
                .FirstOrDefault(c => c.CheckOutTime.Date == today && c.OfficeId == officeId);

            if (todayCheckOutForOffice != null)
                return false;

            var checkOut = _mapper.Map<CheckOut>(request.CheckOutDto);
            checkOut.CheckOutTime = DateTime.Now;

            await _checkOutRepository.AddAsync(checkOut);
            return true;
        }

    }
}
