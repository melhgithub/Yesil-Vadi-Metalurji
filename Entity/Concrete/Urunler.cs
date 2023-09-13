using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public enum UrunlerStatuses
    {
        [Description("AKTİF")]
        Approved = 1,

        [Description("AKTİF DEĞİL")]
        Removed = 2,

    }
    public class Urunler
    {

        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
        public UrunlerStatuses Status { get; set; }
        public bool Active { get; set; }
        public bool Banner { get; set; }
        public bool Image { get; set; }
        public bool SubtitleStatus { get; set; }
        public bool ContentStatus { get; set; }
        public bool TitleStatus { get; set; }
    }
}
