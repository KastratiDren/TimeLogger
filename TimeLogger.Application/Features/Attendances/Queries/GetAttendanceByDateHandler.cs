using MediatR;
using TimeLogger.Application.IRepositories;
using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.Features.Attendances.Queries
{
    public class GetAttendanceByDateHandler : IRequestHandler<GetAttendanceByDate, List<Attendance>>
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public GetAttendanceByDateHandler(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<List<Attendance>> Handle(GetAttendanceByDate request, CancellationToken cancellationToken)
        {
            var dateTime = request.date.ToDateTime(TimeOnly.MinValue);
            return await _attendanceRepository.GetAttendancesByDate(dateTime);
        }
    }
}
