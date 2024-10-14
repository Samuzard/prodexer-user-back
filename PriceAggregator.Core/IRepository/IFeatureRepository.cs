using System.Linq.Expressions;
using PriceAggregator.Core.Entities;

namespace PriceAggregator.Core.IRepository;

public interface IFeatureRepository : IRepository<Feature>
{
    Task<IEnumerable<Feature>> GetFeatures(Expression<Func<Feature, bool>> filter = null, bool isTracked = true);
    Task<Feature> AddFeature(IEnumerable<int> productIds, string name);
    Task<bool> DeleteFeature(int id);
}