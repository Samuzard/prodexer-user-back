namespace PriceAggregatorAPI.Models.DTOs
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public decimal Price { get; set; }
        public string PriceUnit { get; set; }
        public string StoreName { get; set; }
        public string StoreIconPath { get; set; }
        public string ImagePath { get; set; }
        public decimal? Rating { get; set; }
        public string CategoryName { get; set; }
    }
}
