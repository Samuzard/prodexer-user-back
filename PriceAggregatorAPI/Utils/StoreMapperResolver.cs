using AutoMapper;
using PricAggregatorAPI.Models;
using PricAggregatorAPI.Models.DTOs;
using PriceAggregator.Core.Entities;

namespace PriceAggregatorAPI.Utils
{
    public class StoreMapperResolver : IValueResolver<Product, ProductDTO, string>
    {
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            return source.Store?.Name;
        }
    }
}
