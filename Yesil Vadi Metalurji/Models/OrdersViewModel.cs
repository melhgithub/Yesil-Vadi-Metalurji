using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yesil_Vadi_Metalurji.Dto;

namespace Yesil_Vadi_Metalurji.Models
{
    public class OrdersViewModel
    {
        public OrderFilterDto FilterDto { get; set; }
        public List<Order> Orders { get; set; }
    }
}
