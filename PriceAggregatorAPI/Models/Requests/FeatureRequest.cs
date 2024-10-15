using System.ComponentModel.DataAnnotations;

namespace PriceAggregatorAPI.Models.Requests;

public class FeatureRequest
{
    public string Name { get; set; }
    
    [MinLength(1)]
    public int[] ProductIds { get; set; }
}