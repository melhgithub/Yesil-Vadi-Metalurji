using Business.Concrete;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yesil_Vadi_Metalurji.Controllers
{
    public class AboutPageController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EFAboutRepository());
        public async Task<IActionResult> Index()
        {
            var about = await aboutManager.GetList();

            return View(about);
        }
    }
}
