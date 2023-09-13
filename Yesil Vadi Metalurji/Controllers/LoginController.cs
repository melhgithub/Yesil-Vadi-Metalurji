
using Business.Concrete;
using DataAccess;
using DataAccess.Repositories;
using Entity.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Yesil_Vadi_Metalurji.Dto;
using Yesil_Vadi_Metalurji.Models;

namespace Yesil_Vadi_Metalurji.Controllers
{
    public class LoginController : Controller
    {

        AdminManager adminManager = new AdminManager(new EFAdminRepository());

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var admins = await adminManager.GetList();

            var filter = new AdminLoginDto();

            var model = new AdminsLoginViewModel
            {
                Admins = admins,
                LoginDto = filter
            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(AdminLoginDto admin)
        {
            var data = await adminManager.GetList();
            data = data.Where(x => x.Status == (AdminStatuses)1 && x.Active == true).ToList();
            data = data.Where(x => x.UserName == admin.UserName && x.Password == admin.Password).ToList();


            if (data.Count != 0)
            {
                HttpContext.Session.SetString("username", admin.UserName);

                
                if (admin.UserName == "melh")
                {
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,admin.UserName),
                            new Claim(ClaimTypes.Role, "melh")
                        };
                    var useridentity = new ClaimsIdentity(claims, "a");
                    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                    await HttpContext.SignInAsync(principal);
                    return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminPageTest") });
                }
                else
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,admin.UserName)
                    };
                    var useridentity = new ClaimsIdentity(claims, "a");
                    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                    await HttpContext.SignInAsync(principal);
                    return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminPage") });
                }
            }
            else
            {
                return Json(new { success = false, message = "Geçersiz kullanıcı adı veya şifre." });
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}
