using Business.Concrete;
using DataAccess.Repositories;
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
    public class FooterController : Controller
    {
        FooterManager footerManager = new FooterManager(new EFFooterRepository());
        public async Task<IActionResult> Index()
        {
            var footer = await footerManager.GetList();

            var filter = new FooterEditDto();

            var model = new FooterEditViewModel
            {
                FilterDto = filter,
                Footer = footer,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(FooterEditDto footer)
        {
            if (ModelState.IsValid)
            {
                var updatedFooter = await footerManager.GetByID(footer.ID);
                if (updatedFooter != null)
                {
                    updatedFooter.Title = footer.Title;
                    updatedFooter.Content = footer.Content;
                    updatedFooter.Content = footer.Content;
                    if (footer.Suggestion == "2")
                    {
                        updatedFooter.Suggestion = false;
                    }
                    else
                    {
                        updatedFooter.Suggestion = true;
                    }
                    if (footer.LastPosts == "2")
                    {
                        updatedFooter.LastPosts = false;
                    }
                    else
                    {
                        updatedFooter.LastPosts = true;
                    }

                    await footerManager.Update(updatedFooter);
                }

                return RedirectToAction("Index");
            }

            var filter = new FooterEditDto();
            return View("Index", new FooterEditViewModel
            {
                FilterDto = filter,
                Footer = await footerManager.GetList(),
            });
        }
    }
}
