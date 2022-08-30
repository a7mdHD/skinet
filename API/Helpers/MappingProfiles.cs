using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                //mapping configuration for return the name of brand & type of product insted of type of their classes.
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name)) 
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                //To return full image path.
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}