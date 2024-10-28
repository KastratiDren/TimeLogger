using AutoMapper;
using In_Out_Manager.Application.Features.Authentication.Dtos;
using In_Out_Manager.Domain.Entites;

namespace In_Out_Manager.Application.Mapping
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
