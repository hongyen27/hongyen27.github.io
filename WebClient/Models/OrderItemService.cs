using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class OrderItemService : BaseService
    {
        public int Add(OrderItems obj)
        {
            return Post<OrderItems>("orderitem", obj);
        }
        public List<OrderItems> GetCarts(long id)
        {
            return Gets<OrderItems>($"orderitem/{id}");
        }
        public int Delete(long id, int productid)
        {
            return Delete($"orderitem/{id}&{productid}");
        }
        public int Edit(OrderItems obj)
        {
            return Put<OrderItems>($"orderitem/{obj.Id}", obj);
        }
    }
}
