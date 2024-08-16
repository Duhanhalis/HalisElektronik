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
    public static class ApiDatabaseInitializer
    {
        public static async Task Initialize(IServiceProvider services)
        {
            using (var context = new ApplicationDbContext(services.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Veritabanını oluştur ve varsa migrasyonları uygula
                await context.Database.MigrateAsync();
            }
        }
    }
}
