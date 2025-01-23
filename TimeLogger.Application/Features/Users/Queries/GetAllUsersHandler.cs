using AutoMapper;
using MediatR;
using TimeLogger.Application.Features.Users.Dtos;
using TimeLogger.Application.IRepositories;

namespace TimeLogger.Application.Features.Users.Queries
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, List<ProfileDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<ProfileDto>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsers();
            var usersDtos = _mapper.Map<List<ProfileDto>>(users);

            return usersDtos;
        }
    }
}
