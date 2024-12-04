namespace PriceAggregatorAPI.Models.DTOs;

public class FeaturedItemDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<ProductDto> Products { get; set; }
    public IEnumerable<CategoryDto> Categories { get; set; }
    //public IEnumerable<Store> Stores { get; set; }
}