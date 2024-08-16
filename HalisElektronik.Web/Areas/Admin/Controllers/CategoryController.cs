using HalisElektronik.Models;
using HalisElektronik.Repositories;
using HalisElektronik.Repositories.Implementation;
using HalisElektronik.ViewModels;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace HalisElektronik.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ApiIRepository<Category> _repository;
        private readonly CategoryUrl _categoryUrl;

        public CategoryController(ApiIRepository<Category> repository, CategoryUrl categoryUrl)
        {
            _repository = repository;
            _categoryUrl = categoryUrl;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllItemsAsync(_categoryUrl.CategoryList));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddItemAsync(_categoryUrl.CategoryCreate, new Category()
                {
                    CategoryName = category.CategoryName,
                    CategoryDescription = category.CategoryDescription,
                });
                return RedirectToAction(nameof(CategoryController.Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            Category category = await _repository.GetItemByIdAsync(_categoryUrl.CategoryGet, id);

            return View(new CategoryViewModel()
            {
                CategoryDescription = category.CategoryDescription,
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
               await _repository.UpdateItemAsync(_categoryUrl.CategoryEdit, new Category()
                {
                    CategoryName = category.CategoryName,
                    CategoryDescription = category.CategoryDescription,
                    CategoryId = category.CategoryId,
                });
                return RedirectToAction(nameof(CategoryController.Index));
            }
            return View(category);
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _repository.DeleteItemAsync(_categoryUrl.CategoryDelete, id);
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction(nameof(CategoryController.Index));

        }
    }
}
