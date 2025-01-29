namespace TimeLogger.Application.Features.Attendances.Queries
{
    public class GetDailyWorkDurationHandler : IRequestHandler<GetDailyWorkDuration, TimeSpan?>
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public GetDailyWorkDurationHandler(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<TimeSpan?> Handle(GetDailyWorkDuration request, CancellationToken cancellationToken)
        {
            var currentDate = DateTime.Now;
            var startOfDay = currentDate.Date; 
            var endOfDay = startOfDay.AddDays(1).AddSeconds(-1); 

            var totalWorkDuration = await _attendanceRepository.GetTotalWorkDurationByUserId(request.UserId, startOfDay, endOfDay);

            return totalWorkDuration;
        }
    }
}
