using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public enum MessageStatuses
    {

        [Description("TÜMÜ")]
        All = 0,

        [Description("OKUNDU")]
        Readed = 1,

        [Description("BEKLİYOR")]
        Pending = 2,
    }
    public class Message
    {

        [Key]
        public int ID { get; set; }

        [MaxLength(100)]
        public string Mail { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Subject { get; set; }
        public string Content { get; set; }
        public MessageStatuses Status { get; set; }


    }
}
