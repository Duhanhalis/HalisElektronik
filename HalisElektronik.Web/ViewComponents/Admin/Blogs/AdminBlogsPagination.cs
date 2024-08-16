using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using System.Net.Http;

namespace HalisElektronik.Web.ViewComponents
{
    public class AdminBlogsPagination : ViewComponent
    {
        private readonly ApiIRepository<Blog> _blogRepository;
        private readonly BlogUrl _blogUrl;
        public AdminBlogsPagination(ApiIRepository<Blog> blogRepository, BlogUrl blogUrl)
        {
            _blogRepository = blogRepository;
            _blogUrl = blogUrl;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            var model = await _blogRepository.GetAllItemsAsync(_blogUrl.BlogList);
            return View(model.ToList().Count);
        }
    }
}
