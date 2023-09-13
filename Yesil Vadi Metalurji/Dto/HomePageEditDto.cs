using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yesil_Vadi_Metalurji.Dto
{
    public class HomePageEditDto
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public string Subtitle { get; set; }
        public string Content { get; set; }
        public string SayisalVeriYazisi { get; set; }
        public string SayisalVeri1 { get; set; }
        public string SayisalVeri2 { get; set; }
        public string Hizmetlerimiz { get; set; }
        public string Aciklama1 { get; set; }
        public string Aciklama2 { get; set; }
        public string Aciklama3 { get; set; }
        public string IsOrtaklarimiz { get; set; }

        public HomePageStatuses Status { get; set; }
        public bool Active{ get; set; }
        public string Banner { get; set; }
        public string Image { get; set; }
        public string SubtitleStatus { get; set; }
        public string ContentStatus { get; set; }
        public string TitleStatus { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public string ImageUrl4 { get; set; }
        public string ImageUrl5 { get; set; }
        public string ImageUrl6 { get; set; }
        public string ImageUrl7 { get; set; }
        public string ImageUrl8 { get; set; }
        public string ImageUrl9 { get; set; }
        public string ImageUrl10 { get; set; }
        public string HakkimizdaFoto1 { get; set; }
        public string HakkimizdaFoto2 { get; set; }
        public string HizmetlerimizFoto1 { get; set; }
        public string HizmetlerimizFoto2 { get; set; }
        public string HizmetlerimizFoto3 { get; set; }
        public string IsOrtaklarimizFoto1 { get; set; }
        public string IsOrtaklarimizFoto2 { get; set; }
        public string IsOrtaklarimizFoto3 { get; set; }
        public string IsOrtaklarimizFoto4 { get; set; }
        public string IsOrtaklarimizFoto5 { get; set; }
        public string IsOrtaklarimizFoto6 { get; set; }

    }
}
