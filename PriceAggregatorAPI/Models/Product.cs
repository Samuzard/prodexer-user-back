using PriceAggregatorAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PricAggregatorAPI.Models
{
    public class Product : AggregateObject
    {   
        [ForeignKey(nameof(MainProduct))]
        public int MainProductId { get; set; }
        public MainProduct MainProduct { get; set; }

        [ForeignKey(nameof(Store))]
        public int StoreId { get;set; }
        public Store Store { get; set; }
       
        [Required]
        public string Url { get; set; }
        [Required]
        
        public decimal Price { get; set; }
        [Required]
        [MaxLength(10)]
        public string PriceUnit { get; set; }
    }
}
