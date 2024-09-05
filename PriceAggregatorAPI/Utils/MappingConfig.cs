using AutoMapper;
using PricAggregatorAPI.Models.DTOs;
using PriceAggregator.Core.Entities;
using PriceAggregatorAPI.Models.DTOs;
using PriceAggregatorAPI.Utils;

namespace PricAggregatorAPI.Utils
{
    public sealed class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.StoreName
                    , opt => opt.MapFrom<StoreMapperResolver>());
        }
    }
}
