using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yesil_Vadi_Metalurji.Dto
{
    public class ProductFilterDto
    {

        public string Name { get; set; }

        public string Material { get; set; }

        private string _price;

        public string Price
        {
            get { return _price; }
            set { _price = value?.Replace(",", "."); }
        }



        public int Piece { get; set; }

        public ProductStatuses Status { get; set; }
        public string Active { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int? CategoryID { get; set; }
        public CategoryStatuses CategoryStatus { get; set; }
        public string CategoryActive { get; set; }
        public List<Category> Categories { get; set; }
        public List<Image> Images { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
