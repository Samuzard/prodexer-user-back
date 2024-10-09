using System.ComponentModel.DataAnnotations;

namespace PriceAggregatorAPI.Models.Requests;

public class AddFeatureRequest
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    [MinLength(1)]
    public IEnumerable<int> ProductIds { get; set; }
}