﻿using Business.Concrete;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yesil_Vadi_Metalurji.Dto;
using Yesil_Vadi_Metalurji.Models;

namespace Yesil_Vadi_Metalurji.ViewComponents.FooterSuggestion
{
    public class Suggestion : ViewComponent
    {
        FooterManager footerManager = new FooterManager(new EFFooterRepository());
        SuggestionManager suggestionManager = new SuggestionManager(new EFSuggestionRepository());
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footer = await footerManager.GetList();
            var suggestion = await suggestionManager.GetList();


            var dto = new SuggestionAddDto();

            var model = new FooterSuggestionModel
            {
                Footer = footer,
                Suggestion = suggestion,
                Dto = dto
            };

            return View(model);
        }
    }
}
