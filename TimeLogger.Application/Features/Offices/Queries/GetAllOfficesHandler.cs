using TimeLogger.Application.Features.Offices.Dtos;

namespace TimeLogger.Application.Features.Offices.Queries
{
    public class GetAllOfficesHandler : IRequestHandler<GetAllOffices, List<OfficeDto>>
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IMapper _mapper;

        public GetAllOfficesHandler(IOfficeRepository officeRepository, IMapper mapper)
        {
            _officeRepository = officeRepository;
            _mapper = mapper;
        }

        public async Task<List<OfficeDto>> Handle(GetAllOffices request, CancellationToken cancellationToken)
        {
            var offices = await _officeRepository.GetAllOffices();

            var officeDtos = _mapper.Map<List<OfficeDto>>(offices);

            return officeDtos;
        }
    }
}
