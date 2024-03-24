using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.ViewModels
{
    public class CMViewModel
    {
        [Key]
        public int ContainerMarketingId { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? ImageUrlFile { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
