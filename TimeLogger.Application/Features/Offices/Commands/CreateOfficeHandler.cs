﻿using TimeLogger.Application.Features.Offices.Dtos;

namespace TimeLogger.Application.Features.Offices.Commands
{
    public class CreateOfficeHandler : IRequestHandler<CreateOffice, OfficeDto>
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IMapper _mapper;

        public CreateOfficeHandler(IOfficeRepository officeRepository, IMapper mapper)
        {
            _officeRepository = officeRepository;
            _mapper = mapper;
        }

        public async Task<OfficeDto> Handle(CreateOffice request, CancellationToken cancellationToken)
        {
            var office = _mapper.Map<Office>(request.officeDto);

            await _officeRepository.CreateOffice(office);

            var responseDto = _mapper.Map<OfficeDto>(office);

            return responseDto;
        }
    }
}
