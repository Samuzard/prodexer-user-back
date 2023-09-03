using AutoMapper;
using PricAggregatorAPI.Models;
using PricAggregatorAPI.Models.DTOs;

namespace PricAggregatorAPI.Utils
{
    public sealed class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
