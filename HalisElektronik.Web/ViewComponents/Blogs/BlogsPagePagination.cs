using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HalisElektronik.Web.ViewComponents
{
    public class BlogsPagePagination : ViewComponent
    {
        private readonly ApiIRepository<Blog> _repository;
        private readonly BlogUrl _blogUrl;
        public BlogsPagePagination(ApiIRepository<Blog> repository, BlogUrl blogUrl)
        {
            _repository = repository;
            _blogUrl = blogUrl;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _repository.GetAllItemsAsync(_blogUrl.BlogList);
            return View(model.ToList().Count);
        }
    }
}
