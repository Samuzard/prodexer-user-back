using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PriceAggregator.Core.Entities
{
    public class MainProduct : AggregateObject
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        [ForeignKey(nameof(Category))]
        public int CatrgoryID { get; set; }
        public Category Category { get; set; }
    }
}
