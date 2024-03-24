﻿using HalisElektronik.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Repositories
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImageList> ProductImageLists { get; set; }
        public DbSet<AboutUs> Infos { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogsTag> BlogsTags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContainerMarketing> ContainerMarketings { get; set; }
        public DbSet<FeaturetteMain> FeaturetteMains { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<CarouselMain> CarouselMains { get; set; }
        public DbSet<Main> Mains { get; set; }
    }
}
