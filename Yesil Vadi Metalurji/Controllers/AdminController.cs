using Business.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yesil_Vadi_Metalurji.Dto;
using Yesil_Vadi_Metalurji.Models;

namespace Yesil_Vadi_Metalurji.Controllers
{
    public class AdminController : Controller
    {
        AdminManager adminManager = new AdminManager(new EFAdminRepository());
        public async Task<IActionResult> Index()
        {

            var admins = await adminManager.GetList();

            var filter = new AdminFilterDto();

            var model = new AdminsViewModel
            {
                Admins = admins,
                FilterDto = filter
            };


            return View(model);
        }

        public async Task<IActionResult> Filter(AdminFilterDto filterDto)
        {
            var admins = await adminManager.GetList();

            if (!string.IsNullOrEmpty(filterDto.UserName))
            {
                admins = admins.Where(p => p.UserName == filterDto.UserName).ToList();
            }

            if (!string.IsNullOrEmpty(filterDto.Password))
            {
                admins = admins.Where(p => p.Password == filterDto.Password).ToList();
            }

            if (filterDto.Active == "1")
            {
                admins = admins.Where(p => p.Active == true).ToList();
            }

            if (filterDto.Active == "2")
            {
                admins = admins.Where(p => p.Active == false).ToList();
            }

            if (filterDto.Status > 0)
            {
                admins = admins.Where(p => p.Status.Equals(filterDto.Status)).ToList();
            }

            var adminData = admins.Select(p => new
            {
                ID = p.ID,
                Username = p.UserName,
                Password = p.Password,
                Active = p.Active,
                Status = p.Status
            });

            return Json(adminData);
        }


        [HttpPost]
        public async Task<IActionResult> AddEditAdmin(AdminAddDto admin)
        {
            string message = "";

            if (admin != null)
            {
                try
                {
                    var adminToUpdate = await adminManager.GetByID(admin.ID);
                    bool isUpdate = adminToUpdate != null;

                    Admin adminEntity;

                    if (isUpdate)
                    {
                        adminEntity = adminToUpdate;
                    }
                    else
                    {
                        adminEntity = new Admin();
                    }
                    adminEntity.UserName = admin.UserName;
                    adminEntity.Password = admin.Password;
                    adminEntity.Status = admin.Status;
                    if (adminEntity.Status == (AdminStatuses)1)
                    {
                        adminEntity.Active = true;
                    }
                    else
                    {
                        adminEntity.Active = false;
                    }

                    if (isUpdate)
                    {
                        await adminManager.AdminUpdate(adminEntity);
                        message = "Admin başarıyla güncellendi!";
                    }
                    else
                    {
                        await adminManager.AdminAdd(adminEntity);
                        message = "Admin başarıyla kaydedildi!";
                    }
                }
                catch (Exception)
                {
                    message = "Admin eklenirken ya da güncellenirken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
                }

            }
            else
            {
                message = "Hata oluştu!";
            }

            return Json(message);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAdmin(AdminRemoveDto admin)
        {
            string message = "";

            if (admin != null)
            {
                try
                {
                    var adminToRemove = await adminManager.GetByID(admin.ID);

                    if (adminToRemove != null)
                    {
                        adminToRemove.Status = (AdminStatuses)2;
                        adminToRemove.Active = false;
                        await adminManager.AdminUpdate(adminToRemove);

                        message = "Admin başarıyla kaldırıldı!";
                    }
                    else
                    {
                        message = "Kaldırılmak istenen admin bulunamadı!";
                    }
                }
                catch (Exception)
                {
                    message = "Admin kaldırılırken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
                }
            }
            else
            {
                message = "Hata oluştu!";
            }


            return Json(message);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveAdmin(AdminApproveDto admin)
        {
            string message = "";

            if (admin != null)
            {
                try
                {
                    var adminToApprove = await adminManager.GetByID(admin.ID);

                    if (adminToApprove != null)
                    {
                        adminToApprove.Status = (AdminStatuses)1;
                        adminToApprove.Active = true;
                        await adminManager.AdminUpdate(adminToApprove);

                        message = "Admin başarıyla onaylandı!";
                    }
                    else
                    {
                        message = "Onaylanmak istenen admin bulunamadı!";
                    }
                }
                catch (Exception)
                {
                    message = "Admin onaylanırken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
                }
            }
            else
            {
                message = "Hata oluştu!";
            }

            return Json(message);
        }



    }
}
