using HalisElektronik.Models;
using HalisElektronik.Repositories;
using HalisElektronik.ViewModels;
using HalisElektronik.ViewModels.ApiFetch;
using HalisElektronik.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;

namespace HalisElektronik.Web.Controllers
{
    [Route("Ürünler")]
    public class ProductsController : Controller
    {
        private readonly ApiIRepository<Product> _repository;
        private readonly ProductUrl _homeUrl;

        public ProductsController(ApiIRepository<Product> repository, ProductUrl homeUrl)
        {
            _repository = repository;
            _homeUrl = homeUrl;
        }

        [HttpGet("Liste")]
        public async Task<IActionResult> Index(int page = 1, string? searchQuery = null, int? categoryQuery = null)
        {
            int _count = 20;
            var products = await _repository.GetAllItemsAsync(_homeUrl.ProductsList);

            // Ikiside Null Ise
            if (categoryQuery == null && String.IsNullOrEmpty(searchQuery))
            {
                return View(products.Skip((page - 1) * _count).Take(_count).ToList());
            }
            // SearchQuery Null Ise
            else if (String.IsNullOrEmpty(searchQuery) && categoryQuery != null)
            {
                return View(products.Where(x => x.CategoryId == categoryQuery).Skip((page - 1) * _count).Take(_count).ToList());
            }
            // Category Null Ise
            else if (searchQuery != null && categoryQuery == null)
            {
                return View(products.Where(x => x.Title.ToLower().Contains(searchQuery.ToLower()) ||
                x.Description.ToLower().Contains(searchQuery.ToLower()) ||
                x.ProductId.ToString().ToLower().Contains(searchQuery.ToLower()) ||
                x.Category.CategoryName.ToLower().Contains(searchQuery.ToLower()) ||
                x.Category.CategoryDescription.ToLower().Contains(searchQuery.ToLower())).Skip((page - 1) * _count).Take(_count).ToList());
            }
            else
            {
                return View(products.Where(x =>
                (x.Title.ToLower().Contains(searchQuery.ToLower()) || x.Description.ToLower().Contains(searchQuery.ToLower()) || x.Category.CategoryName.ToLower().Contains(searchQuery.ToLower()) || x.Category.CategoryDescription.Contains(searchQuery.ToLower())) &&
                x.CategoryId == categoryQuery).Skip((page - 1) * _count).Take(_count).ToList());
            }

        }
        //[HttpGet("Liste/{id?}")]
        [HttpGet("Liste/{id?}")]
        public async Task<IActionResult> Details(int id,string? mainPhoto = null)
        {
            try
            {
                var product = await _repository.GetItemByIdAsync(_homeUrl.ProductGet, id);
                if(product != null)
                {
                return View(new ProductDetailsViewModel()
                {
                    Category = product.Category,
                    CategoryId = product.CategoryId,
                    Date_Of_Adjustment = product.Date_Of_Adjustment,
                    Description = product.Description,
                    IsStock = product.IsStock,
                    Price = product.Price,
                    ProductId = product.ProductId,
                    ProductImages = product.ProductImages,
                    Title = product.Title,
                    MainPhoto = mainPhoto,
                });
                }
                else
                {
                    return View(null);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
