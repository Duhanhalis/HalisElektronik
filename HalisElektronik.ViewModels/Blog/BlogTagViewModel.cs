using HalisElektronik.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.ViewModels
{
    public class BlogsTagViewModel
    {
        [Key]
        public int BlogsTagId { get; set; }
        public string BlogsTagName { get; set; } = string.Empty;
        public int? BlogId { get; set; }
    }
}
