using AutoMapper;
using TimeLogger.Application.Features.Authentication.Dtos;
using TimeLogger.Application.Features.Checkins.Dto;
using TimeLogger.Application.Features.Checkouts.Dtos;
using TimeLogger.Application.Features.Offices.Dtos;
using TimeLogger.Application.Features.Rooms.Dtos;
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
            CreateMap<RoomDto, Room>().ReverseMap();

            //user mappers
            CreateMap<ProfileDto, User>()
                .ForMember(dest => dest.CheckIns, opt => opt.MapFrom(src => src.CheckIns))
                .ForMember(dest => dest.CheckOuts, opt => opt.MapFrom(src => src.CheckOuts))
                //.ForMember(dest => dest.RoomBookings, opt => opt.MapFrom(src => src.RoomBookings))
                .ReverseMap();

            //checkin mappers
            CreateMap<CheckInDto, CheckIn>().ReverseMap();
            CreateMap<CheckIn, UserCheckInDto>()
                .ForMember(dest => dest.CheckInTime, opt => opt.MapFrom(src => src.CheckInTime));

            //checkout mappers
            CreateMap<CheckOutDto, CheckOut>().ReverseMap();
            CreateMap<CheckOut, UserCheckOutDto>()
                .ForMember(dest => dest.CheckOutTime, opt => opt.MapFrom(src => src.CheckOutTime));
        }
    }
}
