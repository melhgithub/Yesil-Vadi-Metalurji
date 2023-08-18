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
    [Authorize(Policy = "MelhOnly")]
    public class ImageTestController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public ImageTestController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            RefreshImageList();
            return View(Images);
        }

        [HttpPost]
        public ActionResult Upload(IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var imagePath = Path.Combine(_environment.WebRootPath, "Resimler", image.FileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
            }

            RefreshImageList();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(string image)
        {
            if (!string.IsNullOrEmpty(image))
            {
                var imagePath = Path.Combine(_environment.WebRootPath, "Resimler", image);

                if (System.IO.File.Exists(imagePath))
                {
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
