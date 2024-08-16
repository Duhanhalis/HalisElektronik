using HalisElektronik.Models;
using HalisElektronik.Repositories;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HalisElektronik.Web.ViewComponents
{
    public class ProductsPageCategoryComponents : ViewComponent
    {
        private readonly ApiIRepository<Category> _repository;
        private readonly CategoryUrl _categoryUrl;
        public ProductsPageCategoryComponents(ApiIRepository<Category> repository, CategoryUrl categoryUrl)
        {
            _repository = repository;
            _categoryUrl = categoryUrl;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _repository.GetAllItemsAsync(_categoryUrl.CategoryList);
            return View(model.ToList());
        }
    }
}
