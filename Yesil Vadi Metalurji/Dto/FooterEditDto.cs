using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yesil_Vadi_Metalurji.Dto
{
    public class FooterEditDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string LastPosts { get; set; }
        public string Suggestion { get; set; }
        public string LastBool { get; set; }
        public string Last { get; set; }

    }
}
