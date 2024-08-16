using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HalisElektronik.Models
{
    [Table("FeaturetteMain")]
    public class FeaturetteMain
    {
        [Key]
        public int FeaturetteMainId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        [ForeignKey(name: nameof(Image))]
        public int ImageId { get; set; }
        public Image? Images { get; set; }
    }
}
