using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Models
{
    [Table("ProductsMainImage")]
    public class ProductMainImage
    {
        [Key]
        public int? MainId { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageDescription { get; set; }
        public int? ProductId { get; set; }
        public Product ProductsCard { get; set; } = null!;
    }
}
