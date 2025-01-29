namespace TimeLogger.Application.Features.Attendances.Queries
{
    public record GetDailyWorkDuration(string UserId) : IRequest<TimeSpan?>;
}
