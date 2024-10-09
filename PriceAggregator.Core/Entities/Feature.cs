using System.ComponentModel.DataAnnotations;

namespace PriceAggregator.Core.Entities;

public class Feature : AggregateObject
{ 
    [Required] 
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
    public ICollection<Store> Stores { get; set; }
    public ICollection<Category> Categories { get; set; }
}