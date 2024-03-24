using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalisElektronik.Models
{
    /// <summary>
    /// Blogların Tutulduğu Table
    /// </summary>
    [Table("Blog")]
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        [MaxLength(100), MinLength(3)]
        public string? BlogTitle { get; set; }
        [MaxLength(1000)]
        public string? BlogAltTitle { get; set; }
        public string? BlogDescription { get; set; }
        public int? BlogTagId { get; set; }
        public List<BlogsTag>? Tag { get; set; } = new List<BlogsTag>();
        public DateTime Date_Time { get; set; } = DateTime.Now;
    }
}
