using Meow.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meow.Data
{
    public class Catment
    {
        [Key]
        public int CatmentId { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public string ContentCatment { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public virtual ReplyListItem ReplyListItem {get; set;}


    }
}
