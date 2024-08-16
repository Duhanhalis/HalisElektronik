using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HalisElektronik.Web.ViewComponents
{
    public class LayoutPageBlogComponent : ViewComponent
    {
       private readonly ApiIRepository<BlogsTag> _repository;
        private readonly BlogTagUrl _blogTag;
        public LayoutPageBlogComponent(ApiIRepository<BlogsTag> repository, BlogTagUrl blogTag)
        {
            _repository = repository;
            _blogTag = blogTag;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _repository.GetAllItemsAsync(_blogTag.BlogTagList);
            return View(model.ToList());
        }
    }
}
