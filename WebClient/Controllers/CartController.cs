using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using WebClient.Filters;
using WebClient.Models;

namespace WebClient.Controllers
{
    [MenuFilter]
    public class CartController : BaseController
    {
        public IActionResult Index()
        {
            return View(service.Cart.GetCarts(CartId));
        }
        [HttpPost]
        public IActionResult Create(OrderItems obj)
        {
            try
            {
                Product product = service.Product.GetProductById(obj.ProductId);
                obj.Id = CartId;

                if (product.Discount == 0 || product.Discount == null)
                {
                    obj.Price = product.Price;
                }
                else
                {
                    obj.Price = (int)(product.Price * (1-product.Discount));
                }
                service.Cart.Add(obj);
                
            }
            catch{}
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (service.Cart.Delete(CartId, id) > 0)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("Error", "Delete failed");
            return View();
        }
        [HttpPost]
        public IActionResult Edit(OrderItems obj)
        {
            obj.Id = CartId;
            return Json(service.Cart.Edit(obj));
        }
    }
}
