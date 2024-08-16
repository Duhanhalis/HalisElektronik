using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HalisElektronik.Web.ViewComponents
{
    public class LayoutPageCategoryComponent : ViewComponent
    {
      private readonly ApiIRepository<Category> _repository;
        private readonly CategoryUrl _categoryUrl;
        public LayoutPageCategoryComponent(ApiIRepository<Category> repository, CategoryUrl categoryUrl)
        {
            _repository = repository;
            _categoryUrl = categoryUrl;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Category> model = await _repository.GetAllItemsAsync(_categoryUrl.CategoryList);
            return View(model.ToList());
        }
        
    }
}
