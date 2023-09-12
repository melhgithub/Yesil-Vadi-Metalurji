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
    public class MessagesController : Controller
    {
        MessageManager messageManager = new MessageManager(new EFMessageRepository());
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Add(MessageAddDto sendtoMessage)
        {
            string message;
            if (ModelState.IsValid)
            {
                var addedMessage = new Message
                {
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
