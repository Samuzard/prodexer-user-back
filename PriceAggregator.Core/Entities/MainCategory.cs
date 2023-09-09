using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceAggregator.Core.Entities
{
    public class MainCategory : AggregateObject
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int Sort { get; set; }
    }
}
