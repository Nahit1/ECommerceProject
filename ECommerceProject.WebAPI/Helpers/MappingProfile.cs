using AutoMapper;
using ECommerceProject.Core.Entities;
using ECommerceProject.WebAPI.DTOs;

namespace ECommerceProject.WebAPI.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}