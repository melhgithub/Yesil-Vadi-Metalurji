using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{

    public enum ProductionStatuses
    {
        [Description("TÜMÜ")]
        All = 0,


        [Description("Üretimde")]
        Approved = 1,

        [Description("KALDIRILDI")]
        Removed = 2,

        [Description("Üretim İptal Edildi")]
        Cancelled = 3,


        [Description("Üretim Tamamlandı")]
        Finished = 4,

        [Description("Beklemede")]
        Pending = 5,
    }

    public class Production
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public ProductionStatuses Status { get; set; }
        public bool Active { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Mail { get; set; }



        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        [Required]
        public int TotalPiece { get; set; }
        [Required]
        public int ProductPiece { get; set; }


        //BAĞLANTILAR

        public int OfferID { get; set; }
        public Offer Offer { get; set; }



    }
}
