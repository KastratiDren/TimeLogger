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
            var totalWorkDuration = await _attendanceRepository.GetMonthlyWorkDurationAsync(request.UserId);

            return totalWorkDuration;
        }
    }
}
