using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meow.Data
{
    public class Reply
    {
        [Key]
        public int PawstReplyId { get; set; }

        [Key]
        public string TextPawst { get; set; }

        [Required]
        public Guid CatOwnerId { get; set; }
    }
}
