using MediatR;
using TimeLogger.Application.Features.Checkins.Dto;

namespace TimeLogger.Application.Features.Checkins.Commands
{
    public record UserCheckIn(CheckInDto CheckInDto) : IRequest<bool>;
}
