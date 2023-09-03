using static PriceAggregatorWeb.Utils.StaticDetails;

namespace PriceAggregatorWeb
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
