namespace PriceAggregatorAPI.Models.DTOs;

public class CategoryDto
{
    private long Id { get; set; }
    public string Name { get; set; }
    public int TreeLevel { get; set; }
    public int ParentId { get; set; }
    public string IconPath { get; set; }
    public string IconAlt {get; set; }
}