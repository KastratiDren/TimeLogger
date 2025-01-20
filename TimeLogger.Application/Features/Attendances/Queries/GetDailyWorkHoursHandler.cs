using MediatR;
using TimeLogger.Application.IRepositories;

namespace TimeLogger.Application.Features.Attendances.Queries
{
    public class GetDailyWorkHoursHandler : IRequestHandler<GetDailyWorkHours, TimeSpan?>
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public GetDailyWorkHoursHandler(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<TimeSpan?> Handle(GetDailyWorkHours request, CancellationToken cancellationToken)
        {
            var currentDate = DateTime.Now;
            var startOfDay = currentDate.Date; // This gives you today's date at 00:00:00
            var endOfDay = startOfDay.AddDays(1).AddSeconds(-1); // This gives you today's date at 23:59:59

            // Get the total work duration for today
            var totalWorkDuration = await _attendanceRepository.GetUserTotalWorkDuration(request.UserId, startOfDay, endOfDay);

            return totalWorkDuration;
        }
    }
}
