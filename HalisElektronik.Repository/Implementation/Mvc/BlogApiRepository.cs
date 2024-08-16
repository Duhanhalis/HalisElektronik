using HalisElektronik.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Repositories.Implementation.Mvc
{
    public class BlogApiRepository : GenericApiRepository<Blog>
    {
        public BlogApiRepository(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
        {
        }
    }
}
