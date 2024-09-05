using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceAggregator.Core.Entities
{
    public class Product : AggregateObject
    {   
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

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
        
        [ForeignKey(nameof(Category))]
        public int CatrgoryID { get; set; }
        public Category Category { get; set; }
    }
}
