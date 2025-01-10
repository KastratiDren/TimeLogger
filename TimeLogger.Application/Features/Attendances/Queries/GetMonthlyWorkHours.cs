using MediatR;

namespace TimeLogger.Application.Features.Attendances.Queries
{
    public record GetMonthlyWorkHours(string UserId) : IRequest<TimeSpan>;
}
