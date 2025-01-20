using MediatR;

namespace TimeLogger.Application.Features.Attendances.Queries
{
    public record GetDailyWorkHours(string UserId) : IRequest<TimeSpan?>;
}
