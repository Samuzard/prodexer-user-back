using System.ComponentModel.DataAnnotations;

namespace PriceAggregatorAPI.Models.DTOs;

public class FeaturedItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<ProductDto> Products { get; set; }
    //public IEnumerable<Store> Stores { get; set; }
    //public IEnumerable<Category> Categories { get; set; }
}