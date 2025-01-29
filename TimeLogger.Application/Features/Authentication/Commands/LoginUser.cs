using TimeLogger.Application.Features.Authentication.Dtos;

namespace TimeLogger.Application.Features.Authentication.Commands
{
    public record LoginUser(LoginDto loginDto) : IRequest<UserDto>;
}
