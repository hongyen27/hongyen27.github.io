using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class AuthController : Controller
    {
        AppService service = new AppService();
        [Authorize]
        public IActionResult Index()
        {
            long id = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Account account = service.Member.GetMemberById(id);
            return View(account);
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Account obj)
        {
            if (ModelState.IsValid)
            {
                obj.Id = Helper.RandomLong();
                obj.Status = "A";
                obj.CompanyId = "";
                int ret = service.Member.Add(obj);
                string[] error =
                {
                    "Username Đã tồn tại!",
                    "Đăng kí bị lỗi"
                };
                if (ret >= 2)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    ModelState.AddModelError("error", error[ret]);//error[ret]
                }
            }
            return View(obj);
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(SignInModel obj)
        {
            if (ModelState.IsValid)
            {
                Account member = service.Member.SignIn(obj.Usr, obj.Pwd);
                if (member != null)
                {
                    ClaimsIdentity claims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, member.Id.ToString()));
                    claims.AddClaim(new Claim(ClaimTypes.Name, member.Username));
                    claims.AddClaim(new Claim(ClaimTypes.Email, member.Email));
                    //claims.AddClaim(new Claim(ClaimTypes.SerialNumber, member.SDT));
                    //claims.AddClaim(new Claim(ClaimTypes.StreetAddress, member.Address));
                    //load roles
                    if (member.Roles != null)
                    {
                        foreach (Role item in member.Roles)
                        {
                            claims.AddClaim(new Claim(ClaimTypes.Role, item.Name));
                        }
                    }
                    AuthenticationProperties properties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        IsPersistent = obj.Remember,
                    };
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claims), properties);
                    foreach (var item in member.Roles)
                    {
                        if (item.Name == "Administrator" || item.Name == "Staff")
                        {
                            return Redirect("/administrator");
                        }

                        if(item.Name == "DELIVER")
                        {
                            return Redirect("/order");
                        }
                    }
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("error", "Đăng nhập bị lỗi!");
                }
            }
            return View(obj);
        }
        public IActionResult Denied()
        {
            return View();
        }
        [Authorize]
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
        public IActionResult Change()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Change(Account obj)
        {
            obj.Username = User.Identity.Name;
            if (obj.OldPassword.Equals(obj.Password))
            {
                ModelState.AddModelError("Error", "Mật khẩu mới không được giống mật khẩu cũ!");
                return View(obj);
            }
            else
            {
                if (service.Member.ChangePwd(obj) > 0)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("Error", "Update Failed");
                return View(obj);
            }
        }
    }
}
