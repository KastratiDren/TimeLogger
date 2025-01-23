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
            var startOfDay = currentDate.Date; 
            var endOfDay = startOfDay.AddDays(1).AddSeconds(-1); 

            var totalWorkDuration = await _attendanceRepository.GetTotalWorkDurationByUserId(request.UserId, startOfDay, endOfDay);

            return totalWorkDuration;
        }
    }
}
