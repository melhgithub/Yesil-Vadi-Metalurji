using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yesil_Vadi_Metalurji.Dto
{
    public class LinkEditDto
    {
        public int ID { get; set; }

        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Whatsapp { get; set; }
        public string Pinterest { get; set; }
        public string GoogleP { get; set; }

        public string FacebookStatus { get; set; }
        public string TwitterStatus { get; set; }
        public string InstagramStatus { get; set; }
        public string WhatsappStatus { get; set; }
        public string PinterestStatus { get; set; }
        public string GooglePStatus { get; set; }
        public LinkStatuses Status { get; set; }
    }
}
