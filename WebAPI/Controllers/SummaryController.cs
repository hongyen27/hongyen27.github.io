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
    public class SummaryController : BaseController
    {
        // GET: api/<SummaryController>
        [HttpGet]
        public List<Summary> Get()
        {
            return app.Summary.GetSummaryCategories();
        }

        // GET api/<SummaryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SummaryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SummaryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SummaryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
