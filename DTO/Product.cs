using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public double? Discount { get; set; }
        public int CategoryId { get; set; }
        public string Status { get; set; }
        public int NewPrice { get; set; }
        public string Temp_Discount { get; set; }
        public List<Product> Relation { get; set; }
    }
}
