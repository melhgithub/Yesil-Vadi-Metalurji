using Business.Concrete;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Yesil_Vadi_Metalurji.Models;

namespace Yesil_Vadi_Metalurji.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        HomePageManager homePageManager = new HomePageManager(new EFHomePageRepository());

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        ImageManager imageManager = new ImageManager(new EFImageRepository());
        public async Task<IActionResult> Index()
        {
            var homepage = await homePageManager.GetList();
            var images = await imageManager.GetList();

            var model = new HomePageViewModel
            {
                HomePage = homepage,
                Images = images
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
