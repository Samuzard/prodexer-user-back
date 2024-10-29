using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceAggregator.Core.Entities
{
    public class Category : AggregateObject
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public int TreeLevel { get; set; }
        public int ParentId { get; set; }
        public int? FeatureId { get; set; }
        [ForeignKey("FeatureId")]
        public Feature Feature { get; set; }
        
        //public bool IsActive { get; set; }
        //public int Sort { get; set; }
    }
}