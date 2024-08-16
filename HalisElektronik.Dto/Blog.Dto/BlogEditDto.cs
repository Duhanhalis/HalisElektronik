using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Dto
{
    public class BlogEditDto
    {
        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogAltTitle { get; set; }
        public string? BlogDescription { get; set; }
        public int? BlogsTagId { get; set; }
        public DateTime Date_Time { get; set; } = DateTime.Now;
        public int? ImageId { get; set; }
        public ImageDto? Images { get; set; }
    }
}
