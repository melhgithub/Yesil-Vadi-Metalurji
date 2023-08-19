using Business.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Yesil_Vadi_Metalurji.Controllers
{
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        ImageManager imageManager = new ImageManager(new EFImageRepository());

        public ImageController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            RefreshImageList();
            return View(Images);
        }

        [HttpPost]
        public async Task<ActionResult> Upload(List<IFormFile> images)
        {
            if (images != null && images.Count > 0)
            {
                foreach (var image in images)
                {
                    if (image.Length > 0)
                    {
                        var imagePath = Path.Combine(_environment.WebRootPath, "Resimler", image.FileName);

                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            image.CopyTo(stream);
                        }

                        await kaydet(image.FileName);
                    }
                }
            }

            RefreshImageList();

            return RedirectToAction(nameof(Index));
        }


        private async Task kaydet(string fileName)
        {
            Image image = new Image
            {
                Name = fileName
            };
            await imageManager.Add(image);
        }


        private async Task sil(string fileName)
        {
            var image = await imageManager.GetImageByName(fileName);
            await imageManager.Delete(image);
        }

        public IActionResult Delete(string image)
        {
            if (!string.IsNullOrEmpty(image))
            {
                var imagePath = Path.Combine(_environment.WebRootPath, "Resimler", image);

                if (System.IO.File.Exists(imagePath))
                {
                    _ = sil(image);
                    System.IO.File.Delete(imagePath);
                }
            }

            RefreshImageList();

            return RedirectToAction(nameof(Index));
        }

        private List<string> Images = new List<string>();

        private void RefreshImageList()
        {
            var imageDirectory = Path.Combine(_environment.WebRootPath, "Resimler");
            Images = Directory.GetFiles(imageDirectory)
                             .Select(filePath => Path.GetFileName(filePath))
                             .ToList();
        }
    }
}
