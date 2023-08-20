using Business.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Yesil_Vadi_Metalurji.Dto;
using Yesil_Vadi_Metalurji.Models;
using Core.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Yesil_Vadi_Metalurji.Controllers
{
    [Authorize(Policy = "MelhOnly")]
    public class OfferTestController : Controller
    {

        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());
        ProductManager productManager = new ProductManager(new EFProductRepository());
        OfferManager offerManager = new OfferManager(new EFOfferRepository());
        OfferDetailManager offerDetailManager = new OfferDetailManager(new EFOfferDetailRepository());
        OrderManager orderManager = new OrderManager(new EFOrderRepository());
        ProductionManager productionManager = new ProductionManager(new EFProductionRepository());


        public async Task<IActionResult> Index()
        {
            var offers = await offerManager.GetList();

            OfferFilterDto filter = new OfferFilterDto();

            var model = new OffersViewModel
            {
                Offers = offers,
                FilterDto = filter
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await productManager.GetListWithIncludes();

            var productData = products.Select(p => new
            {
                ID = p.ID,
                Name = p.Name,
                Price = p.Price
            });

            return Json(productData);
        }

        [HttpPost]
        public async Task<IActionResult> Filter(OfferFilterDto filterDto)
        {

            var offers = await offerManager.GetList();

            if (!string.IsNullOrEmpty(filterDto.Name)) offers = offers.Where(p => p.Name == filterDto.Name).ToList();

            if (!string.IsNullOrEmpty(filterDto.LastName)) offers = offers.Where(p => p.Name == filterDto.LastName).ToList();

            if (!string.IsNullOrEmpty(filterDto.Mail)) offers = offers.Where(p => p.Mail == filterDto.Mail).ToList();

            if (!string.IsNullOrEmpty(filterDto.PhoneNumber)) offers = offers.Where(p => p.PhoneNumber == filterDto.PhoneNumber).ToList();

            if (!string.IsNullOrEmpty(filterDto.TotalPrice))
            {
                offers = offers.Where(p => p.TotalPrice == filterDto.TotalPrice.ToDecimal()).ToList();
            }

            if (filterDto.TotalPiece > 0) offers = offers.Where(p => p.TotalPiece == filterDto.TotalPiece).ToList();

            if (filterDto.ProductPiece > 0) offers = offers.Where(p => p.ProductPiece == filterDto.ProductPiece).ToList();

            if (filterDto.Status > 0) offers = offers.Where(p => p.Status.Equals(filterDto.Status)).ToList();

            if (filterDto.Active == "1")
            {
                offers = offers.Where(p => p.Active == true).ToList();
            }
            else if (filterDto.Active == "2")
            {
                offers = offers.Where(p => p.Active == false).ToList();
            }


            var offerData = offers.Select(p => new
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
                Productpiece = p.ProductPiece,
                Createdate = p.CreateDate
            });

            return Json(offerData);
        }

        [HttpGet]
        public async Task<IActionResult> GetOfferDetails(int offerId)
        {
            var offerDetails = await offerDetailManager.GetOfferDetailsByOfferID(offerId);

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
                        Phonenumber = detail.PhoneNumber,
                        Createdate = detail.CreateDate
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

        [HttpPost]
        public async Task<IActionResult> AddOffer(Dictionary<string, string> form, OfferAddDto offer)
        {
            string message = "";
            int.TryParse(form["adet"], out int productpiece);
            decimal totalprice = 0;
            int totalpiecee = 0;

            if (int.TryParse(form["adet"], out int adet) && adet != 0)
            {
                try
                {
                    var active = false;
                    if (offer.Active == "1")
                    {
                        active = true;
                    }
                    else
                    {
                        active = false;
                    }
                    var offerToAdd = new Offer
                    {
                        Status = offer.Status,
                        Active = active,
                        Name = offer.Name,
                        LastName = offer.LastName,
                        Mail = offer.Mail,
                        PhoneNumber = offer.PhoneNumber,
                        TotalPiece = 0,
                        TotalPrice = 0,
                        ProductPiece = productpiece,
                        CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString())
                };

                    await offerManager.Add(offerToAdd);

                    var addedOffer = await offerManager.GetByID(offerToAdd.ID);

                    for (int i = 1; i <= adet; i++)
                    {
                        if (form[$"Product{i}"] != null && int.TryParse(form[$"Product{i}"], out int productID) &&
                            int.TryParse(form[$"ProductPiece{i}"], out int productPiece))
                        {
                            totalprice += form[$"ProductPrice{i}"].ToDecimal() * productPiece;
                            totalpiecee += productPiece;
                            var offerProduct = await productManager.GetByID(productID);
                            var productName = offerProduct.Name;
                            var offerDetailToAdd = new OfferDetail
                            {
                                OfferID = addedOffer.ID,
                                Name = addedOffer.Name,
                                LastName = addedOffer.LastName,
                                Mail = addedOffer.Mail,
                                PhoneNumber = addedOffer.PhoneNumber,
                                ProductID = productID,
                                ProductName = productName,
                                Price = form[$"ProductPrice{i}"].ToDecimal(),
                                Piece = productPiece,
                                CreateDate = addedOffer.CreateDate
                            };

                            await offerDetailManager.Add(offerDetailToAdd);
                        }
                        else
                        {
                            message = "Teklif eklenirken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
                            return Json(message);
                        }
                    }

                    var offerToUpdate = await offerManager.GetByID(offerToAdd.ID);
                    offerToUpdate.TotalPrice = totalprice;
                    offerToUpdate.TotalPiece = totalpiecee;
                    await offerManager.Update(offerToUpdate);

                    message = "Teklif başarıyla kaydedildi!";
                    return Json(message);
                }
                catch (Exception)
                {
                    message = "Teklif eklenirken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
                    return Json(message);
                }
            }
            else
            {
                message = "Hiç ürün eklemediniz!";
                return Json(message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ApproveOffer(OfferApproveDto offer)
        {
            string message = "";
            try
            {
                var offerToApprove = await offerManager.GetByID(offer.ID);

                if (offerToApprove != null)
                {
                    offerToApprove.Status = (OfferStatuses)1;
                    offerToApprove.Active = true;
                    await offerManager.Update(offerToApprove);

                    message = "Teklif başarıyla onaylandı!";
                }
                else
                {
                    message = "Onaylanmak istenen teklif bulunamadı!";
                }
            }
            catch (Exception)
            {
                message = "Teklif onaylanırken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
            }

            return Json(message);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveOffer(OfferDeleteDto offer)
        {
            string message = "";
            try
            {
                var offerToRemove = await offerManager.GetByID(offer.ID);

                if (offerToRemove != null)
                {
                    offerToRemove.Status = (OfferStatuses)3;
                    offerToRemove.Active = false;
                    await offerManager.Update(offerToRemove);

                    message = "Teklif başarıyla reddedildi!";
                }
                else
                {
                    message = "Reddedilmek istenen teklif bulunamadı!";
                }
            }
            catch (Exception)
            {
                message = "Teklif reddedilirken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
            }

            return Json(message);
        }

        [HttpPost]
        public async Task<IActionResult> GoToOrder(OfferToOrderDto offer)
        {
            string message = "";
            try
            {
                var offerToOrder = await offerManager.GetByID(offer.ID);

                if (offerToOrder != null)
                {
                    offerToOrder.Status = (OfferStatuses)4;
                    await offerManager.Update(offerToOrder);


                    var orderToAdd = new Order
                    {
                        Status = (OrderStatuses)5,
                        Active = true,
                        OfferID = offerToOrder.ID,
                        Name = offerToOrder.Name,
                        LastName = offerToOrder.LastName,
                        Mail = offerToOrder.Mail,
                        PhoneNumber = offerToOrder.PhoneNumber,
                        TotalPiece = offerToOrder.TotalPiece,
                        TotalPrice = offerToOrder.TotalPrice,
                        ProductPiece = offerToOrder.ProductPiece,
                        CreateDate = offerToOrder.CreateDate
                    };
                    await orderManager.Add(orderToAdd);

                    message = "Teklif başarıyla siparişe geçti!";
                }
                else
                {
                    message = "Siparişe geçecek teklif bulunamadı!";
                }
            }
            catch (Exception)
            {
                message = "Teklif siparişe geçerken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
            }

            return Json(message);
        }


    }
}
