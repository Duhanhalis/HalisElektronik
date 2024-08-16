using HalisElektronik.Models;
using HalisElektronik.Repositories;
using HalisElektronik.Repositories.Implementation;
using HalisElektronik.Repositories.Implementation.Api.Inteface;
using HalisElektronik.Repositories.Implementation.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace HalisElektronik.Services
{
    public static class Startup
    {
        public static void ServicesExtenisons(this IServiceCollection services)
        {
            //services.AddIdentityCore<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped<IGenericRepository<Product>, ProductRepository>();
            services.AddScoped<IGenericRepository<Blog>, BlogRepository>();
            services.AddScoped<IGenericRepository<BlogsTag>, BlogsTagRepository>();
            services.AddScoped<IGenericRepository<Category>, CategoryRepository>();
            services.AddScoped<IGenericRepository<ContainerMarketing>, ConMarRepository>();
            services.AddScoped<IGenericRepository<SocialMedia>, SocialMediaRepository>();
            services.AddScoped<IGenericRepository<Info>, InfoRepository>();
            services.AddScoped<IGenericRepository<CarouselMain>, CarouselMainRepository>();
            services.AddScoped<IGenericRepository<FeaturetteMain>, FeaturetteMainRepository>();
            services.AddScoped<IGenericRepository<Image>,ImageRepository>();
            services.AddScoped<IGenericImageRepository<Image>, ImageRepository>();
            services.AddScoped<IGenericImageRepository<ProductImage>, ProductImageRepository>();
            services.AddScoped<ProductImageRepository>();
            //#region Identity

            //services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>().
            //    AddDefaultTokenProviders();
            //services.AddRazorPages();


            //services.Configure<IdentityOptions>(options =>
            //{
            //    // Password settings.
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequiredLength = 6;
            //    options.Password.RequiredUniqueChars = 1;

            //    // Lockout settings.
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
            //    options.Lockout.MaxFailedAccessAttempts = 5;
            //    options.Lockout.AllowedForNewUsers = true;

            //    // User settings.
            //    options.User.AllowedUserNameCharacters =
            //    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            //    options.User.RequireUniqueEmail = false;
            //});

            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            //    options.LoginPath = "/Identity/Account/Login";
            //    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            //    options.SlidingExpiration = true;
            //});
            //#endregion



        }
    }
}
