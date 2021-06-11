using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Areas.Controllers
{
    //attribute
    [Area("administrator")]
    public class CategoryController : Controller
    {
        CategoryService service = new CategoryService();
        public IActionResult Index()
        {
            return View(service.GetCategories());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (service.Add(obj) > 0)
            {
                return Redirect("/administrator/category/");
            }
            ModelState.AddModelError("Error", "Insert Failed");
            return View(obj);
        }
        public IActionResult Delete(int id)
        {
            if (service.Delete(id) > 0)
            {
                return Redirect("/administrator/category/");
            }
            ModelState.AddModelError("Error", "Delete Failed");
            return View();
        }
        public IActionResult Edit(int id)
        {
            return View(service.GetCategoryById(id));
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (service.Edit(obj) > 0)
            {
                return Redirect("/administrator/category/");
            }
            ModelState.AddModelError("error", "Edit Failed");
            return View(obj);
        }
    }
}
