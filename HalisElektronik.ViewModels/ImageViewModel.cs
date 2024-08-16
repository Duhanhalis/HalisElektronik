using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HalisElektronik.ViewModels
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
        public EntityTypeViewModel EntityId { get; set; }
    }
}
