using Business.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yesil_Vadi_Metalurji.Controllers
{
    public class AdminPageController : Controller
    {
        AdminManager adminManager = new AdminManager(new EFAdminRepository());
        public async Task<IActionResult> Index()
        {
            var username = User.Identity.Name;
            ViewBag.UserName = username;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(string username, string currentPassword, string newPassword)
        {
            var user = await GetUserByUsernameAsync(username);
            if (user == null || user.Password != currentPassword)
            {
                return Json(new { success = false, message = "Eski şifre yanlış." });
            }

            user.Password = newPassword;
            var updateResult = await UpdateUserAsync(user);

            if (!updateResult)
            {
                return Json(new { success = false, message = "Şifre güncellenirken bir hata oluştu." });
            }

            return Json(new { success = true, message = "Şifre başarıyla güncellendi." });
        }

        private async Task<Admin> GetUserByUsernameAsync(string username)
        {
            return await adminManager.GetAdminByName(username);
        }

        private async Task<bool> UpdateUserAsync(Admin admin)
        {
            try
            {
                await adminManager.Update(admin);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
