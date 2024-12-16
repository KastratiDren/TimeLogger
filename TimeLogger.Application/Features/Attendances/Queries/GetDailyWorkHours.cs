using MediatR;
using TimeLogger.Application.Features.Attendances.Dto;

namespace TimeLogger.Application.Features.Attendances.Queries
{
    public record GetDailyWorkHours(AttendanceDto AttendanceDto) : IRequest<TimeSpan?>;
}
