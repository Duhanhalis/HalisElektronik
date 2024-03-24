using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalisElektronik.Models
{
    /// <summary>
    /// Blogların Etiketlerinin Tutulduğu Table
    /// </summary>
    [Table("BlogsTag")]
    public class BlogsTag
    {
        [Key]
        public int BlogsId { get; set; }
        [Required, MaxLength(50), MinLength(3)]
        public string BlogsTagName { get; set; } = string.Empty;
    }
}
