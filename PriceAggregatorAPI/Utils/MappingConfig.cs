using AutoMapper;
using PriceAggregator.Core.Entities;
using PriceAggregatorAPI.Models.DTOs;

namespace PriceAggregatorAPI.Utils
{
    public sealed class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.Name))
                .ForMember(dest => dest.StoreIconPath, opt => opt.MapFrom(src => src.Store.IconPath))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<FeaturedItem, FeaturedItemDto>();
            
            CreateMap<IEnumerable<FeaturedItem>, FeaturedItemContainerDto>()
                .ForMember(dest => dest.FeaturedProductItemDtoList,
                    opt => opt.MapFrom(src => src.Where(x => x.Products != null && x.Products.Any())))
                .ForMember(dest => dest.FeaturedCategoryItemDtoList,
                    opt => opt.MapFrom(src => src.Where(x => x.Categories != null && x.Categories.Any())));
            
            CreateMap<Category, CategoryDto>();
        }
    }
}