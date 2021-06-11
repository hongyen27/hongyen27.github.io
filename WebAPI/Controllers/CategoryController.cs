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
    public class CategoryController : BaseController
    {
        // GET: api/<CategoryController>
        [HttpGet]
        public List<Category> Get()
        {
            return app.Category.GetCategories();
        }
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return app.Category.GetCategoryById(id);
        }
        [HttpPost]
        public int Post(Category obj)
        {
            return app.Category.Add(obj);
        }
        [HttpDelete("{p}")]
        public int Delete(int p)
        {
            return app.Category.Delete(p);
        }
        [HttpPut("{id}")]
        public int Put(Category obj)
        {
            return app.Category.Edit(obj);
        }
    }
}
