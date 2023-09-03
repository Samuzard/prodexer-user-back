using System.ComponentModel.DataAnnotations;

namespace PricAggregatorAPI.Models.DTOs
{
    public class ProductDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [MaxLength(50)]
        public string Store { get; set; }
        [Required]
        [MaxLength(50)]
        public string OriginUrl { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
