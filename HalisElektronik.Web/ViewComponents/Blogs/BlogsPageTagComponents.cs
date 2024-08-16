using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HalisElektronik.Web.ViewComponents
{
    public class BlogsPageTagComponents : ViewComponent
    {
        private readonly ApiIRepository<BlogsTag> _repository;
        private readonly BlogTagUrl _blogTagUrl;
        public BlogsPageTagComponents(ApiIRepository<BlogsTag> repository, BlogTagUrl blogTagUrl)
        {
            _repository = repository;
            _blogTagUrl = blogTagUrl;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _repository.GetAllItemsAsync(_blogTagUrl.BlogTagList);
            return View(model.ToList());
        }
    }
}
