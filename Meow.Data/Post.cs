﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meow.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
