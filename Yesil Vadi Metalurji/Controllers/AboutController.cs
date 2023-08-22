using Business.Concrete;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yesil_Vadi_Metalurji.Models;

namespace Yesil_Vadi_Metalurji.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EFAboutRepository());
        ImageManager imageManager = new ImageManager(new EFImageRepository());
        public async Task<IActionResult> Index()
        {
            var about = await aboutManager.GetList();
            var images = await imageManager.GetList();

            var model = new AboutViewModel
            {
                About = about,
                Images = images
            };

            return View(model);
        }
    }
}
