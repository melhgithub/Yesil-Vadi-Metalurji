using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public enum ContactStatuses
    {
        [Description("AKTİF")]
        Approved = 1,

        [Description("AKTİF DEĞİL")]
        Removed = 2,

    }
    public class Contact
    {

        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public ContactStatuses Status { get; set; }
        public bool Active { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string Map { get; set; }
        public string Address { get; set; }
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
