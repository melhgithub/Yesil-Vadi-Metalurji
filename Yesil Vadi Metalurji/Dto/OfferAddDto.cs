using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yesil_Vadi_Metalurji.Dto
{
    public class OfferAddDto
    {
        public int ID { get; set; }

        public OfferStatuses Status { get; set; }

        public string Active { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Mail { get; set; }
    }
}
