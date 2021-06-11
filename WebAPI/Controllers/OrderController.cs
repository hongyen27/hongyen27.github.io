using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        //getlist orders by accountId
        [HttpGet("{id}")]
        public List<Orders> Get(long id)
        {
            return app.Order.GetOrders(id);
        }
        // GET api/<OrderController>/5
        [HttpGet("item/{id}")]
        public List<OrderItems> GetItems(long id)
        {
            return app.OderItem.GetOrderItemsById(id);
        }

        [HttpGet("GetOrdersById/{p}")]
        public Orders GetOrdersById(long p)
        {
            return app.Order.GetOrdersById(p);
        }


        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public int Put(Orders obj)
        {
            return app.Order.Pay(obj);
        }

        [HttpPut("process/{p}")]
        public int PutOrders(Orders obj)
        {
            return app.Order.OrderProcess(obj);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
