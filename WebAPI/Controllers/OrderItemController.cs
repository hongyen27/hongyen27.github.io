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
    public class OrderItemController : BaseController
    {
        // GET: api/<OrderItemController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public List<OrderItems> Get(long id)
        {
            return app.OderItem.GetCarts(id);
        }
        [HttpPost]
        public int Post(OrderItems obj)
        {
            return app.OderItem.Add(obj);
        }
        [HttpDelete("{p}&{productid}")]
        public int Delete(long p, int productid)
        {
            return app.OderItem.Delete(p, productid);
        }
        [HttpPut("{id}")]
        public int Put(OrderItems obj)
        {
            return app.OderItem.Edit(obj);
        }
    }
}
