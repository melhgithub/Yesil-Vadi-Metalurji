using Business.Concrete;
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
    [Authorize(Policy = "MelhOnly")]
    public class HomePageTestController : Controller
    {
        HomePageManager homepageManager = new HomePageManager(new EFHomePageRepository());
        ImageManager imageManager = new ImageManager(new EFImageRepository());
        public async Task<IActionResult> Index()
        {
            var homepages = await homepageManager.GetList();

            var images = await imageManager.GetList();

            var filter = new HomePageEditDto();

            var model = new HomePageTestViewModel
            {
                FilterDto = filter,
                HomePage = homepages,
                Images = images
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(HomePageEditDto homepage)
        {
            if (ModelState.IsValid)
            {
                var updatedPage = await homepageManager.GetByID(homepage.ID);
                if (updatedPage != null)
                {
                    updatedPage.Content = homepage.Content;
                    updatedPage.Title = homepage.Title;
                    updatedPage.Subtitle = homepage.Subtitle;
                    updatedPage.IsOrtaklarimiz = homepage.IsOrtaklarimiz;
                    updatedPage.SayisalVeri1 = homepage.SayisalVeri1;
                    updatedPage.SayisalVeri2 = homepage.SayisalVeri2;
                    updatedPage.SayisalVeriYazisi = homepage.SayisalVeriYazisi;
                    updatedPage.Hizmetlerimiz = homepage.Hizmetlerimiz;
                    updatedPage.Aciklama1 = homepage.Aciklama1;
                    updatedPage.Aciklama2 = homepage.Aciklama2;
                    updatedPage.Aciklama3 = homepage.Aciklama3;
                    updatedPage.Status = (HomePageStatuses)homepage.Status;
                    if (homepage.Image == "1")
                    {
                        updatedPage.Image = true;
                    }
                    else
                    {
                        updatedPage.Image = false;
                    }


                    if (homepage.SubtitleStatus == "1")
                    {
                        updatedPage.SubtitleStatus = true;
                    }
                    else
                    {
                        updatedPage.SubtitleStatus = false;
                    }


                    if (homepage.TitleStatus == "1")
                    {
                        updatedPage.TitleStatus = true;
                    }
                    else
                    {
                        updatedPage.TitleStatus = false;
                    }

                    if (homepage.ContentStatus == "1")
                    {
                        updatedPage.ContentStatus = true;
                    }
                    else
                    {
                        updatedPage.ContentStatus = false;
                    }
                    if (homepage.Banner == "1")
                    {
                        updatedPage.Banner = true;
                    }
                    else
                    {
                        updatedPage.Banner = false;
                    }
                    if (updatedPage.Status == (HomePageStatuses)1)
                    {
                        updatedPage.Active = true;
                    }
                    else
                    {
                        updatedPage.Active = false;
                    }


                    if (homepage.HakkimizdaFoto1 != null)
                    {
                        int imageid = int.Parse(homepage.HakkimizdaFoto1);
                        var image = await imageManager.GetByID(imageid);
                        homepage.HakkimizdaFoto1 = image.Name;
                    }
                    if (homepage.HakkimizdaFoto2 != null)
                    {
                        int imageid = int.Parse(homepage.HakkimizdaFoto2);
                        var image = await imageManager.GetByID(imageid);
                        homepage.HakkimizdaFoto2 = image.Name;
                    }
                    if (homepage.HizmetlerimizFoto1 != null)
                    {
                        int imageid = int.Parse(homepage.HizmetlerimizFoto1);
                        var image = await imageManager.GetByID(imageid);
                        homepage.HizmetlerimizFoto1 = image.Name;
                    }
                    if (homepage.HizmetlerimizFoto2 != null)
                    {
                        int imageid = int.Parse(homepage.HizmetlerimizFoto2);
                        var image = await imageManager.GetByID(imageid);
                        homepage.HizmetlerimizFoto2 = image.Name;
                    }
                    if (homepage.HizmetlerimizFoto3 != null)
                    {
                        int imageid = int.Parse(homepage.HizmetlerimizFoto3);
                        var image = await imageManager.GetByID(imageid);
                        homepage.HizmetlerimizFoto3 = image.Name;
                    }
                    if (homepage.IsOrtaklarimizFoto1 != null)
                    {
                        int imageid = int.Parse(homepage.IsOrtaklarimizFoto1);
                        var image = await imageManager.GetByID(imageid);
                        homepage.IsOrtaklarimizFoto1 = image.Name;
                    }
                    if (homepage.IsOrtaklarimizFoto2 != null)
                    {
                        int imageid = int.Parse(homepage.IsOrtaklarimizFoto2);
                        var image = await imageManager.GetByID(imageid);
                        homepage.IsOrtaklarimizFoto2 = image.Name;
                    }
                    if (homepage.IsOrtaklarimizFoto3 != null)
                    {
                        int imageid = int.Parse(homepage.IsOrtaklarimizFoto3);
                        var image = await imageManager.GetByID(imageid);
                        homepage.IsOrtaklarimizFoto3 = image.Name;
                    }
                    if (homepage.IsOrtaklarimizFoto4 != null)
                    {
                        int imageid = int.Parse(homepage.IsOrtaklarimizFoto4);
                        var image = await imageManager.GetByID(imageid);
                        homepage.IsOrtaklarimizFoto4 = image.Name;
                    }
                    if (homepage.IsOrtaklarimizFoto5 != null)
                    {
                        int imageid = int.Parse(homepage.IsOrtaklarimizFoto5);
                        var image = await imageManager.GetByID(imageid);
                        homepage.IsOrtaklarimizFoto5 = image.Name;
                    }
                    if (homepage.IsOrtaklarimizFoto6 != null)
                    {
                        int imageid = int.Parse(homepage.IsOrtaklarimizFoto6);
                        var image = await imageManager.GetByID(imageid);
                        homepage.IsOrtaklarimizFoto6 = image.Name;
                    }
                    if (homepage.ImageUrl1 != null)
                    {
                        int imageid = int.Parse(homepage.ImageUrl1);
                        var image = await imageManager.GetByID(imageid);
                        homepage.ImageUrl1 = image.Name;
                    }
                    if (homepage.ImageUrl2 != null)
                    {
                        int imageid = int.Parse(homepage.ImageUrl2);
                        var image = await imageManager.GetByID(imageid);
                        homepage.ImageUrl2 = image.Name;
                    }
                    if (homepage.ImageUrl3 != null)
                    {
                        int imageid = int.Parse(homepage.ImageUrl3);
                        var image = await imageManager.GetByID(imageid);
                        homepage.ImageUrl3 = image.Name;
                    }
                    if (homepage.ImageUrl4 != null)
                    {
                        int imageid = int.Parse(homepage.ImageUrl4);
                        var image = await imageManager.GetByID(imageid);
                        homepage.ImageUrl4 = image.Name;
                    }
                    if (homepage.ImageUrl5 != null)
                    {
                        int imageid = int.Parse(homepage.ImageUrl5);
                        var image = await imageManager.GetByID(imageid);
                        homepage.ImageUrl5 = image.Name;
                    }
                    if (homepage.ImageUrl6 != null)
                    {
                        int imageid = int.Parse(homepage.ImageUrl6);
                        var image = await imageManager.GetByID(imageid);
                        homepage.ImageUrl6 = image.Name;
                    }
                    if (homepage.ImageUrl7 != null)
                    {
                        int imageid = int.Parse(homepage.ImageUrl7);
                        var image = await imageManager.GetByID(imageid);
                        homepage.ImageUrl7 = image.Name;
                    }
                    if (homepage.ImageUrl8 != null)
                    {
                        int imageid = int.Parse(homepage.ImageUrl8);
                        var image = await imageManager.GetByID(imageid);
                        homepage.ImageUrl8 = image.Name;
                    }
                    if (homepage.ImageUrl9 != null)
                    {
                        int imageid = int.Parse(homepage.ImageUrl9);
                        var image = await imageManager.GetByID(imageid);
                        homepage.ImageUrl9 = image.Name;
                    }
                    if (homepage.ImageUrl10 != null)
                    {
                        int imageid = int.Parse(homepage.ImageUrl10);
                        var image = await imageManager.GetByID(imageid);
                        homepage.ImageUrl10 = image.Name;
                    }




                    updatedPage.HakkimizdaFoto1 = homepage.HakkimizdaFoto1;
                    updatedPage.HakkimizdaFoto2 = homepage.HakkimizdaFoto2;
                    updatedPage.HizmetlerimizFoto1 = homepage.HizmetlerimizFoto1;
                    updatedPage.HizmetlerimizFoto2 = homepage.HizmetlerimizFoto2;
                    updatedPage.HizmetlerimizFoto3 = homepage.HizmetlerimizFoto3;
                    updatedPage.IsOrtaklarimizFoto1 = homepage.IsOrtaklarimizFoto1;
                    updatedPage.IsOrtaklarimizFoto2 = homepage.IsOrtaklarimizFoto2;
                    updatedPage.IsOrtaklarimizFoto3 = homepage.IsOrtaklarimizFoto3;
                    updatedPage.IsOrtaklarimizFoto4 = homepage.IsOrtaklarimizFoto4;
                    updatedPage.IsOrtaklarimizFoto5 = homepage.IsOrtaklarimizFoto5;
                    updatedPage.IsOrtaklarimizFoto6 = homepage.IsOrtaklarimizFoto6;
                    updatedPage.ImageUrl1 = homepage.ImageUrl1;
                    updatedPage.ImageUrl2 = homepage.ImageUrl2;
                    updatedPage.ImageUrl3 = homepage.ImageUrl3;
                    updatedPage.ImageUrl4 = homepage.ImageUrl4;
                    updatedPage.ImageUrl5 = homepage.ImageUrl5;
                    updatedPage.ImageUrl6 = homepage.ImageUrl6;
                    updatedPage.ImageUrl7 = homepage.ImageUrl7;
                    updatedPage.ImageUrl8 = homepage.ImageUrl8;
                    updatedPage.ImageUrl9 = homepage.ImageUrl9;
                    updatedPage.ImageUrl10 = homepage.ImageUrl10;
                    await homepageManager.Update(updatedPage);
                }

                return RedirectToAction("Index");
            }
            var filter = new HomePageEditDto();
            return View("Index", new HomePageTestViewModel
            {
                FilterDto = filter,
                HomePage = await homepageManager.GetList(),
                Images = await imageManager.GetList()
            });
        }
    }
}
