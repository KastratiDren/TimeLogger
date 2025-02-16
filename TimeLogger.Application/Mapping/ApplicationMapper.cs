﻿using TimeLogger.Application.Features.Authentication.Dtos;
using TimeLogger.Application.Features.Checkins.Dto;
using TimeLogger.Application.Features.Checkouts.Dtos;
using TimeLogger.Application.Features.Offices.Dtos;
using TimeLogger.Application.Features.RoomBookings.Dtos;
using TimeLogger.Application.Features.Rooms.Dtos;
using TimeLogger.Application.Features.Users.Dtos;

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
            CreateMap<RoomBookingsDto, RoomBooking>().ReverseMap();

            //user mappers
            CreateMap<ProfileDto, User>()
                .ForMember(dest => dest.CheckIns, opt => opt.MapFrom(src => src.CheckIns))
                .ForMember(dest => dest.CheckOuts, opt => opt.MapFrom(src => src.CheckOuts))
                //.ForMember(dest => dest.RoomBookings, opt => opt.MapFrom(src => src.RoomBookings))
                .ReverseMap();

            CreateMap<User, ProfileDto>()
                .ForMember(dest => dest.RoomBookings, opt => opt.MapFrom(src => src.RoomBookings));


            //checkin mappers
            CreateMap<CheckInDto, CheckIn>().ReverseMap();
            CreateMap<CheckIn, UserCheckInDto>()
                .ForMember(dest => dest.CheckInTime, opt => opt.MapFrom(src => src.CheckInTime));

            //checkout mappers
            CreateMap<CheckOutDto, CheckOut>().ReverseMap();
            CreateMap<CheckOut, UserCheckOutDto>()
                .ForMember(dest => dest.CheckOutTime, opt => opt.MapFrom(src => src.CheckOutTime));


            // Map RoomBooking to UserRoomBookingDto
            CreateMap<RoomBooking, UserRoomBookingDto>()
                .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.Room.Name)) 
                .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(src => src.StartTime)) 
                .ReverseMap();


        }
    }
}
