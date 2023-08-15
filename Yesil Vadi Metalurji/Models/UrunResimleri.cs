using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yesil_Vadi_Metalurji.Models
{
    public class UrunResimleri
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile ImageURL { get; set; }
    }
}
