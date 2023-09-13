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
    public class UrunlerPageController : Controller
    {
        UrunlerManager urunlerManager = new UrunlerManager(new EFUrunlerRepository());
        public async Task<IActionResult> Index()
        {
            var urunler = await urunlerManager.GetList();

            var filter = new UrunlerEditDto();

            var model = new UrunlerPageViewModel
            {
                FilterDto = filter,
                Urunler = urunler,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UrunlerEditDto urunler)
        {
            if (ModelState.IsValid)
            {
                var updatedUrunler = await urunlerManager.GetByID(urunler.ID);
                if (updatedUrunler != null)
                {
                    updatedUrunler.Content = urunler.Content;
                    updatedUrunler.Title = urunler.Title;
                    updatedUrunler.Subtitle = urunler.Subtitle;
                    updatedUrunler.Status = (UrunlerStatuses)urunler.Status;


                    if (urunler.SubtitleStatus == "1")
                    {
                        updatedUrunler.SubtitleStatus = true;
                    }
                    else
                    {
                        updatedUrunler.SubtitleStatus = false;
                    }

                    if (urunler.TitleStatus == "1")
                    {
                        updatedUrunler.TitleStatus = true;
                    }
                    else
                    {
                        updatedUrunler.TitleStatus = false;
                    }

                    if (urunler.ContentStatus == "1")
                    {
                        updatedUrunler.ContentStatus = true;
                    }
                    else
                    {
                        updatedUrunler.ContentStatus = false;
                    }
                    if (urunler.Banner == "1")
                    {
                        updatedUrunler.Banner = true;
                    }
                    else
                    {
                        updatedUrunler.Banner = false;
                    }
                    if (updatedUrunler.Status == (UrunlerStatuses)1)
                    {
                        updatedUrunler.Active = true;
                    }
                    else
                    {
                        updatedUrunler.Active = false;
                    }



                    await urunlerManager.Update(updatedUrunler);
                }

                return RedirectToAction("Index");
            }

            var filter = new UrunlerEditDto();

            return View("Index", new UrunlerPageViewModel
            {
                FilterDto = filter,
                Urunler = await urunlerManager.GetList()
            });
        }
    }
}
