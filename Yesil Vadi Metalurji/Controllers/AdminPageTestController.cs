using Business.Concrete;
using DataAccess.Repositories;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yesil_Vadi_Metalurji.Controllers
{
    [Authorize(Policy = "MelhOnly")]
    public class AdminPageTestController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EFAboutRepository());
        ContactManager contactManager = new ContactManager(new EFContactRepository());
        FooterManager footerManager = new FooterManager(new EFFooterRepository());
        HomePageManager homePageManager = new HomePageManager(new EFHomePageRepository());
        LinkManager linkManager = new LinkManager(new EFLinkRepository());
        UrunlerManager urunlerManager = new UrunlerManager(new EFUrunlerRepository());
        AdminManager adminManager = new AdminManager(new EFAdminRepository());
        public async Task<IActionResult> Index()
        {
            var username = User.Identity.Name;
            ViewBag.UserName = username;
            return View();
        }
        public async Task<IActionResult> AOlustur()
        {
            var homepages = await homePageManager.GetList();
            if (homepages == null)
            {

                var hp = new HomePage
                {
                    Active = true,
                    Status = (HomePageStatuses)2,
                    Content = "Hakkımızda Ana Sayfa",
                    Title = "Ana Sayfa",
                    Subtitle = "",
                    SubtitleStatus = false,
                    Banner = false,
                    Image = true,
                    ContentStatus = true,
                    TitleStatus = true,
                    Hizmetlerimiz = "Hizmetlerimiz",
                    IsOrtaklarimiz = "İş Ortaklarımız",
                    SayisalVeriYazisi = "Sayısal veri için yazı gelecek.",
                    SayisalVeri1 = "Sayısal veri 1",
                    SayisalVeri2 = "Sayısal veri 2",
                    Aciklama1 = "Açıklama 1",
                    Aciklama2 = "Açıklama 2",
                    Aciklama3 = "Açıklama 3",
                };
                await homePageManager.Add(hp);

                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public async Task<IActionResult> HOlustur()
        {
            var abouts = await aboutManager.GetList();
            if (abouts == null)
            {
                var about = new About
                {
                    Active = true,
                    Status = (AboutStatuses)1,
                    Content = "Hakkımızda içerik gelecek.",
                    Title = "Hakkımızda",
                    Subtitle = "",
                    SubtitleStatus = false,
                    Banner = true,
                    Image = true,
                    ContentStatus = true,
                    TitleStatus = true
                };
                await aboutManager.Add(about);

                return View("Index");
            }
            else
            {
                return View("Index");
            }
            
        }

        public async Task<IActionResult> COlustur()
        {
            var contacts = await contactManager.GetList();
            if (contacts == null)
            {
                var ct = new Contact
                {
                    Active = true,
                    Status = (ContactStatuses)1,
                    Content = "",
                    Title = "İletişim",
                    Subtitle = "",
                    SubtitleStatus = false,
                    Banner = false,
                    Image = false,
                    ContentStatus = false,
                    TitleStatus = true,
                    Mail = "bilgi@yesilvadimetalurji.com.tr",
                    Map = "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12590.710672920595!2d32.5069328!3d37.9145962!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14d090265baa34eb%3A0xa342b510071e7812!2sYe%C5%9FilVadi%20Metalurji!5e0!3m2!1str!2str!4v1694003832618!5m2!1str!2str",
                    Address = "Horozluhan Mah. Karatay Sanayi Ek Blokları Güvenilir Sk. No:108 Selçuklu/Konya",
                    PhoneNumber = "05315266565",
                };
                await contactManager.Add(ct);

                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public async Task<IActionResult> UOlustur()
        {
            var urunler = await urunlerManager.GetList();
            if (urunler == null)
            {
                var ur = new Urunler
                {
                    Active = true,
                    Status = (UrunlerStatuses)1,
                    Content = "",
                    Title = "Ürünler",
                    Subtitle = "",
                    SubtitleStatus = false,
                    Banner = true,
                    Image = true,
                    ContentStatus = true,
                    TitleStatus = true,
                };
                await urunlerManager.Add(ur);

                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public async Task<IActionResult> BOlustur()
        {
            var links = await linkManager.GetList();
            if (links == null)
            {
                var lk = new Link
                {
                    Status = (LinkStatuses)1,
                    Facebook = "",
                    FacebookStatus = true,
                    GoogleP = "",
                    GooglePStatus = false,
                    Instagram = "",
                    InstagramStatus = true,
                    Pinterest = "",
                    PinterestStatus = false,
                    Twitter = "",
                    TwitterStatus = true,
                    Whatsapp = "",
                    WhatsappStatus = true
                };
                await linkManager.Add(lk);

                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public async Task<IActionResult> FOlustur()
        {
            var footers = await footerManager.GetList();
            if (footers == null)
            {
                var ft = new Footer
                {
                    Title = "Yeşilvadi Metalurji Nedir?",
                    Content = "-----------------------",
                    Last = "2023 Yeşilvadi Metalurji. Tüm Hakları Saklıdır.",
                    LastBool = true,
                    LastPosts = true,
                    Link = true,
                    Suggestion = true,
                };
                await footerManager.Add(ft);

                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(string username, string currentPassword, string newPassword)
        {
            var user = await GetUserByUsernameAsync(username);
            if (user == null || user.Password != currentPassword)
            {
                return Json(new { success = false, message = "Eski şifre yanlış." });
            }

            user.Password = newPassword;
            var updateResult = await UpdateUserAsync(user);

            if (!updateResult)
            {
                return Json(new { success = false, message = "Şifre güncellenirken bir hata oluştu." });
            }

            return Json(new { success = true, message = "Şifre başarıyla güncellendi." });
        }

        private async Task<Admin> GetUserByUsernameAsync(string username)
        {
            return await adminManager.GetAdminByName(username);
        }

        private async Task<bool> UpdateUserAsync(Admin admin)
        {
            try
            {
                await adminManager.Update(admin);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
