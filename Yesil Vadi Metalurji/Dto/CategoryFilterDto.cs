﻿using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yesil_Vadi_Metalurji.Dto
{
    public class CategoryFilterDto
    {
        public string Name { get; set; }
        public CategoryStatuses Status { get; set; }
        public string Active { get; set; }

    }
}
