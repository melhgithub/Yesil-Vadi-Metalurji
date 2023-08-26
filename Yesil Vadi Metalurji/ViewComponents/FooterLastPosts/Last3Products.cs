using Business.Concrete;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yesil_Vadi_Metalurji.Models;

namespace Yesil_Vadi_Metalurji.ViewComponents.FooterLastPosts
{
    public class Last3Products : ViewComponent
    {
        ProductManager productManager = new ProductManager(new EFProductRepository());
        FooterManager footerManager = new FooterManager(new EFFooterRepository());
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var products = await productManager.GetLast3Product();
            var footer = await footerManager.GetList();

            var model = new FooterProductsViewModel
            {
                Products = products,
                Footer = footer
            };

            return View(model);
        }
    }
}
