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
                .ForMember(dest => dest.StoreIconPath, opt => opt.MapFrom(src => src.Store.IconPath));

            CreateMap<Feature, FeatureDto>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
        }
    }
}