namespace PriceAggregatorAPI.Models.Requests;

internal class UpdateFeatureRequest
{
    internal IEnumerable<int> ProductIds { get; set; }
}