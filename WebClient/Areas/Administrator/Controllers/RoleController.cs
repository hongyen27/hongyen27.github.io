using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Areas.Controllers
{
    //[Authorize(Roles = "Administrator")]
    [Area("administrator")]
    public class RoleController : Controller
    {
        AppService service = new AppService();
        public IActionResult Index()
        {
            return View(service.Role.GetRoles());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Role obj)
        {
            if (service.Role.Add(obj) > 0)
            {
                return Redirect("/administrator/role/");
            }
            ModelState.AddModelError("Error", "Insert Failed");
            return View(obj);
        }
        public IActionResult Delete(int id)
        {
            if (service.Role.Delete(id) > 0)
            {
                return Redirect("/administrator/role/");
            }
            ModelState.AddModelError("Error", "Delete Failed");
            return View();
        }
        public IActionResult Edit(int id)
        {
            return Json(service.Role.GetRoleById(id));
        }
        [HttpPost]
        public IActionResult Edit(Role obj)
        {
            if (service.Role.Edit(obj) > 0)
            {
                return Redirect("/administrator/role/");
            }
            ModelState.AddModelError("Error", "Edit Failed");
            return View(obj);
        }
    }
}
