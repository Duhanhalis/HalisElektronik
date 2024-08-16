using HalisElektronik.Models;
using HalisElektronik.Repositories.Implementation.Api.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Repositories.Implementation
{
    public class ProductImageRepository : GenericImageRepository<ProductImage>
    {
        public ProductImageRepository(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment) : base(context, webHostEnvironment)
        {
        }
       
    }
}
