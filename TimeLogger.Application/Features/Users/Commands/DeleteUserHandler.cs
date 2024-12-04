using AutoMapper;
using MediatR;
using TimeLogger.Application.IRepositories;

namespace TimeLogger.Application.Features.Users.Commands
{
    public class DeleteUserHandler : IRequestHandler<DeleteUser, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.DeleteAsync(request.UserId);
            return result;
        }
    }
}
