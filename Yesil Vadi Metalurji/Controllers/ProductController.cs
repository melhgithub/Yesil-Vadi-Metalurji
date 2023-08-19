using Business.Concrete;
using Core.Extensions;
using DataAccess.Repositories;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yesil_Vadi_Metalurji.Dto;
using Yesil_Vadi_Metalurji.Models;

namespace Yesil_Vadi_Metalurji.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EFProductRepository());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());
        ImageManager imageManager = new ImageManager(new EFImageRepository());

        public async Task<IActionResult> Index()
        {
            var products = await productManager.GetListWithIncludes();
            var categories = await categoryManager.GetList();
            var images = await imageManager.GetList();

            var filter = new ProductFilterDto
            {
                Categories = categories,
                Images = images
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

            if (filterDto.Image == "1")
            {
                products = products.Where(p => p.ImageUrl1 != null || p.ImageUrl2 != null || p.ImageUrl3 != null || p.ImageUrl4 != null || p.ImageUrl5 != null || p.ImageUrl6 != null).ToList();
            }

            else if (filterDto.Image == "2")
            {
                products = products.Where(p => p.ImageUrl1 == null && p.ImageUrl2 == null && p.ImageUrl3 == null).ToList();
                products = products.Where(p => p.ImageUrl4 == null && p.ImageUrl5 == null && p.ImageUrl6 == null).ToList();
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
                imageurla = p.ImageUrl1,
                imageurlb = p.ImageUrl2,
                imageurlc = p.ImageUrl3,
                imageurld = p.ImageUrl4,
                imageurle = p.ImageUrl5,
                imageurlf = p.ImageUrl6
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
                    if (productEntity.Status == (ProductStatuses)1)
                    {
                        productEntity.Active = true;
                    }
                    else
                    {
                        productEntity.Active = false;
                    }
                    productEntity.Description = product.Description;

                    if (product.ImageUrl1 != null)
                    {
                        int.TryParse(product.ImageUrl1, out int imageurl);
                        var image = await imageManager.GetByID(imageurl);
                        productEntity.ImageUrl1 = image.Name;
                    }
                    if (productEntity.ID > 0 && product.ImageUrl1 == null)
                    {
                        productEntity.ImageUrl1 = null;
                    }

                    if (product.ImageUrl2 != null)
                    {
                        int.TryParse(product.ImageUrl2, out int imageurl);
                        var image = await imageManager.GetByID(imageurl);
                        productEntity.ImageUrl2 = image.Name;
                    }
                    if (productEntity.ID > 0 && product.ImageUrl2 == null)
                    {
                        productEntity.ImageUrl2 = null;
                    }

                    if (product.ImageUrl3 != null)
                    {
                        int.TryParse(product.ImageUrl3, out int imageurl);
                        var image = await imageManager.GetByID(imageurl);
                        productEntity.ImageUrl3 = image.Name;
                    }
                    if (productEntity.ID > 0 && product.ImageUrl3 == null)
                    {
                        productEntity.ImageUrl3 = null;
                    }

                    if (product.ImageUrl4 != null)
                    {
                        int.TryParse(product.ImageUrl4, out int imageurl);
                        var image = await imageManager.GetByID(imageurl);
                        productEntity.ImageUrl4 = image.Name;
                    }
                    if (productEntity.ID > 0 && product.ImageUrl4 == null)
                    {
                        productEntity.ImageUrl4 = null;
                    }

                    if (product.ImageUrl5 != null)
                    {
                        int.TryParse(product.ImageUrl5, out int imageurl);
                        var image = await imageManager.GetByID(imageurl);
                        productEntity.ImageUrl5 = image.Name;
                    }
                    if (productEntity.ID > 0 && product.ImageUrl5 == null)
                    {
                        productEntity.ImageUrl5 = null;
                    }

                    if (product.ImageUrl6 != null)
                    {
                        int.TryParse(product.ImageUrl6, out int imageurl);
                        var image = await imageManager.GetByID(imageurl);
                        productEntity.ImageUrl6 = image.Name;
                    }
                    if (productEntity.ID > 0 && product.ImageUrl6 == null)
                    {
                        productEntity.ImageUrl6 = null;
                    }


                    if (productEntity.ID > 0)
                    {
                        await productManager.Update(productEntity);
                    }
                    else
                    {
                        await productManager.Add(productEntity);
                    }

                    message = productEntity.ID > 0 ? "Ürün başarıyla güncellendi!" : "Ürün başarıyla kaydedildi!";
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
