using Business.Concrete;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yesil_Vadi_Metalurji.Dto;
using Yesil_Vadi_Metalurji.Models;

namespace Yesil_Vadi_Metalurji.Controllers
{
    public class LinkController : Controller
    {
        LinkManager linkManager = new LinkManager(new EFLinkRepository());
        public async Task<IActionResult> Index()
        {

            var links = await linkManager.GetList();

            var filter = new LinkEditDto();

            var model = new LinkEditViewModel
            {
                Dto = filter,
                Link = links,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(LinkEditDto link)
        {
            if (ModelState.IsValid)
            {
                var updatedLink = await linkManager.GetByID(link.ID);
                if (updatedLink != null)
                {
                    updatedLink.Facebook = link.Facebook;
                    updatedLink.Whatsapp = link.Whatsapp;
                    updatedLink.GoogleP = link.GoogleP;
                    updatedLink.Instagram = link.Instagram;
                    updatedLink.Pinterest = link.Pinterest;
                    updatedLink.Twitter = link.Twitter;
                    updatedLink.Status = link.Status;
                    if (link.FacebookStatus == "2")
                    {
                        updatedLink.FacebookStatus = false;
                    }
                    else
                    {
                        updatedLink.FacebookStatus = true;
                    }
                    if (link.TwitterStatus == "2")
                    {
                        updatedLink.TwitterStatus = false;
                    }
                    else
                    {
                        updatedLink.TwitterStatus = true;
                    }
                    if (link.InstagramStatus == "2")
                    {
                        updatedLink.InstagramStatus = false;
                    }
                    else
                    {
                        updatedLink.InstagramStatus = true;
                    }
                    if (link.WhatsappStatus == "2")
                    {
                        updatedLink.WhatsappStatus = false;
                    }
                    else
                    {
                        updatedLink.WhatsappStatus = true;
                    }
                    if (link.PinterestStatus == "2")
                    {
                        updatedLink.PinterestStatus = false;
                    }
                    else
                    {
                        updatedLink.PinterestStatus = true;
                    }
                    if (link.GooglePStatus == "2")
                    {
                        updatedLink.GooglePStatus = false;
                    }
                    else
                    {
                        updatedLink.GooglePStatus = true;
                    }

                    await linkManager.Update(updatedLink);
                }

                return RedirectToAction("Index");
            }

            var filter = new LinkEditDto();
            return View("Index", new LinkEditViewModel
            {
                Dto = filter,
                Link = await linkManager.GetList(),
            });
        }
    }
}
