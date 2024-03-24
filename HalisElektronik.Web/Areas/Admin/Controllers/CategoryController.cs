using HalisElektronik.Models;
using HalisElektronik.Repositories;
using HalisElektronik.Repositories.Implementation;
using HalisElektronik.Repositories.Interfaces;
using HalisElektronik.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace HalisElektronik.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IGenericRepository<Category> _repository;
        public CategoryController(IGenericRepository<Category> categoryRepository)
        {
            _repository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View(_repository.GetAll());
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
                await _repository.AddAsync(new Category()
                {
                    CategoryName = category.CategoryName,
                    CategoryDescription = category.CategoryDescription,
                    CategoryId = category.CategoryId,
                });
                return RedirectToAction("Index", "Home");
            }
           return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category category = _repository.GetById(id);

            return View(new CategoryViewModel()
            {
                CategoryDescription = category.CategoryDescription,
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            });
        }
        [HttpPost]
        public IActionResult Edit(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(new Category()
                {
                    CategoryName=category.CategoryName,
                    CategoryDescription=category.CategoryDescription,
                    CategoryId=category.CategoryId,
                });
                return RedirectToAction("Index","Home");
            }
            return View("Index");
        }
        
        public IActionResult Delete(int id)
        {
            Category category = _repository.GetById(id);
            if(category != null)
            {
                _repository.Delete(category);
            }
            return RedirectToAction("Index", "Home");

        }
    }
}
