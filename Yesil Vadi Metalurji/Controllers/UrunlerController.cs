﻿using Business.Concrete;
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
        OfferManager offerManager = new OfferManager(new EFOfferRepository());
        OfferDetailManager offerDetailManager = new OfferDetailManager(new EFOfferDetailRepository());
        public async Task<IActionResult> Index()
        {
            var products = await productManager.GetListWithIncludes();
            products = products.Where(p => p.Active == true && p.Status == (ProductStatuses)1).ToList();
            products = products.Where(p => p.ImageUrl1 != null).ToList();
            var categories = await categoryManager.GetList();

            var firstActiveCategory = categories.Where(c => c.Status == (CategoryStatuses)1 && c.Active == true).Take(1).ToList();

            foreach(var category in firstActiveCategory)
            {
                products = products.Where(p => p.Category.Name == category.Name).ToList();
            }

            var filterDto = new ProductFilterDto
            {
                Categories = categories
            };

            var urunler = await urunlerManager.GetList();
            var model = new ProductsViewModel
            {
                Urunlers = urunler,
                Categories = categories,
                FilterDto = filterDto,
                Products = products,
                Category = firstActiveCategory
            };

            return View("Kategori",model);
        }


        [HttpGet]
        public async Task<IActionResult> Kategori(int kategoriID)
        {
            if (kategoriID == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                try
                {
                    var category = await categoryManager.GetByID(kategoriID);
                    if (category == null || category.Active!=true || category.Status!=(CategoryStatuses)1)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        var products = await productManager.GetListWithIncludes();
                        products = products.Where(p => p.CategoryID == category.ID).ToList();
                        products = products.Where(p => p.Active == true && p.Status == (ProductStatuses)1).ToList();
                        products = products.Where(p => p.ImageUrl1 != null).ToList();
                        var categories = await categoryManager.GetList();
                        var categoryy = categories.Where(p => p.ID == kategoriID).ToList();
                        if (products != null && category.Active != false && category.Status == (CategoryStatuses)1)
                        {
                            var filterDto = new ProductFilterDto
                            {
                                Categories = categories
                            };

                            var urunler = await urunlerManager.GetList();
                            var model = new ProductsViewModel
                            {
                                Urunlers = urunler,
                                Categories = categories,
                                Category = categoryy,
                                FilterDto = filterDto,
                                Products = products
                            };

                            return View(model);

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
                    if (product == null && product.Active==true && product.Status==(ProductStatuses)1)
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

                                var category = categories.Where(p => p.ID == product.CategoryID).ToList();

                                var filterDto = new ProductFilterDto
                                {
                                    Categories = categories
                                };
                                var urunler = await urunlerManager.GetList();
                                var model = new ProductsViewModel
                                {
                                    Urunlers = urunler,
                                    Categories = categories,
                                    FilterDto = filterDto,
                                    Category = category,
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

        [HttpPost]
        public async Task<IActionResult> SubmitOffer(OfferAddDto offer)
        {
            string message = "Bir hata oluştu, lütfen sistem yöneticisi ile irtibata geçiniz.";
            var products = await productManager.GetListWithIncludes();
            var product = products.Where(p => p.ID == offer.ProductID).ToList();
            if (product != null)
            {
                foreach(var p in product)
                {
                    if (p.Active == true)
                    {
                        var toplamfiyat = offer.ProductPiece * p.Price;
                        var offerToAdd = new Offer
                        {
                            Status = (OfferStatuses)5,
                            Active = true,
                            Name =offer.Name,
                            LastName=offer.LastName,
                            PhoneNumber=offer.PhoneNumber,
                            Mail=offer.Mail,
                            ProductPiece=1,
                            TotalPiece=offer.ProductPiece,
                            TotalPrice=toplamfiyat,
                            CreateDate= DateTime.Parse(DateTime.Now.ToShortDateString()),

                        };

                        await offerManager.Add(offerToAdd);

                        var addedOffer = await offerManager.GetByID(offerToAdd.ID);

                        var offerDetailToAdd = new OfferDetail
                        {
                            OfferID = addedOffer.ID,
                            Name = addedOffer.Name,
                            LastName = addedOffer.LastName,
                            Mail = addedOffer.Mail,
                            PhoneNumber = addedOffer.PhoneNumber,
                            ProductID = offer.ProductID,
                            ProductName = p.Name,
                            Price = toplamfiyat,
                            Piece = offer.ProductPiece,
                            CreateDate = addedOffer.CreateDate
                        };

                        await offerDetailManager.Add(offerDetailToAdd);

                        message = "Başarılı.";
                    }
                    else
                    {
                        message = "Bir sorun oluştu, lütfen yöneticiyle irtibata geçiniz.";
                    }
                }
            }

            return Json(message);
        }


    }
}
