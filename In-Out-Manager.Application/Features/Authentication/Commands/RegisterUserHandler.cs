﻿using AutoMapper;
using In_Out_Manager.Application.Features.Authentication.Dtos;
using In_Out_Manager.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace In_Out_Manager.Application.Features.Authentication.Commands
{
    public class RegisterUserHandler : IRequestHandler<RegisterUser, UserDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public RegisterUserHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
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

                var userDto = _mapper.Map<UserDto>(user);
                return userDto;
            }catch(Exception ex)
            {
                throw new ApplicationException("An error occurred while registering the user.", ex);
            }
        }
    }
}