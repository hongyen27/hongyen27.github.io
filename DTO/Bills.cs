using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Bills
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public DateTime CreateTime { get; set; }
        public string TaxCode { get; set; }
    }
}
