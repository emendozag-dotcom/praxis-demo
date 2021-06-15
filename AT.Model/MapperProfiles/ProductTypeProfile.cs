using AT.Model.Common;
using AT.Model.DTOs;
using AutoMapper;

namespace AT.Model.MapperProfiles
{
    public class ProductTypeProfile : Profile
    {
        public ProductTypeProfile()
        {
            CreateMap<ProductType, ProductTypeDto>()
                .ForMember(target => target.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(target => target.Name, opt => opt.MapFrom(src => src.ProductTypeName));

            CreateMap<ProductTypeDto, ProductType>()
                .ForMember(target => target.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(target => target.ProductTypeName, opt => opt.MapFrom(src => src.Name));
        }
    }
}