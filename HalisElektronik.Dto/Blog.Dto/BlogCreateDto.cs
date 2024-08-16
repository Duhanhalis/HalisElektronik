using HalisElektronik.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Dto
{
    public class BlogCreateDto
    {

        [MaxLength(100), MinLength(3)]
        public string? BlogTitle { get; set; }
        [MaxLength(1000)]
        public string? BlogAltTitle { get; set; }
        public string? BlogDescription { get; set; }
        public int? BlogsTagId { get; set; }
        public BlogTagDto? Tags { get; set; }
        public DateTime Date_Time { get; set; } = DateTime.Now;
        public int ImageId { get; set; }
        public ImageDto? BlogImage { get; set; }
    }
}
