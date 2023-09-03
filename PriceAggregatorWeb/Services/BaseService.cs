using Newtonsoft.Json;
using PricAggregatorAPI.Utils;
using PriceAggregatorWeb.Services.IServices;

namespace PriceAggregatorWeb.Services
{
    public class BaseService : IBaseService
    {
        private IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResponse> SendAsync(APIRequest apiRequest)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PriceAggregatorAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                message.Method = HttpMethod.Get;

                return await DeserializeIntoAPIResponse(client, message);
            }
            catch (Exception ex)
            {
                var response = new APIResponse
                {
                    ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false
                };

                return response;
            }
        }

        private async Task<APIResponse> DeserializeIntoAPIResponse(HttpClient client, HttpRequestMessage message)
        {
            HttpResponseMessage apiResponse = await client.SendAsync(message);
            var apiContent = await apiResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<APIResponse>(apiContent);

            return response /*?? throw new Exception(apiResponse.StatusCode.ToString())*/;
        }

    }
}
