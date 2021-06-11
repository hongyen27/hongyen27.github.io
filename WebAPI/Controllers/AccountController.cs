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
    public class AccountController : BaseController
    {
        // GET: api/<AccountController>
        [HttpGet]
        public List<Account> Get()
        {
            return app.Account.GetMembers();
        }
        [HttpGet("{id}")]
        public Account Get(long id)
        {
            return app.Account.GetMemberAndRoles(id);
        }
        [HttpPut("{id}")]
        public int Put(AccountInRole obj)
        {
            return app.AccountInRole.Save(obj);
        }
        [HttpPost]
        public int Post(Account obj)
        {
            return app.Account.Add(obj);
        }
        [HttpPut("{username}&{oldpassword}")]
        public int Put(Account obj)
        {
            return app.Account.Update(obj);
        }
        [HttpGet("GetDeliver")]
        public List<Account> GetDeliver()
        {
            return app.Account.GetDelivers();
        }
    }
}
