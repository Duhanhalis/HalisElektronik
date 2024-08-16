using HalisElektronik.Repositories;
using Microsoft.EntityFrameworkCore;
using HalisElektronik.Services;
using HalisElektronik.Models;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
     .AddJsonOptions(options =>
     {
         options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
     });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(HalisElektronik.Dto.AutoMapperProfile).Assembly);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    string MySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection")!;
    options.UseMySql(MySqlConnection, ServerVersion.AutoDetect(MySqlConnection));
});

builder.Services.ServicesExtenisons();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await ApiDatabaseInitializer.Initialize(services);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
