using AutoMapper;
using PricAggregatorAPI.Models.DTOs;
using PriceAggregator.Core.Entities;

namespace PricAggregatorAPI.Utils
{
    public sealed class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}
