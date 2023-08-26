using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Suggestion
    {

        [Key]
        public int ID { get; set; }

        [MaxLength(100)]
        public string Mail { get; set; }

        [MaxLength(500)]
        public string Content { get; set; }
    }
}
