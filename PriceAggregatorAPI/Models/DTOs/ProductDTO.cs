using PriceAggregatorAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PricAggregatorAPI.Models.DTOs
{
    public class ProductDTO
    {
        public string Url { get; set; }
        public decimal Price { get; set; }
        public string PriceUnit { get; set; }
        public string StoreName { get; set; }
    }
}
