using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public enum LinkStatuses
    {

        [Description("TÜMÜ")]
        All = 0,

        [Description("AKTİF")]
        Active = 1,

        [Description("AKTİF DEĞİL")]
        Deactive = 2,
    }
    public class Link
    {
        public int ID { get; set; }
        public string Facebook { get; set; }
        public bool FacebookStatus { get; set; }
        public string Twitter { get; set; }
        public bool TwitterStatus { get; set; }
        public string GoogleP { get; set; }
        public bool GooglePStatus { get; set; }
        public string Pinterest { get; set; }
        public bool PinterestStatus { get; set; }
        public string Instagram { get; set; }
        public bool InstagramStatus { get; set; }
        public string Whatsapp { get; set; }
        public bool WhatsappStatus { get; set; }
        public LinkStatuses Status { get; set; }

    }
}
