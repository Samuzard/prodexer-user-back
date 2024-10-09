using System.Linq.Expressions;
using PriceAggregator.Core.Entities;

namespace PriceAggregator.Core.IRepository;

public interface IFeatureRepository : IRepository<Feature>
{
    Task<Feature> AddFeature(IEnumerable<int> productIds, string name); 
}