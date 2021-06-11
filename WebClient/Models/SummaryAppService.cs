using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class SummaryAppService : BaseService
    {
        public List<Summary> GetSummaryCategories()
        {
            return Gets<Summary>("summary");
        }
    }
}
