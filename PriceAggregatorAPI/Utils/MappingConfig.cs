using AutoMapper;
using PricAggregatorAPI.Models;
using PricAggregatorAPI.Models.DTOs;
using PriceAggregatorAPI.Models;
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

            CreateMap<MainProduct, MainProductDTO>()
                .ForMember(dest => dest.CatrgoryName
                    , opt => opt.MapFrom<MainProductMapperResolver>());
        }
    }
}
