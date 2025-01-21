using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TimeLogger.Application.Features.Authentication.Dtos;
using TimeLogger.Application.IServices;
using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.Features.Authentication.Commands
{
    public class LoginUserHandler : IRequestHandler<LoginUser, UserDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public LoginUserHandler(
            ITokenService tokenService,
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IMapper mapper)
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(LoginUser request, CancellationToken cancellationToken)
        {
            try
            {
                var requestDto = request.loginDto;

                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == requestDto.Email.ToLower());

                if (user == null)
                    throw new UnauthorizedAccessException("Invalid email!");

                var result = await _signInManager.CheckPasswordSignInAsync(user, requestDto.Password, false);

                if (!result.Succeeded)
                    throw new UnauthorizedAccessException("Email not found and/or password incorrect");

                var roles = await _userManager.GetRolesAsync(user);

                // Generate the token
                var token = await _tokenService.GenerateJwtToken(user);

                // Map the user entity to the DTO
                var userDto = _mapper.Map<UserDto>(user);
                userDto.Token = token;
                userDto.Role = roles.FirstOrDefault();

                return userDto;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while login the user.", ex);
            }

        }
    }
}
