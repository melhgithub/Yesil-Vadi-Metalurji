using Business.Concrete;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yesil_Vadi_Metalurji.ViewComponents.HeaderComponent
{
    public class Header : ViewComponent
    {
        LinkManager linkManager = new LinkManager(new EFLinkRepository());
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var link = await linkManager.GetList();


            return View(link);
        }
    }
}
