using HalisElektronik.Models;
using HalisElektronik.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Services
{
    public static class DatabaseInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            using (var context = new IdentityDb(serviceProvider.GetRequiredService<DbContextOptions<IdentityDb>>()))
            {
                // Veritabanını oluştur ve varsa migrasyonları uygula
                context.Database.Migrate();

                // Eğer veri tabanında belirli bir veri yoksa varsayılan verileri ekle
                if (!context.ApplicationUsers.Any())
                {
                    var user = new ApplicationUser
                    { Email = "duhanhalis@gmail.com", UserName = "Zekihalis", EmailConfirmed = true};
                    var result = await userManager.CreateAsync(user, "Duhanhalis12345");
                    context.SaveChanges();
                }
            }
        }
    }
}
