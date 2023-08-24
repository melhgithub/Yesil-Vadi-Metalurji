using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public enum AboutStatuses
    {
        [Description("AKTİF")]
        Approved = 1,

        [Description("AKTİF DEĞİL")]
        Removed = 2,

    }
    public class About
    {

        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public AboutStatuses Status { get; set; }
        public bool Active { get; set; }
        public bool Banner { get; set; }
        public bool Image { get; set; }
        public bool SubtitleStatus { get; set; }
        public bool ContentStatus { get; set; }

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
