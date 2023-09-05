using Business.Concrete;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yesil_Vadi_Metalurji.Models;

namespace Yesil_Vadi_Metalurji.ViewComponents.FooterLinks
{
    public class Link : ViewComponent
    {
        FooterManager footerManager = new FooterManager(new EFFooterRepository());
        LinkManager linkManager = new LinkManager(new EFLinkRepository());
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footer = await footerManager.GetList();
            var link = await linkManager.GetList();

            var model = new FooterLinkModel
            {
                Footer = footer,
                Link = link,
            };

            return View(model);
        }
    }
}
