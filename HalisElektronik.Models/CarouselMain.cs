using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Models
{
    [Table("CarouselMain")]
    public class CarouselMain
    {
        [Key]
        public int CarouselMainId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? BtnTitle { get; set; }
        public string? BtnUrl { get; set; }
        [ForeignKey("MainId")]
        public int MainId { get; set; }

    }
}
