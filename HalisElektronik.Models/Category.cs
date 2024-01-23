using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalisElektronik.Models
{
    /// <summary>
    /// Kategorileri Databaseden Alıyor
    /// </summary>
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [MaxLength(50),MinLength(3)]
        public string CategoryName { get; set; } = string.Empty!;
        [MaxLength(200)]
        public string? CategoryDescription { get; set; }
        public List<Product>? Products { get; set; } = new List<Product>();
    }
}
