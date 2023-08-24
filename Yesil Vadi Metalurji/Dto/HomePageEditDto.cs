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

        public HomePageStatuses Status { get; set; }
        public bool Active{ get; set; }
        public string Banner { get; set; }
        public string Image { get; set; }
        public string SubtitleStatus { get; set; }
        public string ContentStatus { get; set; }
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

    }
}
