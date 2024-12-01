using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceAggregator.Core.Entities
{
    public class Category : AggregateObject
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public long TreeLevel { get; set; }
        public long ParentId { get; set; }
        public long? FeatureId { get; set; }
        [ForeignKey("FeatureId")]
        public FeaturedItem FeaturedItem { get; set; }
        public bool IsActive { get; set; }
        public string IconPath { get; set; }
        public string IconAlt {get; set; }
    }
}