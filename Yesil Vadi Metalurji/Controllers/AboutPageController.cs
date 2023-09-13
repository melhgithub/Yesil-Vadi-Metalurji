using Business.Concrete;
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
    public class AboutPageController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EFAboutRepository());
        ImageManager imageManager = new ImageManager(new EFImageRepository());
        public async Task<IActionResult> Index()
        {
            var abouts = await aboutManager.GetList();

            var images = await imageManager.GetList();

            var filter = new AboutEditDto();

            var model = new AboutPageViewModel
            {
                FilterDto = filter,
                About = abouts,
                Images = images
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AboutEditDto about)
        {
            if (ModelState.IsValid)
            {
                var updatedAbout = await aboutManager.GetByID(about.ID);
                if (updatedAbout != null)
                {
                    updatedAbout.Content = about.Content;
                    updatedAbout.Title = about.Title;
                    updatedAbout.Subtitle = about.Subtitle;
                    updatedAbout.Status = (AboutStatuses)about.Status;
                    if (about.Image == "1")
                    {
                        updatedAbout.Image = true;
                    }
                    else
                    {
                        updatedAbout.Image = false;
                    }


                    if (about.SubtitleStatus == "1")
                    {
                        updatedAbout.SubtitleStatus = true;
                    }
                    else
                    {
                        updatedAbout.SubtitleStatus = false;
                    }


                    if (about.TitleStatus == "1")
                    {
                        updatedAbout.TitleStatus = true;
                    }
                    else
                    {
                        updatedAbout.TitleStatus = false;
                    }

                    if (about.ContentStatus == "1")
                    {
                        updatedAbout.ContentStatus = true;
                    }
                    else
                    {
                        updatedAbout.ContentStatus = false;
                    }
                    if (about.Banner == "1")
                    {
                        updatedAbout.Banner = true;
                    }
                    else
                    {
                        updatedAbout.Banner = false;
                    }
                    if (updatedAbout.Status == (AboutStatuses)1)
                    {
                        updatedAbout.Active = true;
                    }
                    else
                    {
                        updatedAbout.Active = false;
                    }


                    if (about.ImageUrl1 != null)
                    {
                        int imageid = int.Parse(about.ImageUrl1);
                        var image = await imageManager.GetByID(imageid);
                        about.ImageUrl1 = image.Name;
                    }
                    if (about.ImageUrl2 != null)
                    {
                        int imageid = int.Parse(about.ImageUrl2);
                        var image = await imageManager.GetByID(imageid);
                        about.ImageUrl2 = image.Name;
                    }
                    if (about.ImageUrl3 != null)
                    {
                        int imageid = int.Parse(about.ImageUrl3);
                        var image = await imageManager.GetByID(imageid);
                        about.ImageUrl3 = image.Name;
                    }
                    if (about.ImageUrl4 != null)
                    {
                        int imageid = int.Parse(about.ImageUrl4);
                        var image = await imageManager.GetByID(imageid);
                        about.ImageUrl4 = image.Name;
                    }
                    if (about.ImageUrl5 != null)
                    {
                        int imageid = int.Parse(about.ImageUrl5);
                        var image = await imageManager.GetByID(imageid);
                        about.ImageUrl5 = image.Name;
                    }
                    if (about.ImageUrl6 != null)
                    {
                        int imageid = int.Parse(about.ImageUrl6);
                        var image = await imageManager.GetByID(imageid);
                        about.ImageUrl6 = image.Name;
                    }
                    if (about.ImageUrl7 != null)
                    {
                        int imageid = int.Parse(about.ImageUrl7);
                        var image = await imageManager.GetByID(imageid);
                        about.ImageUrl7 = image.Name;
                    }
                    if (about.ImageUrl8 != null)
                    {
                        int imageid = int.Parse(about.ImageUrl8);
                        var image = await imageManager.GetByID(imageid);
                        about.ImageUrl8 = image.Name;
                    }
                    if (about.ImageUrl9 != null)
                    {
                        int imageid = int.Parse(about.ImageUrl9);
                        var image = await imageManager.GetByID(imageid);
                        about.ImageUrl9 = image.Name;
                    }
                    if (about.ImageUrl10 != null)
                    {
                        int imageid = int.Parse(about.ImageUrl10);
                        var image = await imageManager.GetByID(imageid);
                        about.ImageUrl10 = image.Name;
                    }




                    updatedAbout.ImageUrl1 = about.ImageUrl1;
                    updatedAbout.ImageUrl2 = about.ImageUrl2;
                    updatedAbout.ImageUrl3 = about.ImageUrl3;
                    updatedAbout.ImageUrl4 = about.ImageUrl4;
                    updatedAbout.ImageUrl5 = about.ImageUrl5;
                    updatedAbout.ImageUrl6 = about.ImageUrl6;
                    updatedAbout.ImageUrl7 = about.ImageUrl7;
                    updatedAbout.ImageUrl8 = about.ImageUrl8;
                    updatedAbout.ImageUrl9 = about.ImageUrl9;
                    updatedAbout.ImageUrl10 = about.ImageUrl10;
                    await aboutManager.Update(updatedAbout);
                }

                return RedirectToAction("Index");
            }

            var filter = new AboutEditDto();
            return View("Index", new AboutPageViewModel
            {
                FilterDto = filter,
                About = await aboutManager.GetList(),
                Images = await imageManager.GetList()
            });
        }
    }
}
