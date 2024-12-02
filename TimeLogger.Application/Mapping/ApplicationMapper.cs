﻿using AutoMapper;
using TimeLogger.Application.Features.Authentication.Dtos;
using TimeLogger.Application.Features.Offices.Dtos;
using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.Mapping
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            //authentication mappers
            CreateMap<RegisterDto, User>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<LoginDto, User>().ReverseMap();

            //office mappers
            CreateMap<OfficeDto, Office>().ReverseMap();
        }
    }
}
