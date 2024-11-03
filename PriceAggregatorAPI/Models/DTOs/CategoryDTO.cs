namespace PriceAggregatorAPI.Models.DTOs;

public class CategoryDto
{
    private int Id { get; set; }
    public string Name { get; set; }
    public int TreeLevel { get; set; }
    public int ParentId { get; set; }
}