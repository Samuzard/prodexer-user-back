using System.ComponentModel.DataAnnotations;

namespace PricAggregatorAPI.Models.DTOs
{
    public class ProductDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Url { get; set; }
        [Required]
        [MaxLength(50)]
        public string StoreId { get; set; }
        [Required]
        [MaxLength(50)]
        public string OriginUrl { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
