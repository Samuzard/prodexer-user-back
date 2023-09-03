using PricAggregatorAPI.Utils;

namespace PriceAggregatorWeb.Services.IServices
{
    public interface IBaseService
    {
        Task<APIResponse> SendAsync(APIRequest apiRequest);
    }
}
