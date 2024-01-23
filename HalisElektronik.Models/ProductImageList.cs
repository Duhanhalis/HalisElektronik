using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalisElektronik.Models
{
    /// <summary>
    /// Ürünlerin Fotoğrafları Tutulan Table
    /// </summary>
    [Table("ProductsImages")]
    public class ProductImageList
    {
        [Key]
        public int ProductMainId { get; set; }
        public string? ImageUrl_1 { get; set; }
        public string? ImageDescription { get; set; }
        public int? ProductId { get; set; }
        public Product ProductImgMain { get; set; } = null!;

    }
}
