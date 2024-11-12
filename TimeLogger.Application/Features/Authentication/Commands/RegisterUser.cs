using TimeLogger.Application.Features.Authentication.Dtos;
using MediatR;

namespace TimeLogger.Application.Features.Authentication.Commands
{
    public record RegisterUser(RegisterDto registerDto) : IRequest<UserDto>;
}
