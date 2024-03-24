using HalisElektronik.Models;
using HalisElektronik.Repositories;
using HalisElektronik.Repositories.Implementation;
using HalisElektronik.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace HalisElektronik.Services
{
    public static class Startup
    {
        public static void ServicesExtenisons(this IServiceCollection services)
        {
            services.AddIdentityCore<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped<IGenericRepository<Product>, ProductRepository>();
            services.AddScoped<IGenericRepository<Category>, CategoryRepository>();
            services.AddScoped<IGenericRepository<ProductImageList>, ProductImageRepository>();
            services.AddScoped<IGenericRepository<ContainerMarketing>, ConMarRepository>();
            services.AddScoped<IGenericRepository<Main>, MainRepository>();
            services.AddScoped<IGenericRepository<SocialMedia>, SocialMediaRepository>();
            services.AddScoped<IGenericRepository<CarouselMain>, CarouselMainRepository>();
            services.AddScoped<IGenericRepository<FeaturetteMain>, FeaturetteMainRepository>();
            //services.AddSingleton<IWebHostEnvironment>(env => HostingEnvironment);
            //services.AddIdentity<AppUser, AppRole>(options =>
            //{
            //    options.User.RequireUniqueEmail = true;
            //    options.User.AllowedUserNameCharacters = "abcçdefghýijklmnopqrsþtuüvwxyzABCÇDEFGHIÝJKLMNOPQRSÞTUÜVWXYZ0123456789-._@+";

            //    options.Password.RequiredLength = 6;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequireUppercase = true;
            //    options.Password.RequireDigit = false;

            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            //    options.Lockout.MaxFailedAccessAttempts = 3;
            //}).AddPasswordValidator<PasswordValidator>().AddErrorDescriber<LocalizationIdentityErrorDescriber>().AddUserValidator<UserValidator>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        }
    }
}
