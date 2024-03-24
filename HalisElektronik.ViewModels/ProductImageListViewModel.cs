using HalisElektronik.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.ViewModels
{
    public class ProductImageListViewModel
    {
        [Key]
        public int ProductMainId { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public string? ImageUrlString { get; set; }
        public string? ImageDescription { get; set; }
        public int? ProductId { get; set; }
    }
}
