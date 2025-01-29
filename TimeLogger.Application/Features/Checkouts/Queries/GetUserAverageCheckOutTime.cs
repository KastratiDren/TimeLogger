namespace TimeLogger.Application.Features.Checkouts.Queries
{
    public record GetUserAverageCheckOutTime(string userId) : IRequest<TimeSpan?>;
}
