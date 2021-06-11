using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Areas.Controllers
{
    [Area("administrator")]
    public class ProductController : Controller
    {
        AppService service = new AppService();

        public IActionResult Index()
        {
            return View(service.Product.GetProducts());
        }
        public IActionResult Create()
        {
            return View(service.Category.GetCategories());
        }
        [HttpPost]
        public IActionResult Create(Product obj, IFormFile f)
        {
            if (f != null)
            {
                obj.ImageUrl = Upload(f);
            }
            obj.Discount = double.Parse(obj.Temp_Discount);
            if (service.Product.Add(obj) > 0)
            {
                return Redirect("/administrator/product/");
            }
            ModelState.AddModelError("Error", "Insert Failed");
            return View(obj);
        }
        static string Upload(IFormFile f)
        {
            string fileName = Guid.NewGuid() + f.FileName.Replace(" ", string.Empty);
            string path = Directory.GetCurrentDirectory() + "/wwwroot/upload/" + fileName;
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                f.CopyTo(stream);
            }
            return fileName;
        }
        public IActionResult Delete(int id)
        {
            if (service.Product.Delete(id) > 0)
            {
                return Redirect("/administrator/product/");
            }
            ModelState.AddModelError("Error", "Delete Failed");
            return View();
        }
        public IActionResult Edit(int id)
        {
            Product obj = service.Product.GetProductById(id);
            List<Category> list = service.Category.GetCategories();
            ViewBag.categories = list;//load list category
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(Product obj, IFormFile f)
        {
            if (f != null)
            {
                obj.ImageUrl = Upload(f);
            }
            obj.Discount = double.Parse(obj.Temp_Discount);
            if (service.Product.Edit(obj) > 0)
            {
                return Redirect("/administrator/product/");
            }
            ModelState.AddModelError("Error", "Edit Failed");
            return View(obj);
        }
    }
}
