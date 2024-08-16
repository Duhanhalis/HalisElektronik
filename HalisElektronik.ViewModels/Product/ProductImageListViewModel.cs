using HalisElektronik.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.ViewModels
{
    public class ProductImageListViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile ImageUrlForm { get; set; } = null!;
        public int ProductId { get; set; }
        public Models.Product? Product { get; set; }
    }
}
