using AutoMapper;
using MediatR;
using TimeLogger.Application.Features.Users.Dtos;
using TimeLogger.Application.IRepositories;

namespace TimeLogger.Application.Features.Users.Queries
{
    public class GetUserByIdHandler : IRequestHandler<GetUserById, ProfileDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ProfileDto> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {request.UserId} not found.");
            }

            var userDto = _mapper.Map<ProfileDto>(user);
            return userDto;
        }
    }
}

