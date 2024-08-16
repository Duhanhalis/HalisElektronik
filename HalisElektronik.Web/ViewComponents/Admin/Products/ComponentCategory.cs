using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HalisElektronik.Web.ViewComponents
{
    public class ComponentCategory : ViewComponent
    {
        private readonly ApiIRepository<Category> _repository;
        private readonly CategoryUrl _categoryUrl;
        public ComponentCategory(ApiIRepository<Category> repository, CategoryUrl categoryUrl)
        {
            _repository = repository;
            _categoryUrl = categoryUrl;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            return View(await _repository.GetAllItemsAsync(_categoryUrl.CategoryList));
        }
    }
}
