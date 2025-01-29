namespace TimeLogger.Application.Features.Attendances.Queries
{
    public class GetWeeklyWorkDurationHandler : IRequestHandler<GetWeeklyWorkDuration, TimeSpan?>
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public GetWeeklyWorkDurationHandler(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<TimeSpan?> Handle(GetWeeklyWorkDuration request, CancellationToken cancellationToken)
        {
            var today = DateTime.Today.AddDays(1);
            var startOfWeek = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);

            return await _attendanceRepository.GetTotalWorkDurationByUserId(request.UserId, startOfWeek, today);
        }
    }
}
