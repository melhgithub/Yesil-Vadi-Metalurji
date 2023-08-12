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

    public enum ProductStatuses
    {

        [Description("TÜMÜ")]
        All = 0,

        [Description("SATIŞTA")]
        Approved = 1,

        [Description("KALDIRILDI")]
        Removed = 2,
    }
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Material { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Piece { get; set; }

        [Required]
        public ProductStatuses Status { get; set; }

        //VARSA
        [MaxLength(500)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }


        //BAĞLANTILAR

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
