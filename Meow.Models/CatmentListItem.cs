using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meow.Models
{
    public class CatmentListItem
    {
        public int CatmentId { get; set; }

        public string ContentCatment { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int PawstReplyId { get; set; }
        public string PawstReplyTitle { get; set; }
    }

}
