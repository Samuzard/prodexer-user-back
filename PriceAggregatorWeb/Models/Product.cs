using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PricAggregatorWeb.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }     
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set;}
        public string ImageUrl { get; set; }
        [Required]
        [MaxLength(50)]
        public string Store { get;set; }
        [Required]
        [MaxLength(150)]
        public string Url { get; set; }
        public string Description { get; set; }   
        [Required]
        public decimal Price { get; set; }
        [Required]
        [MaxLength(10)]
        public string Currency { get; set; }
        [Required]
        [MaxLength(50)] 
        public string State { get; set; }
        public double Ratings { get; set; }
    }
}
