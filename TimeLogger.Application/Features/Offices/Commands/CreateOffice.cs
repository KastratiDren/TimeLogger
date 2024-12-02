using MediatR;
using TimeLogger.Application.Features.Offices.Dtos;

namespace TimeLogger.Application.Features.Offices.Commands
{
    public record CreateOffice(OfficeDto officeDto) : IRequest<OfficeDto>;
}
