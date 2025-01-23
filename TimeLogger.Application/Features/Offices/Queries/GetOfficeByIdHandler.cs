using AutoMapper;
using MediatR;
using TimeLogger.Application.Features.Offices.Dtos;
using TimeLogger.Application.IRepositories;

namespace TimeLogger.Application.Features.Offices.Queries
{
    public class GetOfficeByIdHandler : IRequestHandler<GetOfficeById, OfficeDto>
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IMapper _mapper;

        public GetOfficeByIdHandler(IOfficeRepository officeRepository, IMapper mapper)
        {
            _officeRepository = officeRepository;
            _mapper = mapper;
        }

        public async Task<OfficeDto> Handle(GetOfficeById request, CancellationToken cancellationToken)
        {

            var office = await _officeRepository.GetOfficeById(request.id);

            if (office == null)
                return null;

            var officeDto = _mapper.Map<OfficeDto>(office);
            return officeDto;
        }
    }
}
