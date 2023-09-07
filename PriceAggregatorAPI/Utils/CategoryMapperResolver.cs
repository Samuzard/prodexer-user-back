using AutoMapper;
using PriceAggregatorAPI.Models;
using PriceAggregatorAPI.Models.DTOs;

namespace PriceAggregatorAPI.Utils
{
    public class MainProductMapperResolver : IValueResolver<MainProduct, MainProductDTO, string>
    {
        public string Resolve(MainProduct source, MainProductDTO destination, string destMember, ResolutionContext context)
        {
            return source.Category?.Name;
        }
    }
}
