using Business.Concrete;
using Core.Extensions;
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
    public class ProductionTestController : Controller
    {

        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());
        ProductManager productManager = new ProductManager(new EFProductRepository());
        OfferManager offerManager = new OfferManager(new EFOfferRepository());
        OfferDetailManager offerDetailManager = new OfferDetailManager(new EFOfferDetailRepository());
        OrderManager orderManager = new OrderManager(new EFOrderRepository());
        ProductionManager productionManager = new ProductionManager(new EFProductionRepository());

        public async Task<IActionResult> Index()
        {
            var productions = await productionManager.GetList();

            ProductionFilterDto filter = new ProductionFilterDto();

            var model = new ProductionsViewModel
            {
                Productions = productions,
                FilterDto = filter
            };

            return View(model);
        }

        public async Task<IActionResult> Filter(ProductionFilterDto filterDto)
        {

            var productions = await productionManager.GetList();

            if (!string.IsNullOrEmpty(filterDto.Name)) productions = productions.Where(p => p.Name == filterDto.Name).ToList();

            if (!string.IsNullOrEmpty(filterDto.LastName)) productions = productions.Where(p => p.Name == filterDto.LastName).ToList();

            if (!string.IsNullOrEmpty(filterDto.Mail)) productions = productions.Where(p => p.Mail == filterDto.Mail).ToList();

            if (!string.IsNullOrEmpty(filterDto.PhoneNumber)) productions = productions.Where(p => p.PhoneNumber == filterDto.PhoneNumber).ToList();

            if (!string.IsNullOrEmpty(filterDto.TotalPrice))
            {
                productions = productions.Where(p => p.TotalPrice == filterDto.TotalPrice.ToDecimal()).ToList();
            }



            if (filterDto.TotalPiece > 0) productions = productions.Where(p => p.TotalPiece == filterDto.TotalPiece).ToList();

            if (filterDto.ProductPiece > 0) productions = productions.Where(p => p.ProductPiece == filterDto.ProductPiece).ToList();

            if (filterDto.Status > 0) productions = productions.Where(p => p.Status.Equals(filterDto.Status)).ToList();

            if (filterDto.Active == "1")
            {
                productions = productions.Where(p => p.Active == true).ToList();
            }
            else if (filterDto.Active == "2")
            {
                productions = productions.Where(p => p.Active == false).ToList();
            }


            var offerData = productions.Select(p => new
            {
                ID = p.ID,
                Name = p.Name,
                Lastname = p.LastName,
                Mail = p.Mail,
                Phonenumber = p.PhoneNumber,
                Status = p.Status,
                Active = p.Active,
                Totalpiece = p.TotalPiece,
                Totalprice = p.TotalPrice,
                Productpiece = p.ProductPiece
            });

            return Json(offerData);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveProduction(ProductionApproveDto production)
        {
            string message = "";
            try
            {
                var productionToApprove = await productionManager.GetByID(production.ID);

                if (productionToApprove != null)
                {
                    productionToApprove.Status = (ProductionStatuses)1;
                    productionToApprove.Active = true;
                    await productionManager.Update(productionToApprove);

                    message = "Üretim başarıyla onaylandı!";
                }
                else
                {
                    message = "Onaylanmak istenen üretim bulunamadı!";
                }
            }
            catch (Exception)
            {
                message = "Üretim onaylanırken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
            }

            return Json(message);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProduction(ProductionDeleteDto production)
        {
            string message = "";
            try
            {
                var productionToRemove = await productionManager.GetByID(production.ID);

                if (productionToRemove != null)
                {
                    productionToRemove.Status = (ProductionStatuses)3;
                    productionToRemove.Active = false;
                    await productionManager.Update(productionToRemove);

                    message = "Üretim başarıyla reddedildi!";
                }
                else
                {
                    message = "Reddedilmek istenen üretim bulunamadı!";
                }
            }
            catch (Exception)
            {
                message = "Üretim reddedilirken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
            }

            return Json(message);
        }

        [HttpPost]
        public async Task<IActionResult> FinishProduction(ProductionFinishDto production)
        {
            string message = "";
            try
            {
                var productionToFinish = await productionManager.GetByID(production.ID);

                if (productionToFinish != null)
                {
                    productionToFinish.Status = (ProductionStatuses)4;
                    await productionManager.Update(productionToFinish);

                    message = "Üretim başarıyla tamamlandı!";
                }
                else
                {
                    message = "Tamamlanacak üretim bulunamadı!";
                }
            }
            catch (Exception)
            {
                message = "Üretim tamamlanırken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
            }

            return Json(message);
        }

        [HttpGet]
        public async Task<IActionResult> GetOfferDetailsByProductionId(int productionId)
        {
            var production = await productionManager.GetByID(productionId);
            var offerDetails = await offerDetailManager.GetOfferDetailsByOfferID(production.OfferID);

            if (offerDetails != null)
            {
                var offerDetailData = new List<object>();

                foreach (var detail in offerDetails)
                {
                    var detailData = new
                    {
                        ID = detail.ID,
                        Productpiece = detail.Piece,
                        Productprice = detail.Price,
                        Productname = detail.ProductName,
                        Name = detail.Name,
                        Lastname = detail.LastName,
                        Mail = detail.Mail,
                        Phonenumber = detail.PhoneNumber
                    };

                    offerDetailData.Add(detailData);
                }

                return Json(offerDetailData);
            }
            else
            {
                return Json(new[] { new { result = "Bir sorun oluştu." } });
            }
        }



    }
}
