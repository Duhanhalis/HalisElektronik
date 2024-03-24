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
        public IEnumerable<CarouselMain>? carouselMains { get; set; }
        public IEnumerable<ContainerMarketing>? containerMarketings { get; set; }
        public IEnumerable<FeaturetteMain>? featuretteMains { get; set; }
        public IEnumerable<SocialMedia>? socialMedias { get; set; }
    }
}
