using System.ComponentModel.DataAnnotations;

namespace PriceAggregatorAPI.Models.DTOs;

public class FeatureDto
{
    [Required]
    public string Name { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    public ICollection<ProductDto> Products { get; set; }
//     public IEnumerable<Store> Stores { get; set; }
//     public IEnumerable<Category> Categories { get; set; }
}