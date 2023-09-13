using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public enum HomePageStatuses
    {
        [Description("AKTİF")]
        Approved = 1,

        [Description("AKTİF DEĞİL")]
        Removed = 2,

    }
    public class HomePage
    {
        [Key]
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
        public bool Active { get; set; }
        public bool Banner { get; set; }
        public bool Image { get; set; }
        public bool SubtitleStatus { get; set; }
        public bool ContentStatus { get; set; }
        public bool TitleStatus { get; set; }

        [MaxLength(200)]
        public string HakkimizdaFoto1 { get; set; }

        [MaxLength(200)]
        public string HakkimizdaFoto2 { get; set; }

        [MaxLength(200)]
        public string HizmetlerimizFoto1 { get; set; }

        [MaxLength(200)]
        public string HizmetlerimizFoto2 { get; set; }

        [MaxLength(200)]
        public string HizmetlerimizFoto3 { get; set; }

        [MaxLength(200)]
        public string IsOrtaklarimizFoto1 { get; set; }

        [MaxLength(200)]
        public string IsOrtaklarimizFoto2 { get; set; }

        [MaxLength(200)]
        public string IsOrtaklarimizFoto3 { get; set; }

        [MaxLength(200)]
        public string IsOrtaklarimizFoto4 { get; set; }

        [MaxLength(200)]
        public string IsOrtaklarimizFoto5 { get; set; }

        [MaxLength(200)]
        public string IsOrtaklarimizFoto6 { get; set; }

        [MaxLength(200)]
        public string ImageUrl1 { get; set; }

        [MaxLength(200)]
        public string ImageUrl2 { get; set; }

        [MaxLength(200)]
        public string ImageUrl3 { get; set; }

        [MaxLength(200)]
        public string ImageUrl4 { get; set; }

        [MaxLength(200)]
        public string ImageUrl5 { get; set; }

        [MaxLength(200)]
        public string ImageUrl6 { get; set; }

        [MaxLength(200)]
        public string ImageUrl7 { get; set; }

        [MaxLength(200)]
        public string ImageUrl8 { get; set; }

        [MaxLength(200)]
        public string ImageUrl9 { get; set; }

        [MaxLength(200)]
        public string ImageUrl10 { get; set; }
    }
}
