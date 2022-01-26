using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meow.Data
{
    public class Reply //: Post
    {
        [Key]
        public int PawstReplyId { get; set; }

        [Required]
        public string PawstReplyTitle { get; set; }

        [Required]
        public string TextPawst { get; set; }

        [Required]
        public string Catent { get; set; }

        [Required]
        public Guid CatOwnerId { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        [Required]
        public DateTimeOffset ModifiedUtc { get; set; }

    }
}
