using HalisElektronik.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Dto
{
    public class CategoryEditDto
    {
        public int CategoryId { get; set; }
        [MaxLength(50), MinLength(3)]
        public string CategoryName { get; set; } = string.Empty!;
        [MaxLength(200)]
        public string? CategoryDescription { get; set; }
    }
}
