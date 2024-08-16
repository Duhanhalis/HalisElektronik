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
    public class FeaturetteMainViewModel
    {
        [Key]
        public int FeaturetteMainId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int ImageId { get; set; }
        public ImageViewModel? Image { get; set; }
    }
}
