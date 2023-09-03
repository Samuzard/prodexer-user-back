using AutoMapper;
using PricAggregatorWeb.Models;
using PriceAggregator.Models.DTOs;

namespace PricAggregatorWeb.Utils
{
    public sealed class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
