using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Catent { get; set; }

        [Required]
        public Guid CatOwnerId { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        [Required]
        public DateTimeOffset ModifiedUtc { get; set; }

        [ForeignKey("Catment")]
        public int CatmentId { get; set; }
        public virtual Catment Catment { get; set; }
    }
}
