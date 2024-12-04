using MediatR;
using TimeLogger.Application.Features.Users.Dtos;

namespace TimeLogger.Application.Features.Users.Queries
{
    public record GetAllUsers : IRequest<List<ProfileDto>>;
}
