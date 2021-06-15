using AT.Model.Common;
using AT.Model.DTOs;
using AutoMapper;

namespace AT.Model.MapperProfiles {
    public class UserForListProfile : Profile {
        public UserForListProfile () {
            CreateMap<User, UserForList> ()
                .ForMember (dest => dest.UserName, opt => opt.MapFrom (src => src.UserName))
                .ForMember (dest => dest.Id, opt => opt.MapFrom (src => src.Id));
        }
    }
}