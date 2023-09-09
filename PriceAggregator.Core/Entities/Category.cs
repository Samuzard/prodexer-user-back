using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceAggregator.Core.Entities
{
    public class Category : AggregateObject
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [ForeignKey(nameof(MainCategory))]
        public int MainCatrgoryId { get; set; }
        public MainCategory MainCategory { get; set; }

        public bool IsActive { get; set; }
        public int Sort { get; set; }
    }
}
