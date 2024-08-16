using HalisElektronik.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Repositories.Implementation
{
    public class SocialMediaRepository : GenericRepository<SocialMedia>
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SocialMediaRepository(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
    }
}
