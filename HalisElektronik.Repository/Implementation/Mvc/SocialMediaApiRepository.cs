using HalisElektronik.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Repositories.Implementation.Mvc
{
    public class SocialMediaApiRepository : GenericApiRepository<SocialMedia>
    {
        public SocialMediaApiRepository(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
        {
        }
    }
}
