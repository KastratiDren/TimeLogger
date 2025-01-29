namespace TimeLogger.Application.Features.Attendances.Queries
{
    public record GetAttendanceByUserId(string userId) : IRequest<List<Attendance>>;
}
