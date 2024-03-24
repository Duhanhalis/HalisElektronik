using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Models
{
    [Table("MainClass")]
    public class Main
    {
        public int MainId { get; set; }
        public ICollection<CarouselMain>? carouselMains { get; set; }
        public ICollection<ContainerMarketing>? containerMarketings { get; set; }
        public ICollection<FeaturetteMain>? featuretteMains { get; set; }
    }
}
