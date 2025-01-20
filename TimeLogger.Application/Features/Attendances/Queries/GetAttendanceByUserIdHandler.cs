using MediatR;
using TimeLogger.Application.IRepositories;
using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.Features.Attendances.Queries
{
    public class GetAttendanceByUserIdHandler : IRequestHandler<GetAttendanceByUserId, List<Attendance>>
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public GetAttendanceByUserIdHandler(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<List<Attendance>> Handle(GetAttendanceByUserId request, CancellationToken cancellationToken)
        {
            var attendance = await _attendanceRepository.GetAttendancesByUserId(request.userId);

            return attendance;
        }
    }
}
