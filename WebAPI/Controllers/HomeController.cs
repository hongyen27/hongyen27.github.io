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
    public class HomeController : BaseController
    {
        [HttpGet("browser/{id}")]
        //[Route("api/home/browser/{id}")]
        public Category Browser(int id)
        {
            return app.Category.GetCategoryDetail(id);
        }
        [HttpGet("detail/{p}")]
        //[Route("api/home/detail/{id}")]
        public Product Detail(int p)
        {
            return app.Product.GetProductsDetail(p);
        }
        [HttpGet("{id}&{size}")]
        //[Route("api/home/{id}&{size}")]
        public List<Product> Get(int id, int size)
        {
            return app.Product.GetProductsPagination(id, size);
        }
        [HttpGet("search/{q}&{id}&{size}")]
        //[Route("api/home/search/{q}&{id}&{size}")]
        public List<Product> Search(string q, int id, int size)
        {
            return app.Product.SearchProductsPaginationByQ(q, id, size);
        }
    }
}
