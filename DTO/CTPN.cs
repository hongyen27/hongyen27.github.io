using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class CTPN
    {
        public string MAPN { get; set; }
        public int Material_ID { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Notes { get; set; }
        public string DVT { get; set; }

    }
}
