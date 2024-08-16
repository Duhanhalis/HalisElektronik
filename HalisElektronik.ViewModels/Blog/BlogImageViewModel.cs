using HalisElektronik.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.ViewModels
{
    public class BlogImagesViewModel
    {
        [Key]
        public int Id { get; set; }
        public string? ImageDescription { get; set; }
        public string? ImageUrl { get; set; }
        public int? BlogId { get; set; }
        public IFormFile? Image { get; set; }
    }
}
