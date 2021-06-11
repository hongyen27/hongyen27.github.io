using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class OrderService : BaseService
    {
        public List<Orders> GetOrders(long id)
        {
            return Gets<Orders>($"order/{id}");
        }
        public int Pay(Orders obj)
        {
            return Put<Orders>($"order/{obj.Id}", obj);
        }

        public List<OrderItems> GetItems(long id)
        {
            return Gets<OrderItems>($"order/item/{id}");
        }

        public Orders GetOrdersById(long id)
        {
            return Get<Orders>($"order/GetOrdersById/{id}");
        }

        public int OrderProcess(Orders obj)
        {
            return Put<Orders>($"order/process/{obj.Id}", obj);
        }
    }
}
