using HalisElektronik.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.ViewModels
{
    public class ProductViewModel
    {

        [Key]
        public int ProductId { get; set; }

        [Required, MaxLength(150), MinLength(3)]
        public string Title { get; set; } = string.Empty!;
        public string? Description { get; set; } = string.Empty;
        public int? CategoryId { get; set; } = null;
        public CategoryViewModel? Category { get; set; }
        public double? Price { get; set; } = null;
        public bool IsStock { get; set; } = true;
        public DateTime Date_Of_Adjustment { get; set; } = DateTime.Now;
        public int ImageId { get; set; }
        public List<ImageViewModel>? Images { get; set; }
    }   
}
