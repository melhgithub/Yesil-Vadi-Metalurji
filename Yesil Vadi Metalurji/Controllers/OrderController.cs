using Business.Concrete;
using Core.Extensions;
using DataAccess.Repositories;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yesil_Vadi_Metalurji.Dto;
using Yesil_Vadi_Metalurji.Models;

namespace Yesil_Vadi_Metalurji.Controllers
{
    public class OrderController : Controller
    {

        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());
        ProductManager productManager = new ProductManager(new EFProductRepository());
        OfferManager offerManager = new OfferManager(new EFOfferRepository());
        OfferDetailManager offerDetailManager = new OfferDetailManager(new EFOfferDetailRepository());
        OrderManager orderManager = new OrderManager(new EFOrderRepository());
        ProductionManager productionManager = new ProductionManager(new EFProductionRepository());

        public async Task<IActionResult> Index()
        {
            var orders = await orderManager.GetList();

            OrderFilterDto filter = new OrderFilterDto();

            var model = new OrdersViewModel
            {
                Orders = orders,
                FilterDto = filter
            };

            return View(model);
        }

        public async Task<IActionResult> Filter(OrderFilterDto filterDto)
        {

            var orders = await orderManager.GetList();

            if (!string.IsNullOrEmpty(filterDto.Name)) orders = orders.Where(p => p.Name == filterDto.Name).ToList();

            if (!string.IsNullOrEmpty(filterDto.LastName)) orders = orders.Where(p => p.Name == filterDto.LastName).ToList();

            if (!string.IsNullOrEmpty(filterDto.Mail)) orders = orders.Where(p => p.Mail == filterDto.Mail).ToList();

            if (!string.IsNullOrEmpty(filterDto.PhoneNumber)) orders = orders.Where(p => p.PhoneNumber == filterDto.PhoneNumber).ToList();

            if (!string.IsNullOrEmpty(filterDto.TotalPrice))
            {
                orders = orders.Where(p => p.TotalPrice == filterDto.TotalPrice.ToDecimal()).ToList();
            }



            if (filterDto.TotalPiece > 0) orders = orders.Where(p => p.TotalPiece == filterDto.TotalPiece).ToList();

            if (filterDto.ProductPiece > 0) orders = orders.Where(p => p.ProductPiece == filterDto.ProductPiece).ToList();

            if (filterDto.Status > 0) orders = orders.Where(p => p.Status.Equals(filterDto.Status)).ToList();

            if (filterDto.Active == "1")
            {
                orders = orders.Where(p => p.Active == true).ToList();
            }
            else if (filterDto.Active == "2")
            {
                orders = orders.Where(p => p.Active == false).ToList();
            }


            var offerData = orders.Select(p => new
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



        [HttpGet]
        public async Task<IActionResult> GetOfferDetailsByOrderId(int orderId)
        {
            var order = await orderManager.GetByID(orderId);
            var offerDetails = await offerDetailManager.GetOfferDetailsByOfferID(order.OfferID);

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


        [HttpPost]
        public async Task<IActionResult> ApproveOrder(OrderApproveDto order)
        {
            string message = "";
            try
            {
                var orderToApprove = await orderManager.GetByID(order.ID);

                if (orderToApprove != null)
                {
                    orderToApprove.Status = (OrderStatuses)1;
                    orderToApprove.Active = true;
                    await orderManager.OrderUpdate(orderToApprove);

                    message = "Sipariş başarıyla onaylandı!";
                }
                else
                {
                    message = "Onaylanmak istenen sipariş bulunamadı!";
                }
            }
            catch (Exception)
            {
                message = "Sipariş onaylanırken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
            }

            return Json(message);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveOrder(OrderDeleteDto order)
        {
            string message = "";
            try
            {
                var orderToRemove = await orderManager.GetByID(order.ID);

                if (orderToRemove != null)
                {
                    orderToRemove.Status = (OrderStatuses)3;
                    orderToRemove.Active = false;
                    await orderManager.OrderUpdate(orderToRemove);

                    message = "Sipariş başarıyla reddedildi!";
                }
                else
                {
                    message = "Reddedilmek istenen sipariş bulunamadı!";
                }
            }
            catch (Exception)
            {
                message = "Sipariş reddedilirken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
            }

            return Json(message);
        }

        [HttpPost]
        public async Task<IActionResult> GoToProduction(OrderToProductionDto order)
        {
            string message = "";
            try
            {
                var orderToProduction = await orderManager.GetByID(order.ID);

                if (orderToProduction != null)
                {
                    orderToProduction.Status = (OrderStatuses)4;
                    await orderManager.OrderUpdate(orderToProduction);


                    var productionToAdd = new Production
                    {
                        Status = (ProductionStatuses)5,
                        Active = true,
                        OfferID = orderToProduction.OfferID,
                        Name = orderToProduction.Name,
                        LastName = orderToProduction.LastName,
                        Mail = orderToProduction.Mail,
                        PhoneNumber = orderToProduction.PhoneNumber,
                        TotalPiece = orderToProduction.TotalPiece,
                        TotalPrice = orderToProduction.TotalPrice,
                        ProductPiece = orderToProduction.ProductPiece
                    };
                    await productionManager.ProductionAdd(productionToAdd);

                    message = "Sipariş başarıyla üretime geçti!";
                }
                else
                {
                    message = "Üretime geçilecek sipariş bulunamadı!";
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
