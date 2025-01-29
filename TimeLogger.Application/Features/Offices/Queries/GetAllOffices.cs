using TimeLogger.Application.Features.Offices.Dtos;

namespace TimeLogger.Application.Features.Offices.Queries
{
    public record GetAllOffices : IRequest<List<OfficeDto>>;
}
