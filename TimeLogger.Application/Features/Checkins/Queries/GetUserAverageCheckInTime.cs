using MediatR;

namespace TimeLogger.Application.Features.Checkins.Queries
{
    public record GetUserAverageCheckInTime(string userId) : IRequest<TimeSpan?>;
}
