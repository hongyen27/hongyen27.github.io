using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Orders
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Notes { get; set; }
        public long? DeliverID { get; set; }
        public DateTime? DeliverDT { get; set; }
        public long? Staff_ID { get; set; }
        public DateTime? Staff_DT { get; set; }
        public string Address { get; set; }
        public string SDT { get; set; }

        //Thêm vào
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public long? Total { get; set; }
        public string HOTEN { get; set; }
        public string HOTEN_DL { get; set; }
        public string HOTEN_ST { get; set; }
        public string SDT_DL { get; set; }
        public string Status_code { get; set; }


    }
}
