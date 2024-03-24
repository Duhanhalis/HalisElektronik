using HalisElektronik.Models;
using HalisElektronik.Repositories;
using HalisElektronik.Repositories.Interfaces;
using HalisElektronik.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using System.IO;

namespace HalisElektronik.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IGenericRepository<Category> _repositoryCategory;
        private readonly IGenericRepository<ProductImageList> _repositoryImageList;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _context;

        public ProductController(IGenericRepository<Product> repository, IGenericRepository<Category> repositoryCategory, IWebHostEnvironment webHostEnvironment, ApplicationDbContext context, IGenericRepository<ProductImageList> repositoryImageList)
        {
            _repository = repository;
            _repositoryCategory = repositoryCategory;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _repositoryImageList = repositoryImageList;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = new List<Product>();
            foreach (var item in _context.Products.ToList())
            {
                var img = _context.ProductImageLists.Where(x => x.ProductId == item.ProductId).ToList();
                if (img != null)
                {
                    products.Add(new Product()
                    {
                        ProductId = item.ProductId,
                        CategoryId = item.CategoryId,
                        Date_Of_Adjustment = item.Date_Of_Adjustment,
                        Description = item.Description,
                        IsStock = item.IsStock,
                        Price = item.Price,
                        Title = item.Title,
                        ProductImageList = img
                    });
                }
            }
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ListCategory = new SelectList(_repositoryCategory.GetAll(), "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                List<ProductImageList> images = new List<ProductImageList>();
                if (product.ListPhoto != null && product.ListPhoto.Any())
                {
                    foreach (var photo in product.ListPhoto)
                    {
                        if (photo.ImageUrl != null)
                        {
                            // Dosyayý wwwroot klasörüne kaydedin
                            //var webRootPath = $"{_webHostEnvironment.WebRootPath}//ProductImages";
                            //var fileName = $"{product.Title}_{product.CategoryId}_{photo.ImageUrl.FileName}";
                            //var filePath = Path.Combine(webRootPath, fileName);

                            //using (var stream = new FileStream(filePath, FileMode.Create))
                            //{
                            //    photo.ImageUrl.CopyTo(stream);
                            //}
                            var fileName = await _repositoryImageList.ImageCreate(photo.ImageUrl, product.Title);
                            images.Add(
                                new ProductImageList()
                                {
                                    ImageUrl_1 = fileName,
                                    ImageDescription = photo.ImageDescription
                                });
                        }
                    }
                }
                _repository.Add(new Product()
                {
                    Title = product.Title,
                    Description = product.Description,
                    CategoryId = product.CategoryId,
                    Category = product.Category,
                    Date_Of_Adjustment = product.Date_Of_Adjustment,
                    IsStock = product.IsStock,
                    Price = product.Price,
                    ProductImageList = images
                });
                return RedirectToAction("Index", "Product");
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _repository.GetById(id);
            var productImgList = _context.ProductImageLists.Where(pi => pi.ProductId == product.ProductId).ToList();
            List<ProductImageListViewModel> images = new List<ProductImageListViewModel>();
            if (product.ProductImageList != null)
            {
                foreach (var item in productImgList)
                {
                    images.Add(new ProductImageListViewModel()
                    {
                        ImageDescription = item.ImageDescription,
                        ImageUrlString = item.ImageUrl_1,
                        ProductMainId = item.ProductMainId,
                        ProductId = item.ProductId,
                    });
                }
            }



            //while (images.Count < 4)
            //{
            //    images.Add(new() { ImageUrl = null, ImageDescription = "", ImageUrlString = "No-Image.jpg" });
            //}


            ViewBag.ListCategory = new SelectList(_repositoryCategory.GetAll(), "CategoryId", "CategoryName");
            return View(new ProductViewModel()
            {
                Category = product.Category,
                CategoryId = product.CategoryId,
                Date_Of_Adjustment = product.Date_Of_Adjustment,
                Description = product.Description,
                IsStock = product.IsStock,
                ListPhoto = images,
                Price = product.Price,
                Title = product.Title,
                ProductId = product.ProductId,
            });
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel model)
        {

            var productImgList = _context.ProductImageLists.Where(pi => pi.ProductId == model.ProductId).ToList();
            _repository.Update(new Product()
            {
                ProductId = model.ProductId,
                Date_Of_Adjustment = DateTime.Now,
                CategoryId = model.CategoryId,
                Description = model.Description,
                IsStock = model.IsStock,
                Price = model.Price,
                Title = model.Title,
                ProductImageList = productImgList
            });
            return RedirectToAction("Index", "Product");
        }
        public IActionResult Delete(int id)
        {
            var result = _context.ProductImageLists.Where(x => x.ProductId == id).ToList();
            _repository.Delete(_context.Products.Find(id));
            foreach (var item in result)
            {
                var webRootPath = $"{_webHostEnvironment.WebRootPath}//ProductImages";
                if (System.IO.File.Exists(webRootPath + "//" + item.ImageUrl_1))
                {
                    System.IO.File.Delete(webRootPath + "//" + item.ImageUrl_1);
                }
                _context.ProductImageLists.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Product");
        }
        [HttpGet]
        public IActionResult ProductsImgEdit(int id)
        {
            ProductImageList image = _repositoryImageList.GetById(id);

            return View(new ProductImageListViewModel()
            {
                ImageDescription = image.ImageDescription,
                ImageUrlString = image.ImageUrl_1,
                ProductMainId = image.ProductMainId,
                ProductId = image.ProductId,
            });
        }
        [HttpPost]
        public IActionResult ProductsImgEdit(ProductImageListViewModel image)
        {
            if (ModelState.IsValid)
            {
                string oldImg = image.ImageUrlString;
                var webRootPath = $"{_webHostEnvironment.WebRootPath}//ProductImages";
                var fileName = $"{Guid.NewGuid()}_{image.ImageUrl.FileName}";
                var filePath = Path.Combine(webRootPath, fileName);

                if (System.IO.File.Exists(webRootPath + "//" + oldImg))
                {
                    System.IO.File.Delete(webRootPath + "//" + oldImg);
                }
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.ImageUrl.CopyTo(stream);
                }

                _repositoryImageList.Update(new ProductImageList()
                {
                    ImageDescription = image.ImageDescription,
                    ProductId = image.ProductId,
                    ProductMainId = image.ProductMainId,
                    ImageUrl_1 = fileName
                });
                return RedirectToAction("Edit", "Product", new { id = image.ProductId });
            }
            return View();
        }
        [HttpGet]
        public IActionResult ProductsImgCreate(int id)
        {
            //var result = _repository.GetById(id);

            return View(new ProductImageListViewModel()
            {
                ProductId = id,
            });
        }
        [HttpPost]
        public async Task<IActionResult> ProductsImgCreate(ProductImageListViewModel image)
        {

            //var webRootPath = $"{_webHostEnvironment.WebRootPath}//ProductImages";
            //var fileName = $"{Guid.NewGuid()}_{image.ImageUrl.FileName}";
            //var filePath = Path.Combine(webRootPath, fileName);

            //using (var stream = new FileStream(filePath, FileMode.Create))
            //{
            //    image.ImageUrl.CopyTo(stream);
            //}
            var fileName = await _repositoryImageList.ImageCreate(image.ImageUrl, image.ImageDescription);
            _repositoryImageList.Add(new ProductImageList()
            {
                ProductId = image.ProductId,
                ImageDescription = image.ImageDescription,
                ImageUrl_1 = fileName
            });
            return RedirectToAction("Edit", "Product", new { id = image.ProductId });


            //return View();
        }
        [HttpGet]
        public IActionResult ProductsImgDelete(int id)
        {
            var result = _context.ProductImageLists.Find(id);
            _repositoryImageList.ImageDelete(result.ImageUrl_1);
            _repositoryImageList.Delete(result);
            return RedirectToAction("Edit", "Product", new { id = result.ProductId });
        }
    }
}