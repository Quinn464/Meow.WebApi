using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meow.Models
{
    public class CatmentCreate
    {
        [Required]
        public string ContentCatment { get; set; }
        
    }
}
