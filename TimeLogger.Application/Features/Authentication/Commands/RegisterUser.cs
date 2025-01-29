using TimeLogger.Application.Features.Authentication.Dtos;

namespace TimeLogger.Application.Features.Authentication.Commands
{
    public record RegisterUser(RegisterDto registerDto) : IRequest<UserDto>;
}
