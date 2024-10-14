using System.ComponentModel.DataAnnotations;

namespace PriceAggregatorAPI.Models.DTOs;

public class FeatureDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    public IEnumerable<ProductDto> Products { get; set; }
//     public IEnumerable<Store> Stores { get; set; }
//     public IEnumerable<Category> Categories { get; set; }
}