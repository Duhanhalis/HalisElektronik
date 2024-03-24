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
        
        public int ProductId { get; set; }

        [
            Required
            ,MaxLength(150,ErrorMessage = "Uzunluğu Maksimum 150 Karakter Olabilir ?")
            ,MinLength(3,ErrorMessage = "Uzunluğu Maksimum 150 Karakter Olabilir ?")]
        public string Title { get; set; }
        public string? Description { get; set; } = string.Empty;
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public double? Price { get; set; }
        public bool IsStock { get; set; } = true;
        public DateTime Date_Of_Adjustment { get; set; } = DateTime.Now;
        public List<ProductImageListViewModel>? ListPhoto { get; set; }
    }   
}
