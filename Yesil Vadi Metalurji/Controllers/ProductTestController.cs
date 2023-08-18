using Business.Concrete;
using Core.Extensions;
using DataAccess.Repositories;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Yesil_Vadi_Metalurji.Dto;
using Yesil_Vadi_Metalurji.Models;

namespace Yesil_Vadi_Metalurji.Controllers
{
    [Authorize(Policy = "MelhOnly")]
    public class ProductTestController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public ProductTestController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        ProductManager productManager = new ProductManager(new EFProductRepository());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());

        public async Task<IActionResult> Index()
        {
            var products = await productManager.GetListWithIncludes();
            var categories = await categoryManager.GetList();

            var filter = new ProductFilterDto
            {
                Categories = categories
            };

            var model = new ProductsViewModel
            {
                Products = products,
                FilterDto = filter
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Filter(ProductFilterDto filterDto)
        {

            var products = await productManager.GetListWithIncludes();

            if (!string.IsNullOrEmpty(filterDto.Name)) products = products.Where(p => p.Name == filterDto.Name).ToList();

            if (!string.IsNullOrEmpty(filterDto.Material)) products = products.Where(p => p.Material == filterDto.Material).ToList();

            if (!string.IsNullOrEmpty(filterDto.Description)) products = products.Where(p => p.Description == filterDto.Description).ToList();

            if (!string.IsNullOrEmpty(filterDto.Price))
            {
                products = products.Where(p => p.Price == filterDto.Price.ToDecimal()).ToList();
            }

            if (filterDto.Piece > 0) products = products.Where(p => p.Piece == filterDto.Piece).ToList();

            if (filterDto.Status > 0) products = products.Where(p => p.Status.Equals(filterDto.Status)).ToList();

            if (filterDto.CategoryStatus > 0) products = products.Where(p => p.Category.Status.Equals(filterDto.CategoryStatus)).ToList();

            if (filterDto.CategoryID.HasValue) products = products.Where(p => p.CategoryID == filterDto.CategoryID).ToList();

            if (filterDto.Active == "1")
            {
                products = products.Where(p => p.Active == true).ToList();
            }
            else if (filterDto.Active == "2")
            {
                products = products.Where(p => p.Active == false).ToList();
            }
            if (filterDto.CategoryActive == "1")
            {
                products = products.Where(p => p.Category.Active == true).ToList();
            }
            else if (filterDto.CategoryActive == "2")
            {
                products = products.Where(p => p.Category.Active == false).ToList();
            }

            var productData = products.Select(p => new
            {
                ID = p.ID,
                Category = new { p.Category.ID, Name = p.Category.Name },
                Name = p.Name,
                Material = p.Material,
                Price = p.Price,
                Piece = p.Piece,
                Status = p.Status,
                Active = p.Active,
                Description = p.Description,
                ImageUrl1 = p.ImageUrl1,
                ImageUrl2 = p.ImageUrl2,
                ImageUrl3 = p.ImageUrl3,
                ImageUrl4 = p.ImageUrl4,
                ImageUrl5 = p.ImageUrl5,
                ImageUrl6 = p.ImageUrl6
            });

            return Json(productData);
        }

        [HttpPost]
        public async Task<IActionResult> AddEditProduct(ProductAddEditDto product)
        {
            string message;

            if (product != null)
            {
                try
                {
                    var productEntity = product.ID > 0 ? await productManager.GetByID(product.ID) : new Product();

                    productEntity.CategoryID = product.CategoryID;
                    productEntity.Material = product.Material;
                    productEntity.Name = product.Name;
                    productEntity.Piece = product.Piece;
                    productEntity.Price = product.Price.ToDecimal();
                    productEntity.Status = product.Status;
                    productEntity.Active = product.Active;
                    productEntity.Description = product.Description;

                    if (product.ImageUrl1 != null)
                    {
                    }
                    if (product.ImageUrl2 != null)
                    {
                    }
                    if (product.ImageUrl3 != null)
                    {
                    }
                    if (product.ImageUrl4 != null)
                    {
                    }
                    if (product.ImageUrl5 != null)
                    {
                    }
                    if (product.ImageUrl6 != null)
                    {
                    }


                    if (productEntity.ID > 0)
                    {
                        await productManager.Update(productEntity);
                        message = "Ürün başarıyla güncellendi!";
                    }
                    else
                    {
                        await productManager.Add(productEntity);
                        message = "Ürün başarıyla kaydedildi!";
                    }
                }
                catch (Exception)
                {
                    message = "Lütfen bilgileri kontrol ediniz.";
                }
            }
            else
            {
                message = "Hata oluştu!";
            }

            return Json(message);

        }

        [HttpPost]
        public async Task<IActionResult> ApproveProduct(ProductApproveDto product)
        {
            string message;

            if (product != null)
            {
                try
                {
                    var productToApprove = await productManager.GetByID(product.ID);

                    if (productToApprove != null)
                    {

                        productToApprove.Status = (ProductStatuses)1;
                        productToApprove.Active = true;

                        message = "Ürün başarıyla onaylandı!";

                        await productManager.Update(productToApprove);
                    }
                    else
                    {
                        message = "Onaylanmak istenen ürün bulunamadı!";
                    }
                }
                catch (Exception)
                {
                    message = "Ürün onaylanırken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
                }
            }
            else
            {
                message = "Hata oluştu!";
            }

            return Json(message);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProduct(ProductRemoveDto product)
        {
            string message;

            if (product != null)
            {
                try
                {
                    var productToRemove = await productManager.GetByID(product.ID);

                    if (productToRemove != null)
                    {
                        productToRemove.Status = (ProductStatuses)2;
                        productToRemove.Active = false;
                        await productManager.Update(productToRemove);
                        message = "Ürün başarıyla kaldırıldı!";
                    }
                    else
                    {
                        message = "Kaldırılmak istenen ürün bulunamadı!";
                    }
                }
                catch (Exception)
                {
                    message = "Ürün kaldırılırken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
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
