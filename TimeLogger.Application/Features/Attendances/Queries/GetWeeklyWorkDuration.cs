namespace TimeLogger.Application.Features.Attendances.Queries
{
    public record GetWeeklyWorkDuration(string UserId) : IRequest<TimeSpan?>;
}
