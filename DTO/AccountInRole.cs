using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class AccountInRole
    {
        public long AccountId { get; set; }
        public int RoleId { get; set; }
        public bool isDelete { get; set; }

    }
}
