using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebClient.Filters;
using WebClient.Models;

namespace WebClient.Controllers
{
    //[ServiceFilter(typeof( MenuFilter))]
    [MenuFilter]
    public class HomeController : Controller
    {
        AppService service = new AppService();
        public IActionResult Index(int id = 1)
        {
            //string a = User.Identity.Name;
            List<Product> products = service.Product.GetProducts();
            int total = products.Count;
            List<Product> list = service.Product.GetProductsPagination(id, 8);
            ViewBag.total = total;
            ViewBag.page = (total - 1) / 8 + 1;
            return View(list);
            /*ViewBag.products = service.Product.GetProducts();
            return View(service.Category.GetCategories());*/
        }
        public IActionResult Browser(int id)
        {
            return View(service.Category.GetCategoryDetail(id));
        }
        public IActionResult Detail(int id)
        {
            return View(service.Product.GetProductsDetail(id));
        }
        public IActionResult Search(string q, int id = 1)
        {
            List<Product> list = service.Product.SearchProductsPagination(q, id, 8);
            if (list == null)
            {
                return RedirectToAction("Index");
            }
            int total = list.Count;
            ViewBag.total = total;
            ViewBag.page = (total - 1) / 8 + 1;
            return View(list);
        }
    }
}
