using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;
using Yesil_Vadi_Metalurji.Dto;
using Yesil_Vadi_Metalurji.Models;
using Microsoft.AspNetCore.Authorization;

namespace Yesil_Vadi_Metalurji.Controllers
{
    [Authorize(Policy = "MelhOnly")]
    public class CategoryTestController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());

        public async Task<IActionResult> Index()
        {

            var categories = await categoryManager.GetList();

            var filter = new CategoryFilterDto();

            var model = new CategoriesViewModel
            {
                Categories = categories,
                FilterDto = filter
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Filter(CategoryFilterDto filterDto)
        {
            var categories = await categoryManager.GetList();

            if (!string.IsNullOrEmpty(filterDto.Name))
            {
                categories = categories.Where(p => p.Name == filterDto.Name).ToList();
            }

            if (filterDto.Status > 0)
            {
                categories = categories.Where(p => p.Status.Equals(filterDto.Status)).ToList();
            }

            if (filterDto.Active == "1")
            {
                categories = categories.Where(p => p.Active == true).ToList();
            }
            else if (filterDto.Active == "2")
            {
                categories = categories.Where(p => p.Active == false).ToList();
            }

            var categoryData = categories.Select(p => new
            {
                ID = p.ID,
                Name = p.Name,
                Active = p.Active,
                Status = p.Status,
            });

            return Json(categoryData);
        }

        [HttpPost]
        public async Task<IActionResult> AddEditCategory(CategoryAddDto category)
        {
            string message = "";

            if (category != null)
            {
                try
                {
                    var categoryToUpdate = await categoryManager.GetByID(category.ID);
                    bool isUpdate = categoryToUpdate != null;

                    Category categoryEntity;

                    if (isUpdate)
                    {
                        categoryEntity = categoryToUpdate;
                    }
                    else
                    {
                        categoryEntity = new Category();
                    }

                    categoryEntity.Name = category.Name;
                    categoryEntity.Status = category.Status;
                    if (categoryEntity.Status == (CategoryStatuses)1)
                    {

                        categoryEntity.Active = true;
                    }
                    else
                    {
                        categoryEntity.Active = false;
                    }

                    if (isUpdate)
                    {
                        await categoryManager.Update(categoryEntity);
                        message = "Kategori başarıyla güncellendi!";
                    }
                    else
                    {
                        await categoryManager.Add(categoryEntity);
                        message = "Kategori başarıyla kaydedildi!";
                    }
                }
                catch (Exception)
                {
                    message = "Kategori eklenirken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
                }

            }
            else
            {
                message = "Hata oluştu!";
            }

            return Json(message);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCategory(CategoryRemoveDto category)
        {
            string message = "";

            if (category != null)
            {
                try
                {
                    var categoryToRemove = await categoryManager.GetByID(category.ID);

                    if (categoryToRemove != null)
                    {
                        categoryToRemove.Status = (CategoryStatuses)2;
                        categoryToRemove.Active = false;
                        await categoryManager.Update(categoryToRemove);

                        message = "Kategori başarıyla kaldırıldı!";
                    }
                    else
                    {
                        message = "Kaldırılmak istenen kategori bulunamadı!";
                    }
                }
                catch (Exception)
                {
                    message = "Kategori kaldırılırken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
                }
            }
            else
            {
                message = "Hata oluştu!";
            }


            return Json(message);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveCategory(CategoryApproveDto category)
        {
            string message = "";

            if (category != null)
            {
                try
                {
                    var categoryToApprove = await categoryManager.GetByID(category.ID);

                    if (categoryToApprove != null)
                    {
                        categoryToApprove.Status = (CategoryStatuses)1;
                        categoryToApprove.Active = true;
                        await categoryManager.Update(categoryToApprove);

                        message = "Kategori başarıyla onaylandı!";
                    }
                    else
                    {
                        message = "Onaylanmak istenen kategori bulunamadı!";
                    }
                }
                catch (Exception)
                {
                    message = "Kategori onaylanırken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
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
