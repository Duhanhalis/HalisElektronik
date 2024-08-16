using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.ViewModels
{
    public class SocialMediaViewModel
    {
        public int SocialMediaId { get; set; }
        public string? Title { get; set; }
        public string? Link { get; set; }
        public int ImageId { get; set; }
        public ImageViewModel? Image { get; set; }
    }
}
