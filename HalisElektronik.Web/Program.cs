using HalisElektronik.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HalisElektronik.Services;
using HalisElektronik.Repositories.Implementation;
using HalisElektronik.Models;
using HalisElektronik.Repositories.Implementation.Mvc;
using HalisElektronik.ViewModels.ApiFetch;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddDbContext<IdentityDb>(options =>
{
    options.UseSqlite("Data Source=IdentityLibrary.db");
});
builder.Services.ServicesExtenisonsApi();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    await DatabaseInitializer.Initialize(services,userManager);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();