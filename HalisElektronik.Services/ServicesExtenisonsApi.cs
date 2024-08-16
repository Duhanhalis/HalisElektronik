using HalisElektronik.Models;
using HalisElektronik.Repositories;
using HalisElektronik.Repositories.Implementation.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using HalisElektronik.ViewModels.ApiFetch;
using HalisElektronik.Repositories.Implementation.Mvc.Inteface;
using HalisElektronik.Repositories.Implementation.Mvc.Generic;
using HalisElektronik.Repositories.Implementation.Mvc.Images;
using HalisElektronik.Repositories.Implementation;
namespace HalisElektronik.Services
{
    public static class StartupApi
    {
        public static void ServicesExtenisonsApi(this IServiceCollection services)
        {
            #region Api To Mvc
            services.AddScoped<ApiIRepository<Blog>, BlogApiRepository>();
            services.AddScoped<ApiIRepository<Product>, ProductApiRepository>();
            services.AddScoped<ApiIRepository<BlogsTag>, BlogsTagApiRepository>();
            services.AddScoped<ApiIRepository<Category>, CategoryApiRepository>();
            services.AddScoped<ApiIRepository<ContainerMarketing>, ConMarApiRepository>();
            services.AddScoped<ApiIRepository<SocialMedia>, SocialMediaApiRepository>();
            services.AddScoped<ApiIRepository<Info>, InfoApiRepository>();
            services.AddScoped<ApiIRepository<CarouselMain>, CarouselMainApiRepository>();
            services.AddScoped<ApiIRepository<FeaturetteMain>, FeaturetteMainApiRepository>();
            services.AddScoped<ApiIRepository<ProductImage>, ProductIImageGenericRepository>();

            services.AddScoped<ImageApiInterface<Image>, Repositories.Implementation.Mvc.Images.ImageRepository>();
            services.AddScoped<ImageApiInterface<ProductImage>, ProductsImageRepository>();
            services.AddScoped<HomeUrl>();
            services.AddScoped<InfoUrl>();
            services.AddScoped<ImageUrl>();
            services.AddScoped<CategoryUrl>();
            services.AddScoped<BlogTagUrl>();
            services.AddScoped<BlogUrl>();
            services.AddScoped<ProductUrl>();

            #endregion

            #region Identity

            services.AddIdentity<ApplicationUser,ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<IdentityDb>().AddDefaultTokenProviders();
            services.AddRazorPages();


            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Admin/Admin/GiriþYap";
                options.AccessDeniedPath = "/Admin/Admin/GiriþYap";
                options.SlidingExpiration = true;
            });
            #endregion

        }
    }
}
