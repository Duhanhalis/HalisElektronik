using HalisElektronik.Models;
using Microsoft.AspNetCore.Hosting;
using System.Linq.Expressions;

namespace HalisElektronik.Repositories.Implementation
{
    public class CategoryRepository : GenericRepository<Category>
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CategoryRepository(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

    }
}