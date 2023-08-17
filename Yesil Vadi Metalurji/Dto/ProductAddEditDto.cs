using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yesil_Vadi_Metalurji.Dto
{
    public class ProductAddEditDto
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Material { get; set; }

        private string _price;

        public string Price
        {
            get { return _price; }
            set { _price = value.Replace(",", "."); }
        }

        public int Piece { get; set; }

        public ProductStatuses Status { get; set; }
        public bool Active{ get; set; }
        public string Description { get; set; }

        public List<IFormFile> ImageFiles { get; set; }
        public int CategoryID { get; set; }
    }
}
