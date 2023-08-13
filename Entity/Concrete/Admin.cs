using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public enum AdminStatuses
    {
        [Description("TÜMÜ")]
        All = 0,

        [Description("AKTİF")]
        Approved = 1,

        [Description("KALDIRILDI")]
        Removed = 2,
    }
    public class Admin
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        public bool Active { get; set; }
        public AdminStatuses Status { get; set; }

    }
}
