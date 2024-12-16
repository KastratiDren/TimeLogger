using MediatR;
using TimeLogger.Application.IRepositories;

namespace TimeLogger.Application.Features.Attendances.Queries
{
    public class GetDailyWorkHoursHandler : IRequestHandler<GetDailyWorkHours, TimeSpan?>
    {
        private readonly ICheckInRepository _checkInRepository;
        private readonly ICheckOutRepository _checkOutRepository;

        public GetDailyWorkHoursHandler(ICheckInRepository checkInRepository, ICheckOutRepository checkOutRepository)
        {
            _checkInRepository = checkInRepository;
            _checkOutRepository = checkOutRepository;
        }

        public async Task<TimeSpan?> Handle(GetDailyWorkHours request, CancellationToken cancellationToken)
        {
            var attendanceDto = request.AttendanceDto;

            // Fetch CheckIn for the specified date and office
            var checkIn = await _checkInRepository.GetCheckinByDateAndOfficeAsync(
                attendanceDto.Date.ToDateTime(TimeOnly.MinValue),
                attendanceDto.OfficeId);

            // If there's no CheckIn, return null
            if (checkIn == null)
                return null;

            // Fetch CheckOut for the specified date and office
            var checkOut = await _checkOutRepository.GetCheckoutByDateAndOfficeAsync(
                attendanceDto.Date.ToDateTime(TimeOnly.MinValue),
                attendanceDto.OfficeId);

            // If there's no CheckOut, return null
            if (checkOut == null)
                return null;

            // Calculate the work duration
            var workDuration = checkOut.CheckOutTime - checkIn.CheckInTime;

            // Return the time worked
            return workDuration;
        }
    }
}
