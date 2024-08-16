using HalisElektronik.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;

namespace HalisElektronik.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : base(dbContext)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Info> Infos { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogsTag> BlogsTags { get; set; }
        public DbSet<Category> Categories { get; set; }

        #region Main Kisimi
        public DbSet<ContainerMarketing> ContainerMarketings { get; set; }
        public DbSet<FeaturetteMain> FeaturetteMains { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<CarouselMain> CarouselMains { get; set; }
        #endregion

        #region Images
        public DbSet<ProductImage> ProductImage { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
