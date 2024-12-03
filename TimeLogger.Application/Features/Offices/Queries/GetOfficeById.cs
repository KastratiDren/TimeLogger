using MediatR;
using TimeLogger.Application.Features.Offices.Dtos;

namespace TimeLogger.Application.Features.Offices.Queries
{
    public record GetOfficeById(int id) : IRequest<OfficeDto>;
}
