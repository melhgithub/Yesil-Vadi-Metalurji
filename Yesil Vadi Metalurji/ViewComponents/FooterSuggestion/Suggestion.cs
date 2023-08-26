using Business.Concrete;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yesil_Vadi_Metalurji.ViewComponents.FooterSuggestion
{
    public class Suggestion : ViewComponent
    {
        FooterManager footerManager = new FooterManager(new EFFooterRepository());
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footer = await footerManager.GetList();

            return View(footer);
        }
    }
}
