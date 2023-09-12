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
    public class MessagesController : Controller
    {
        MessageManager messageManager = new MessageManager(new EFMessageRepository());
        public async Task<IActionResult> Index()
        {
            var messages = await messageManager.GetList();
            var filterDto = new MessageFilterDto();

            var model = new MessageViewModel
            {
                Message = messages,
                FilterDto = filterDto
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetMessageDetails(int messageId)
        {
            var messages = await messageManager.GetList();
            var details = messages.Where(p => p.ID == messageId).ToList();

            if (details != null)
            {
                var messageData = new List<object>();

                foreach (var detail in details)
                {
                    var detailData = new
                    {
                        ID = detail.ID,
                        Name = detail.Name,
                        Subject = detail.Subject,
                        Mail = detail.Mail,
                        Content = detail.Content,
                    };

                    messageData.Add(detailData);
                }

                return Json(messageData);
            }
            else
            {
                return Json(new[] { new { result = "Bir sorun oluştu." } });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Filter(MessageFilterDto filterDto)
        {
            var messages = await messageManager.GetList();

            if (!string.IsNullOrEmpty(filterDto.Mail))
            {
                messages = messages.Where(p => p.Mail == filterDto.Mail).ToList();
            }
            if (!string.IsNullOrEmpty(filterDto.Subject))
            {
                messages = messages.Where(p => p.Subject == filterDto.Subject).ToList();
            }
            if (!string.IsNullOrEmpty(filterDto.Name))
            {
                messages = messages.Where(p => p.Name == filterDto.Name).ToList();
            }

            if (!string.IsNullOrEmpty(filterDto.Content))
            {
                messages = messages.Where(p => p.Content == filterDto.Content).ToList();
            }

            if (filterDto.Status > 0)
            {
                messages = messages.Where(p => p.Status.Equals(filterDto.Status)).ToList();
            }

            var messageData = messages.Select(p => new
            {
                ID = p.ID,
                Mail = p.Mail,
                Subject = p.Subject,
                Name = p.Name,
                Status = p.Status,
                Content = p.Content
            });

            return Json(messageData);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveMessage(MessageApproveDto messageT)
        {
            string message = "";

            if (message != null)
            {
                try
                {
                    var messageToApprove = await messageManager.GetByID(messageT.ID);

                    if (messageToApprove != null)
                    {
                        messageToApprove.Status = (MessageStatuses)1;
                        await messageManager.Update(messageToApprove);

                        message = "Mesaj başarıyla onaylandı!";
                    }
                    else
                    {
                        message = "Onaylanmak istenen mesaj bulunamadı!";
                    }
                }
                catch (Exception)
                {
                    message = "Mesaj onaylanırken bir sorun oluştu! Lütfen bilgileri kontrol ediniz.";
                }
            }
            else
            {
                message = "Hata oluştu!";
            }

            return Json(message);
        }


        [HttpPost]
        public async Task<IActionResult> Add(MessageAddDto sendtoMessage)
        {
            string message;
            if (ModelState.IsValid)
            {
                var addedMessage = new Message
                {
                    Subject = sendtoMessage.Subject,
                    Mail = sendtoMessage.Mail,
                    Content = sendtoMessage.Content,
                    Name = sendtoMessage.Name,
                    Status = (MessageStatuses)2,
                };

                await messageManager.Add(addedMessage);

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
