using HalisElektronik.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Dto
{
    public class BlogDto
    {
        public int BlogId { get; set; }
        [MaxLength(100)]
        public string? BlogTitle { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string? BlogAltTitle { get; set; } = string.Empty;
        public string? BlogDescription { get; set; } = string.Empty;
        public int? BlogsTagId { get; set; }
        public BlogTagDto? Tags { get; set; }
        public DateTime Date_Time { get; set; } = DateTime.Now;
        public int ImageId { get; set; }
        public ImageDto? BlogImage { get; set; }
    }
}
