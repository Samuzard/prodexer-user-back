namespace PriceAggregatorAPI.Models.DTOs;

public class FeaturedItemContainerDto
{
 public IEnumerable<FeaturedItemDto> FeaturedProductItemDtoList { get; set; }   
 public IEnumerable<FeaturedItemDto> FeaturedCategoryItemDtoList { get; set; }   
}