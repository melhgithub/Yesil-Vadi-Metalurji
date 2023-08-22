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
    public class ContactPageTestController : Controller
    {
        ContactManager contactManager = new ContactManager(new EFContactRepository());
        ImageManager imageManager = new ImageManager(new EFImageRepository());
        public async Task<IActionResult> Index()
        {
            var contact = await contactManager.GetList();

            var images = await imageManager.GetList();

            var filter = new ContactEditDto();

            var model = new ContactPageViewModel
            {
                FilterDto = filter,
                Contact = contact,
                Images = images
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ContactEditDto contact)
        {
            if (ModelState.IsValid)
            {
                var updatedContact = await contactManager.GetByID(contact.ID);
                if (updatedContact != null)
                {
                    updatedContact.Content = contact.Content;
                    updatedContact.Title = contact.Title;
                    updatedContact.Subtitle = contact.Subtitle;
                    updatedContact.Mail = contact.Mail;
                    updatedContact.Map = contact.Map;
                    updatedContact.Address = contact.Address;
                    updatedContact.PhoneNumber = contact.PhoneNumber;
                    updatedContact.Status = (ContactStatuses)contact.Status;
                    if (updatedContact.Status == (ContactStatuses)1)
                    {
                        updatedContact.Active = true;
                    }
                    else
                    {
                        updatedContact.Active = false;
                    }


                    if (contact.ImageUrl1 != null)
                    {
                        int imageid = int.Parse(contact.ImageUrl1);
                        var image = await imageManager.GetByID(imageid);
                        contact.ImageUrl1 = image.Name;
                    }
                    if (contact.ImageUrl2 != null)
                    {
                        int imageid = int.Parse(contact.ImageUrl2);
                        var image = await imageManager.GetByID(imageid);
                        contact.ImageUrl2 = image.Name;
                    }
                    if (contact.ImageUrl3 != null)
                    {
                        int imageid = int.Parse(contact.ImageUrl3);
                        var image = await imageManager.GetByID(imageid);
                        contact.ImageUrl3 = image.Name;
                    }
                    if (contact.ImageUrl4 != null)
                    {
                        int imageid = int.Parse(contact.ImageUrl4);
                        var image = await imageManager.GetByID(imageid);
                        contact.ImageUrl4 = image.Name;
                    }
                    if (contact.ImageUrl5 != null)
                    {
                        int imageid = int.Parse(contact.ImageUrl5);
                        var image = await imageManager.GetByID(imageid);
                        contact.ImageUrl5 = image.Name;
                    }
                    if (contact.ImageUrl6 != null)
                    {
                        int imageid = int.Parse(contact.ImageUrl6);
                        var image = await imageManager.GetByID(imageid);
                        contact.ImageUrl6 = image.Name;
                    }
                    if (contact.ImageUrl7 != null)
                    {
                        int imageid = int.Parse(contact.ImageUrl7);
                        var image = await imageManager.GetByID(imageid);
                        contact.ImageUrl7 = image.Name;
                    }
                    if (contact.ImageUrl8 != null)
                    {
                        int imageid = int.Parse(contact.ImageUrl8);
                        var image = await imageManager.GetByID(imageid);
                        contact.ImageUrl8 = image.Name;
                    }
                    if (contact.ImageUrl9 != null)
                    {
                        int imageid = int.Parse(contact.ImageUrl9);
                        var image = await imageManager.GetByID(imageid);
                        contact.ImageUrl9 = image.Name;
                    }
                    if (contact.ImageUrl10 != null)
                    {
                        int imageid = int.Parse(contact.ImageUrl10);
                        var image = await imageManager.GetByID(imageid);
                        contact.ImageUrl10 = image.Name;
                    }




                    updatedContact.ImageUrl1 = contact.ImageUrl1;
                    updatedContact.ImageUrl2 = contact.ImageUrl2;
                    updatedContact.ImageUrl3 = contact.ImageUrl3;
                    updatedContact.ImageUrl4 = contact.ImageUrl4;
                    updatedContact.ImageUrl5 = contact.ImageUrl5;
                    updatedContact.ImageUrl6 = contact.ImageUrl6;
                    updatedContact.ImageUrl7 = contact.ImageUrl7;
                    updatedContact.ImageUrl8 = contact.ImageUrl8;
                    updatedContact.ImageUrl9 = contact.ImageUrl9;
                    updatedContact.ImageUrl10 = contact.ImageUrl10;
                    await contactManager.Update(updatedContact);
                }

                return RedirectToAction("Index");
            }
            var filter = new ContactEditDto();

            return View("Index", new ContactPageViewModel
            {
                FilterDto = filter,
                Contact = await contactManager.GetList(),
                Images = await imageManager.GetList()
            });
        }
    }
}
