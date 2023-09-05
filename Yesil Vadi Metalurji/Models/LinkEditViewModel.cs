using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yesil_Vadi_Metalurji.Dto;

namespace Yesil_Vadi_Metalurji.Models
{
    public class LinkEditViewModel
    {
        public LinkEditDto Dto { get; set; }
        public List<Link> Link { get; set; }

    }
}
