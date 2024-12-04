using MediatR;
using TimeLogger.Application.Features.Users.Dtos;

namespace TimeLogger.Application.Features.Users.Queries
{
    public record GetUserById(string UserId) : IRequest<ProfileDto>;
}

