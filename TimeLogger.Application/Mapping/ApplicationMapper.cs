using AutoMapper;
using TimeLogger.Application.Features.Authentication.Dtos;
using TimeLogger.Application.Features.Checkins.Dto;
using TimeLogger.Application.Features.Checkouts.Dtos;
using TimeLogger.Application.Features.Offices.Dtos;
using TimeLogger.Application.Features.Users.Dtos;
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

            //user mappers
            CreateMap<ProfileDto, User>().ReverseMap();

            //checkin mappers
            CreateMap<CheckInDto, CheckIn>().ReverseMap();

            //checkout mappers
            CreateMap<CheckOutDto, CheckOut>().ReverseMap();
        }
    }
}
