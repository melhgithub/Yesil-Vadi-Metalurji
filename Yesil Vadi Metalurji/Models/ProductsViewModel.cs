using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yesil_Vadi_Metalurji.Dto;

namespace Yesil_Vadi_Metalurji.Models
{
    public class ProductsViewModel
    {
        public List<Urunler> Urunlers { get; set; }
        public List<Category> Categories { get; set; }
        public ProductFilterDto FilterDto { get; set; }
        public List<Category> Category { get; set; }
        public List<Product> Products { get; set; }
    }
}
