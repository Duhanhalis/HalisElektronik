using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HalisElektronik.Models
{
    [Table("ProductImage")]
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }

        [ForeignKey(name: nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
