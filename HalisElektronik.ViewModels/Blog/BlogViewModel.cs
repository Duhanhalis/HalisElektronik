using HalisElektronik.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.ViewModels
{
    public class BlogViewModel
    {
        [Key]
        public int BlogId { get; set; }
        [MaxLength(100), MinLength(3)]
        public string? BlogTitle { get; set; }
        [MaxLength(1000)]
        public string? BlogAltTitle { get; set; }
        public string? BlogDescription { get; set; }
        public int? BlogsTagId { get; set; }
        public BlogsTagViewModel? Tag { get; set; }
        public DateTime Date_Time { get; set; } = DateTime.Now;
        public int ImageId { get; set; }
        public ImageViewModel? Images { get; set; }
    }
}
