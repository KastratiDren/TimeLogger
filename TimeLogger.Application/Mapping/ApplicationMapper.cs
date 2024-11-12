using AutoMapper;
using TimeLogger.Application.Features.Authentication.Dtos;
using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.Mapping
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<RegisterDto, User>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
