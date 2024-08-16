using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [MaxLength(100)]
        public string? BlogTitle { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string? BlogAltTitle { get; set; } = string.Empty;
        public string? BlogDescription { get; set; } = string.Empty;
        public int? BlogsTagId { get; set; }
        public BlogsTag Tags { get; set; }
        public DateTime Date_Time { get; set; } = DateTime.Now;
        [ForeignKey(name: nameof(Image))]
        public int ImageId { get; set; }
        public Image? BlogImage { get; set; }
    }
}
