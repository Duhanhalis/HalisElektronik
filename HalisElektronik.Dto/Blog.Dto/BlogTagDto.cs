using HalisElektronik.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Dto
{
    public class BlogTagDto
    {
        [Key]
        public int BlogsTagId { get; set; }
        [Required, MaxLength(50), MinLength(3)]
        public string BlogsTagName { get; set; } = string.Empty;
    }
}
