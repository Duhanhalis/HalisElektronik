using HalisElektronik.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Dto
{
    public class CarouselMainCreateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? BtnTitle { get; set; }
        public string? BtnUrl { get; set; }
        public ImageDto? Images { get; set; }
    }
}
