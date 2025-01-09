using MediatR;

namespace TimeLogger.Application.Features.Attendances.Queries
{
    public record GetWeeklyWorkHours(string UserId) : IRequest<TimeSpan>;
}
