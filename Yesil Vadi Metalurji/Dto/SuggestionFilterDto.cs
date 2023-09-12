using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yesil_Vadi_Metalurji.Dto
{
    public class SuggestionFilterDto
    {
        public string Mail { get; set; }
        public SuggestionStatuses Status { get; set; }
        public string Content { get; set; }

    }
}
