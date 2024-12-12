using MediatR;
using TimeLogger.Application.Features.Checkouts.Dtos;

namespace TimeLogger.Application.Features.Checkouts.Commands
{
    public record UserCheckOut(CheckOutDto CheckOutDto) : IRequest<bool>;
}