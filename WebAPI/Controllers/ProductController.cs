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
    public class ProductController : BaseController
    {
        // GET: api/<ProductController>
        [HttpGet]
        public List<Product> Get()
        {
            return app.Product.GetProducts();
        }
        [HttpPost]
        public int Post(Product obj)
        {
            return app.Product.Add(obj);
        }
        [HttpDelete("{p}")]
        public int Delete(int p)
        {
            return app.Product.Delete(p);
        }
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return app.Product.GetProductById(id);
        }
        [HttpPut("{id}")]
        public int Put(Product obj)
        {
            return app.Product.Edit(obj);
        }

    }
}
