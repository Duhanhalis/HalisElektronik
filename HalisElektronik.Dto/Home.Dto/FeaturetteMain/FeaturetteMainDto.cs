using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Dto
{
    [Table("FeaturetteMain")]
    public class FeaturetteMainDto
    {
        public int FeaturetteMainId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int ImageId { get; set; }
        public ImageDto? Images { get; set; }
    }
}
