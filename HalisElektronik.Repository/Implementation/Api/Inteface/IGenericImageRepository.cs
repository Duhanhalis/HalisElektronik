using HalisElektronik.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Repositories.Implementation.Api.Inteface
{
    public interface IGenericImageRepository<T>:IGenericRepository<T> where T : class
    {
        Task<string> ImageCreate(IFormFile formFile, string fileTitle);
        void ImageDelete(string imageName);
        List<ProductImage> ProductImageGet(int id);
    }
}
