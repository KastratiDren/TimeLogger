﻿using AutoMapper;
using TimeLogger.Application.Features.Authentication.Dtos;
using TimeLogger.Application.IServices;
using TimeLogger.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace TimeLogger.Application.Features.Authentication.Commands
{
    public class RegisterUserHandler : IRequestHandler<RegisterUser, UserDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public RegisterUserHandler(UserManager<User> userManager, IMapper mapper, ITokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<UserDto> Handle(RegisterUser request, CancellationToken cancellationToken)
        {
            try
            {
                var requestDto = request.registerDto;

                var user = _mapper.Map<User>(requestDto);

                var createdUser = await _userManager.CreateAsync(user, requestDto.Password);
                if (!createdUser.Succeeded)
                {
                    throw new Exception(string.Join("; ", createdUser.Errors.Select(e => e.Description)));
                }

                var roleResult = await _userManager.AddToRoleAsync(user, "Employee");
                if (!roleResult.Succeeded)
                {
                    throw new Exception(string.Join("; ", roleResult.Errors.Select(e => e.Description)));
                }

                var roles = await _userManager.GetRolesAsync(user);
                var token = _tokenService.CreateToken(user);

                var userDto = _mapper.Map<UserDto>(user);
                userDto.Token = token;
                userDto.Role = roles.FirstOrDefault();
                return userDto;

            }catch(Exception ex)
            {
                throw new ApplicationException("An error occurred while registering the user.", ex);
            }
        }
    }
}
