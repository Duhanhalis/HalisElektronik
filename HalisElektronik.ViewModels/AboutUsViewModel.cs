using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.ViewModels
{
    public class AboutUsViewModel
    {
        public string? HeaderTitle { get; set; }
        public string? HeaderDescription { get; set; } = string.Empty;
        public string? InfoTitle { get; set; } = string.Empty;
        public string? InfoBody { get; set; } = string.Empty;
        public string? InfoMapsUrl { get; set; } = string.Empty;
    }
}
