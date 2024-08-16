using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HalisElektronik.Web.ViewComponents.Admin.Blogs
{
    public class AdminBlogsTags : ViewComponent
    {
        private readonly ApiIRepository<BlogsTag> _repository;
        private readonly BlogTagUrl _blogTagUrl;
        public AdminBlogsTags(ApiIRepository<BlogsTag> repository, BlogTagUrl blogUrl)
        {
            _repository = repository;
            _blogTagUrl = blogUrl;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _repository.GetAllItemsAsync(_blogTagUrl.BlogTagList);
            return View(model.ToList());
        }
    }
}
