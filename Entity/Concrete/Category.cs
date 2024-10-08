﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{

    public enum CategoryStatuses
    {
        [Description("TÜMÜ")]
        All = 0,

        [Description("AKTİF")]
        Approved = 1,

        [Description("KALDIRILDI")]
        Removed = 2,
    }
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public CategoryStatuses Status { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public bool TeklifStatus { get; set; }


        //BAĞLANTILAR

        public List<Product> Product { get; set; }

    }
}
