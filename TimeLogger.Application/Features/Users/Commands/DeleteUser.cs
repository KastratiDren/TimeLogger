using MediatR;

namespace TimeLogger.Application.Features.Users.Commands
{
    public record DeleteUser(string UserId) : IRequest<bool>;
}
