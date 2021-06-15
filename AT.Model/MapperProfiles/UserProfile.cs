using AT.Model.Common;
using AT.Model.DTOs;
using AutoMapper;

namespace AT.Model.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(target=> target.Id, opt=>opt.MapFrom(src => src.Id))
                .ForMember(target=> target.Username, opt=>opt.MapFrom(src => src.UserName));
            CreateMap<UserDto, User>()
                .ForMember(target => target.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(target => target.UserName, opt => opt.MapFrom(src => src.Username));
        }
    }
}