using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Repositories.Implementation.Mvc.Inteface
{
    public interface ImageApiInterface<T> where T : class
    {
        Task<string> AddImageAsync(string ApiAction, IFormFile item, string name);
        Task<bool> DeleteImageAsync(string ApiAction, int id);
        Task<T> AddImageClassAsync(string ApiAction, T item);
    }
}
