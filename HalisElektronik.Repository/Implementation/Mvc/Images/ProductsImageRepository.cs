using HalisElektronik.Models;
using HalisElektronik.Repositories.Implementation.Mvc.Generic;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Repositories.Implementation.Mvc.Images
{
    public class ProductsImageRepository : ImageApiRepository<ProductImage>
    {
        public ProductsImageRepository(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
        {
        }
    }
}
