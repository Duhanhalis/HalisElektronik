using HalisElektronik.Models;
using HalisElektronik.Repositories;
using HalisElektronik.Repositories.Implementation.Mvc.Inteface;
using HalisElektronik.ViewModels;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace HalisElektronik.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ApiIRepository<Product> _repository;
        private readonly ApiIRepository<ProductImage> _repositoryImage;
        private readonly ApiIRepository<Category> _categoryRepository;

        private readonly ImageApiInterface<Image> _image;
        private readonly ImageApiInterface<ProductImage> _productImage;

        private readonly ImageUrl _imageUrl;
        private readonly ProductUrl _productUrl;
        private readonly CategoryUrl _categoryUrl;
        public ProductController(ApiIRepository<Product> repository, ApiIRepository<Category> categoryRepository, ImageUrl imageUrl, ProductUrl productUrl, CategoryUrl categoryUrl, ImageApiInterface<ProductImage> productImage, ApiIRepository<ProductImage> repositoryImage, ImageApiInterface<Image> image)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _imageUrl = imageUrl;
            _productUrl = productUrl;
            _categoryUrl = categoryUrl;
            _productImage = productImage;
            _repositoryImage = repositoryImage;
            _image = image;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllItemsAsync(_productUrl.ProductsList));
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.ListCategory = new SelectList(await _categoryRepository.GetAllItemsAsync(_categoryUrl.CategoryList), "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (model.Images != null)
                {
                    List<ProductImage> images = new List<ProductImage>();
                    foreach (var item in model.Images)
                    {
                        if (item.ImageFile != null)
                        {
                            images.Add(new ProductImage()
                            {
                                ImageUrl = await _productImage.AddImageAsync(_imageUrl.PhotoCreate, item.ImageFile, item.Title),
                                Title = item.Title,
                            });
                        }
                    }

                    await _repository.AddItemAsync(_productUrl.ProductCreate, new Product()
                    {
                        Title = model.Title,
                        CategoryId = model.CategoryId,
                        Date_Of_Adjustment = DateTime.Now,
                        Description = model.Description,
                        IsStock = model.IsStock,
                        Price = model.Price,
                        ProductImages = images
                    });
                }
                else
                {
                    await _repository.AddItemAsync(_productUrl.ProductCreate, new Product()
                    {
                        Title = model.Title,
                        CategoryId = model.CategoryId,
                        Date_Of_Adjustment = DateTime.Now,
                        Description = model.Description,
                        IsStock = model.IsStock,
                        Price = model.Price,
                        ProductImages = new List<ProductImage>()
                    });
                }
                return RedirectToAction("Index", "Product");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.ListCategory = new SelectList(await _categoryRepository.GetAllItemsAsync(_categoryUrl.CategoryList), "CategoryId", "CategoryName");

            Product model = await _repository.GetItemByIdAsync(_productUrl.ProductGet, id);
            //IEnumerable<Image> images = await _image.GetListById(_imageUrl.ImageGetListById, model.ImageId);

            if (model != null)
            {
                return View(new Product()
                {
                    ProductId = model.ProductId,
                    CategoryId = model.CategoryId,
                    Title = model.Title,
                    Date_Of_Adjustment = model.Date_Of_Adjustment,
                    Price = model.Price,
                    Description = model.Description,
                    IsStock = model.IsStock,
                    ProductImages = model.ProductImages
                });
            }

            return Redirect("/");
        }
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            _repository.UpdateItemAsync(_productUrl.ProductEdit, new Product()
            {
                ProductId = model.ProductId,
                Date_Of_Adjustment = DateTime.Now,
                CategoryId = model.CategoryId,
                Description = model.Description,
                IsStock = model.IsStock,
                Price = model.Price,
                Title = model.Title,
                //ImageId = model.ImageId,
            });
            return RedirectToAction(nameof(ProductController.Index));
        }

        
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var model = await _repository.GetItemByIdAsync(_productUrl.ProductGet, id);

            //var modelImage = await _repositoryImage.GetListById("Products/ProductImageGetList", model.ProductId);

            foreach (var item in model.ProductImages)
            {
                await _productImage.DeleteImageAsync("Products/ProductImageDelete", item.Id);
            }

            await _repository.DeleteItemAsync(_productUrl.ProductDelete, id);

            return RedirectToAction(nameof(ProductController.Index));
        }


        [HttpGet]
        public async Task<IActionResult> ProductsImgEdit(int id)
        {
            var model = await _repositoryImage.GetItemByIdAsync(_productUrl.ProductImageGet, id);

            return View(new ProductImageListViewModel()
            {
                Title = model.Title,
                ImageUrl = model.ImageUrl,
                ProductId = model.ProductId,
                Id = model.Id,
            });
        }
        [HttpPost]
        public async Task<IActionResult> ProductsImgEdit(ProductImageListViewModel image)
        {
            if (ModelState.IsValid)
            {
                var model = await _repositoryImage.GetItemByIdAsync(_productUrl.ProductImageGet, image.Id);

                if (image.ImageUrl != null)
                {
                    await _repositoryImage.DeleteItemAsync(_productUrl.ProductImageUpdateDelete, image.Id);
                    await _repositoryImage.UpdateItemAsync(_productUrl.ProductImageUpdate, new ProductImage()
                    {
                        Id = image.Id,
                        ImageUrl = await _image.AddImageAsync(_imageUrl.PhotoCreate, image.ImageUrlForm, image.Title),
                        ProductId = image.ProductId,
                        Title = model.Title,
                    });
                    return RedirectToAction(nameof(ProductController.Edit), new { id = image.ProductId });
                }
                else
                {
                    await _repositoryImage.UpdateItemAsync(_productUrl.ProductImageUpdate, new ProductImage()
                    {
                        Id = image.Id,
                        ImageUrl = image.ImageUrl,
                        ProductId = image.ProductId,
                        Title = model.Title,
                    });
                    return RedirectToAction(nameof(ProductController.Edit), new { id = image.ProductId });
                }

            }
            return View();
        }
        [HttpGet]
        public IActionResult ProductsImgCreate(int id)
        {
            return View(new ProductImageListViewModel()
            {
                ProductId = id,
            });
        }
        [HttpPost]
        public async Task<IActionResult> ProductsImgCreate(ProductImageListViewModel image)
        {
            if (ModelState.IsValid)
            {
                await _repositoryImage.AddItemAsync(_productUrl.ProductImageCreateByModel, new ProductImage()
                {
                    ProductId = image.ProductId,
                    ImageUrl = await _image.AddImageAsync(_imageUrl.PhotoCreate, image.ImageUrlForm, image.Title),
                    Title = image.Title,
                });
                return RedirectToAction(nameof(ProductController.Edit), new { id = image.ProductId });
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        public async Task<IActionResult> ProductsImgDelete(int id, int requestUrl)
        {
            await _repositoryImage.DeleteItemAsync(_productUrl.ProductImageDelete, id);

            return RedirectToAction(nameof(ProductController.Edit), new { id = requestUrl });
        }
    }
}