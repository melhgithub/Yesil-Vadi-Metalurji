using Business.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yesil_Vadi_Metalurji.Dto;

namespace Yesil_Vadi_Metalurji.Controllers
{
    public class SuggestionsController : Controller
    {
        SuggestionManager suggestionManager = new SuggestionManager(new EFSuggestionRepository());

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Add(SuggestionAddDto suggestion)
        {
            string message;
            if (ModelState.IsValid)
            {
                var addedSuggestion = new Suggestion
                {
                    Mail = suggestion.Mail,
                    Content = suggestion.Content,
                    Status = (SuggestionStatuses)2,
                };

                await suggestionManager.Add(addedSuggestion);

                message = "Başarılı";
            }
            else
            {
                message = "Başarısız";
            }

            return Json(message);
        }
    }
}
