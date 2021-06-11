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
    public class MemberController : Controller
    {
        AppService service = new AppService();
        public IActionResult Index()
        {
            return View(service.Member.GetMembers());
        }
        public IActionResult Role(long id)
        {
            return View(service.Member.GetMemberAndRoles(id));
        }
        public IActionResult Edit(AccountInRole obj)
        {
            return Json(service.Member.Edit(obj));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Account obj)
        {
            if (ModelState.IsValid)
            {
                obj.Id = Helper.RandomLong();
                int ret = service.Member.Add(obj);
                string[] error =
                {
                    "Username Đã tồn tại!",
                    "Đăng kí bị lỗi"
                };
                if (ret >= 2)
                {
                    return Redirect("/administrator/member/");
                }
                else
                {
                    //ModelState.AddModelError("error", "Insert Failed" );//error[ret]
                    ModelState.AddModelError("error", error[ret]);
                }
            }
            return View(obj);
        }
    }
}
