using HalisElektronik.Models;
using HalisElektronik.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace HalisElektronik.Repositories.Implementation
{
    public class ProductRepository : GenericRepository<Product>
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductRepository(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
    }
}