using AT.Model.Common;
using AT.Model.DTOs;
using AutoMapper;

namespace AT.Model.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(target => target.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(target => target.Name, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(target => target.ProductTypeId, opt => opt.MapFrom(src => src.IdProductType));

            CreateMap<ProductDto, Product>()
                .ForMember(target => target.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(target => target.ProductName, opt => opt.MapFrom(src => src.Name))
                .ForMember(target => target.IdProductType, opt => opt.MapFrom(src => src.ProductTypeId));

        }
    }
}
