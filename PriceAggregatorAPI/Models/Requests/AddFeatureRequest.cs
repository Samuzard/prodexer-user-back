using System.ComponentModel.DataAnnotations;

namespace PriceAggregatorAPI.Models.Requests;

internal class AddFeatureRequest
{
    [Required]
    internal string Name { get; set; }
    
    [Required]
    [MinLength(1)]
    internal IEnumerable<int> ProductIds { get; set; }
}