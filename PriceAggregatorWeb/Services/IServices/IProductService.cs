using PricAggregatorAPI.Utils;

namespace PriceAggregatorWeb.Services.IServices
{
    public interface IProductService
    {
        Task<APIResponse> GetAllAsync();
        Task<APIResponse> GetAsync(int id);
    }
}
