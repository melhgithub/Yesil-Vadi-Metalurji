﻿using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yesil_Vadi_Metalurji.Dto;

namespace Yesil_Vadi_Metalurji.Models
{
    public class ContactPageViewModel
    {
        public ContactEditDto FilterDto { get; set; }
        public List<Contact> Contact { get; set; }
        public List<Image> Images { get; set; }
    }
}
