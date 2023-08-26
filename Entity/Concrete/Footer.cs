using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Footer
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(26)]
        public string Title { get; set; }

        [MaxLength(350)]
        public string Content { get; set; }
        public bool LastPosts { get; set; }
        public bool Suggestion { get; set; }

    }
}
