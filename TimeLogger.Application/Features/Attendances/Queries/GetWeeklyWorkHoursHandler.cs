using MediatR;
using TimeLogger.Application.IRepositories;

namespace TimeLogger.Application.Features.Attendances.Queries
{
    public class GetWeeklyWorkHoursHandler : IRequestHandler<GetWeeklyWorkHours, TimeSpan>
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public GetWeeklyWorkHoursHandler(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<TimeSpan> Handle(GetWeeklyWorkHours request, CancellationToken cancellationToken)
        {
            var today = DateTime.Today.AddDays(1);
            var startOfWeek = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);

            return await _attendanceRepository.GetTotalWorkDurationByUserId(request.UserId, startOfWeek, today);
        }
    }
}
