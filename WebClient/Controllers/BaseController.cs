using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class BaseController : Controller
    {
        protected AppService service;
        public BaseController()
        {
            service = new AppService();
        }
        protected long CartId
        {
            get
            {
                long cartId;
                string obj = Request.Cookies["cart"];
                if (string.IsNullOrEmpty(obj))
                {
                    cartId = Helper.RandomLong();
                    CookieOptions options = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(30),
                        Path = "/"
                    };
                    Response.Cookies.Append("cart", cartId.ToString(), options);
                }
                else
                {
                    cartId = long.Parse(obj);
                }
                return cartId;
            }
            set
            {

            }
        }
    }
}
