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
        UrunlerManager urunlerManager = new UrunlerManager(new EFUrunlerRepository());
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

            var urunler = await urunlerManager.GetList();
            var model = new ProductsViewModel
            {
                Urunlers = urunler,
                FilterDto = filterDto,
                Products = products
            };

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> UrunDetaylari(int urunID)
        {
            if (urunID == null)
            {
                return RedirectToAction("Urunler");
            }
            else
            {
                try
                {
                    var product = await productManager.GetByID(urunID);
                    if (product == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        var products = await productManager.GetListWithIncludes();
                        products = products.Where(p => p.ID == product.ID).ToList();
                        if (product != null && product.ImageUrl1 != null)
                        {
                            if (product.Active == false || product.Status == (ProductStatuses)2)
                            {
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                var categories = await categoryManager.GetList();


                                var filterDto = new ProductFilterDto
                                {
                                    Categories = categories
                                };
                                var urunler = await urunlerManager.GetList();
                                var model = new ProductsViewModel
                                {
                                    Urunlers = urunler,
                                    FilterDto = filterDto,
                                    Products = products
                                };

                                return View(model);
                            }
                        }
                        else
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                catch
                {
                    return RedirectToAction("Index");
                }
                
            }
           
            
        }

    }
}
