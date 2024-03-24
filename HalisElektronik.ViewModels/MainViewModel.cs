using HalisElektronik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalisElektronik.Repositories;

namespace HalisElektronik.ViewModels
{
    public class MainViewModel
    {
        //private readonly ApplicationDbContext _context;

        //public MainViewModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        public int MainId { get; set; }
        public List<CarouselMain>? carouselMains { get; set; }
        public List<ContainerMarketing>? containerMarketings { get; set; }
        public List<FeaturetteMain>? featuretteMains { get; set; }
        public List<SocialMedia>? socialMedias { get; set; }
    }
}
