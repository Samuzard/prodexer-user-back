﻿namespace PricAggregatorAPI.Models.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public decimal Price { get; set; }
        public string PriceUnit { get; set; }
        public string StoreName { get; set; }
    }
}
