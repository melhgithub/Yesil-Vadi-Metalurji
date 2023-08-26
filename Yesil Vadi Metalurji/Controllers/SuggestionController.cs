using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yesil_Vadi_Metalurji.Controllers
{
    public class SuggestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
