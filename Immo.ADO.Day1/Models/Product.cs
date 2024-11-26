﻿namespace Immo.ADO.Day1.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public byte CategoryId { get; set; }
        public int Quantity { get; set; }
    }
}
