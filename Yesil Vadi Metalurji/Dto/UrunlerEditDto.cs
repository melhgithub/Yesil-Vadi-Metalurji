using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yesil_Vadi_Metalurji.Dto
{
    public class UrunlerEditDto
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public string Subtitle { get; set; }
        public string Content { get; set; }

        public AboutStatuses Status { get; set; }
        public bool Active{ get; set; }
        public string Banner { get; set; }
        public string Image { get; set; }
        public string SubtitleStatus { get; set; }
        public string ContentStatus { get; set; }
        public string TitleStatus { get; set; }

    }
}
