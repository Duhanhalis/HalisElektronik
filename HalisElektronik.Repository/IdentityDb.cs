using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HalisElektronik.Models;
using Microsoft.Extensions.DependencyInjection;

namespace HalisElektronik.Repositories
{
    public class IdentityDb : IdentityDbContext<IdentityUser,IdentityRole,string>
    {
        public IdentityDb(DbContextOptions<IdentityDb> options):base(options)
        {
            
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }
    }
}
