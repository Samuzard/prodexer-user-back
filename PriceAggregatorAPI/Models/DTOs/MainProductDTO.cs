using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PriceAggregatorAPI.Models.DTOs
{
    public class MainProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string CatrgoryName { get; set; }
    }
}
