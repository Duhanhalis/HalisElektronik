using HalisElektronik.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Repositories.Implementation.Mvc
{
    public class FeaturetteMainApiRepository : GenericApiRepository<FeaturetteMain>
    {
        public FeaturetteMainApiRepository(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
        {
        }
    }
}
