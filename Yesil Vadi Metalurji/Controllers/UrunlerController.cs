using Business.Concrete;
using Core.Extensions;
using DataAccess.Repositories;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Yesil_Vadi_Metalurji.Dto;
using Yesil_Vadi_Metalurji.Models;

namespace Yesil_Vadi_Metalurji.Controllers
{
    [AllowAnonymous]
    public class UrunlerController : Controller
    {
        ProductManager productManager = new ProductManager(new EFProductRepository());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());
        public async Task<IActionResult> Index()
        {
            var products = await productManager.GetListWithIncludes();
            products = products.Where(p => p.Active == true && p.Status == (ProductStatuses)1).ToList();
            products = products.Where(p => p.ImageUrl1 != null).ToList();
            var categories = await categoryManager.GetList();


            var filterDto = new ProductFilterDto
            {
                Categories = categories
            };

            var model = new ProductsViewModel
            {
                FilterDto = filterDto,
                Products = products
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

            if (filterDto.CategoryID.HasValue) products = products.Where(p => p.CategoryID == filterDto.CategoryID).ToList();


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
                Imageurla = p.ImageUrl1,
                Imageurlb = p.ImageUrl2,
                Imageurlc = p.ImageUrl3,
                Imageurld = p.ImageUrl4,
                Imageurle = p.ImageUrl5,
                Imageurlf = p.ImageUrl6,
                Description = p.Description
            });

            return Json(productData);
        }

        [HttpGet]
        public async Task<IActionResult> UrunDetaylari(int urunID)
        {
            var product = await productManager.GetByID(urunID);
            var products = await productManager.GetList();
            products = products.Where(p => p.ID == product.ID).ToList();
            if (product != null && product.ImageUrl1!=null)
            {
                if (product.Active == false || product.Status == (ProductStatuses)2)
                {
                    return RedirectToAction("Urunler");
                }
                else
                {
                    var categories = await categoryManager.GetList();


                    var filterDto = new ProductFilterDto
                    {
                        Categories = categories
                    };

                    var model = new ProductsViewModel
                    {
                        FilterDto = filterDto,
                        Products = products
                    };

                    return View(model);
                }
            }
            else
            {
                return RedirectToAction("Urunler");
            }
            
        }
    }
}
