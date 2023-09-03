using PricAggregatorAPI.Utils;
using PricAggregatorWeb.Models;
using PriceAggregatorWeb.Services.IServices;
using PriceAggregatorWeb.Utils;

namespace PriceAggregatorWeb.Services
{
    public class ProductService : BaseService, IProductService
    {
        private string _productUrl;
        public ProductService(IHttpClientFactory httpClientFactory, IConfiguration configuration) 
            : base(httpClientFactory)
        {
            _productUrl = configuration.GetValue<string>("ServiceUrls:PriceAggregatorAPI");
        }

        public async Task<APIResponse> GetAllAsync()
        {
            return await SendAsync(new APIRequest
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = _productUrl + "/api/ProductAPI"
            });
        }

        public async Task<APIResponse> GetAsync(int id)
        {
            return await SendAsync(new APIRequest
            {
                ApiType= StaticDetails.ApiType.GET,
                Url = _productUrl + "api/ProductAPI" + id
            });
        }
    }
}
