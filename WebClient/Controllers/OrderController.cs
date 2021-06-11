using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebClient.Filters;
using WebClient.Models;

namespace WebClient.Controllers
{
    [MenuFilter]
    public class OrderController : BaseController
    {
        AppService app = new AppService();
        public IActionResult Index()
        {
            long id = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            List<Orders> list = app.Order.GetOrders(id);
            return View(list);
        }
        public IActionResult Pay(Orders obj)
        {
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) == null)
            {
                return Redirect("/auth/signin");
            }
            long id = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            obj.AccountId = id;
            obj.Id = CartId;
            obj.Status = "P";

            if (app.Order.Pay(obj) > 0)
            {
                CookieOptions options = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(30),
                    Path = "/"
                };
                Response.Cookies.Append("cart", Helper.RandomLong().ToString(), options);
                return RedirectToAction("Index");
            }
            return Redirect("/");
        }

        public IActionResult Items(long id)
        {
            List<OrderItems> list = app.Order.GetItems(id);
            ViewBag.orders = app.Order.GetOrdersById(id);
            int total = 0;
            foreach (var item in list)
            {
                total += (item.Price * item.Quantity);
            }
            ViewBag.total = total;
            return View(list);
        }

        
        public IActionResult Process(Orders obj)
        {
            long id = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            obj.AccountId = id;
            if (app.Order.OrderProcess(obj)>0)
            {
                if (User.IsInRole("Administrator") || User.IsInRole("Staff"))
                {
                    return Redirect("/administrator/order");
                }
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("error", "Failed");
            return View(obj);
        }
    }
}
