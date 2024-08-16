using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Dto
{
    [Table("ContainerMarketing")]
    public class ContainerMarketingDto
    {
        public int ContainerMarketingId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int ImageId { get; set; }
        public ImageDto? Images { get; set; }
    }
}
