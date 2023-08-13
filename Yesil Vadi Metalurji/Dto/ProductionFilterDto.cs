using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yesil_Vadi_Metalurji.Dto
{
    public class ProductionFilterDto
    {
        public ProductionStatuses Status { get; set; }
        public string Active { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Mail { get; set; }

        private string _totalprice;

        public string TotalPrice
        {
            get { return _totalprice; }
            set { _totalprice = value?.Replace(",", "."); }
        }

        public int TotalPiece { get; set; }
        public int ProductPiece { get; set; }
    }
}
