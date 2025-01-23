using MediatR;
using TimeLogger.Application.IRepositories;

namespace TimeLogger.Application.Features.Attendances.Queries
{
    public record GetMonthlyWorkDuration(string UserId) : IRequest<TimeSpan>;

    public class GetMonthlyWorkDurationHandler : IRequestHandler<GetMonthlyWorkDuration, TimeSpan>
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public GetMonthlyWorkDurationHandler(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<TimeSpan> Handle(GetMonthlyWorkDuration request, CancellationToken cancellationToken)
        {
            var currentDate = DateTime.Now;
            var startOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            var totalWorkDuration = await _attendanceRepository.GetTotalWorkDurationByUserId(request.UserId, startOfMonth, endOfMonth);

            return totalWorkDuration;
        }
    }
}
