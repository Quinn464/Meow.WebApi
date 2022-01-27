using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meow.Models
{
    public class ReplyCreate
    {
        [Required]
        public string PawstReplyTitle { get; set; }
        public string Catent { get; set; }
        public int CatmentId { get; set; }

    }
}
