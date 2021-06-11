using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class OrderItems
    {
        
        public long Id { get; set; }
        public int ProductId { get; set; }
        //public long OrderId { get; set; }
        public int Quantity { get; set; }

        //them vao de hien thi
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
    }
}
