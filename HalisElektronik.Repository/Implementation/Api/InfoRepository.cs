using HalisElektronik.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Repositories.Implementation
{
    public class InfoRepository:GenericRepository<Info>
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment1;
        public InfoRepository(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment1):base(context,webHostEnvironment1)
        {
            _context = context;
            this.webHostEnvironment1 = webHostEnvironment1;
        }


    }
}
    