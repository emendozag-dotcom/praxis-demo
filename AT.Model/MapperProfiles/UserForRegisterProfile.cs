using AT.Model.Common;
using AT.Model.DTOs;
using AutoMapper;

namespace AT.Model.MapperProfiles {
    public class UserForRegisterProfile : Profile {
        public UserForRegisterProfile () {
            CreateMap<UserForRegister, User> ()
                .ForMember (dest => dest.UserName, opt => opt.MapFrom (src => src.UserName));
            CreateMap<User, UserForRegister> ()
                .ForMember (dest => dest.UserName, opt => opt.MapFrom (src => src.UserName));
        }
    }
}