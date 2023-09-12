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
using Yesil_Vadi_Metalurji.Models;

namespace Yesil_Vadi_Metalurji.Controllers
{
    [Authorize(Policy = "MelhOnly")]
    public class SuggestionsTestController : Controller
    {
        SuggestionManager suggestionManager = new SuggestionManager(new EFSuggestionRepository());

        public async Task<IActionResult> Index()
        {
            var suggestions = await suggestionManager.GetList();
            var filterDto = new SuggestionFilterDto();

            var model = new SuggestionViewModel
            {
                Suggestion = suggestions,
                FilterDto = filterDto
            };

            return View(model);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetSuggestionDetails(int suggestionId)
        {
            var suggestions = await suggestionManager.GetList();
            var details = suggestions.Where(p => p.ID == suggestionId).ToList();

            if (details != null)
            {
                var suggestionData = new List<object>();

                foreach (var detail in details)
                {
                    var detailData = new
                    {
                        ID = detail.ID,
                        Mail = detail.Mail,
                        Content = detail.Content,
                    };

                    suggestionData.Add(detailData);
                }

                return Json(suggestionData);
            }
            else
            {
                return Json(new[] { new { result = "Bir sorun oluştu." } });
            }
        }


        [HttpPost]
        public async Task<IActionResult> Filter(SuggestionFilterDto filterDto)
        {
            var suggestions = await suggestionManager.GetList();

            if (!string.IsNullOrEmpty(filterDto.Mail))
            {
                suggestions = suggestions.Where(p => p.Mail == filterDto.Mail).ToList();
            }

            if (!string.IsNullOrEmpty(filterDto.Content))
            {
                suggestions = suggestions.Where(p => p.Content == filterDto.Content).ToList();
            }

            if (filterDto.Status > 0)
            {
                suggestions = suggestions.Where(p => p.Status.Equals(filterDto.Status)).ToList();
            }

            var suggestionData = suggestions.Select(p => new
            {
                ID = p.ID,
                Mail = p.Mail,
                Status = p.Status,
                Content = p.Content
            });

            return Json(suggestionData);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveSuggestion(SuggestionApproveDto category)
        {
            string message = "";

            if (category != null)
            {
                try
                {
                    var suggestionToApprove = await suggestionManager.GetByID(category.ID);

                    if (suggestionToApprove != null)
                    {
                        suggestionToApprove.Status = (SuggestionStatuses)1;
                        await suggestionManager.Update(suggestionToApprove);

                        message = "Öneri/Görüş başarıyla onaylandı!";
                    }
                    else
                    {
                        message = "Onaylanmak istenen öneri/görüş bulunamadı!";
                    }
                }
                catch (Exception)
                {
                    message = "Öneri/Görüş onaylanırken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
                }
            }
            else
            {
                message = "Hata oluştu!";
            }

            return Json(message);
        }

        [HttpPost]
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
