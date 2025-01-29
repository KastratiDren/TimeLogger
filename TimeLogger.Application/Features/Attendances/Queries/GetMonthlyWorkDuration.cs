namespace TimeLogger.Application.Features.Attendances.Queries
{
    public record GetMonthlyWorkDuration(string UserId) : IRequest<TimeSpan?>;
}
