using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceAggregator.Core.Entities
{
    public class Store : AggregateObject
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string IconPath { get; set; }
        public long? FeatureId { get; set; }
        [ForeignKey("FeatureId")]
        public FeaturedItem FeaturedItem { get; set; }
    }
}
