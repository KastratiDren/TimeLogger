using In_Out_Manager.Application.Features.Authentication.Dtos;
using MediatR;

namespace In_Out_Manager.Application.Features.Authentication.Commands
{
    public record RegisterUser(RegisterDto registerDto) : IRequest<UserDto>;
}
