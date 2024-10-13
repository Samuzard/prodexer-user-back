using System.Linq.Expressions;
using PriceAggregator.Core.Entities;

namespace PriceAggregator.Core.IRepository;

public interface IFeatureRepository : IRepository<Feature>
{
    Task<Feature> GetFeatureById(int id);
    Task<IEnumerable<Feature>> GetAllFeatures(Expression<Func<Feature, bool>> filter = null);
    Task<Feature> AddFeature(IEnumerable<int> productIds, string name);
    Task<bool> DeleteFeature(int id);
}