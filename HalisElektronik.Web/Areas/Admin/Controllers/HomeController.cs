using HalisElektronik.Models;
using HalisElektronik.Repositories;
using HalisElektronik.Repositories.Implementation;
using HalisElektronik.Repositories.Interfaces;
using HalisElektronik.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace HalisElektronik.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IGenericRepository<CarouselMain> _carouselMain;
        private readonly IGenericRepository<ContainerMarketing> _containerMarketing;
        private readonly IGenericRepository<FeaturetteMain> _featuretteMain;
        private readonly IGenericRepository<SocialMedia> _socialMedia;
        public HomeController(ApplicationDbContext applicationDbContext, IGenericRepository<CarouselMain> carouselMain, IGenericRepository<FeaturetteMain> featuretteMain, IGenericRepository<ContainerMarketing> containerMarketing, IGenericRepository<SocialMedia> socialMedia)
        {
            _context = applicationDbContext;
            this._carouselMain = carouselMain;
            this._featuretteMain = featuretteMain;
            this._containerMarketing = containerMarketing;
            _socialMedia = socialMedia;
        }

        public IActionResult Index()
        {
            List<Product> products = new List<Product>();
            List<Category> categories = new List<Category>();
            foreach (var item in _context.Products.Take(10).ToList())
            {
                products.Add(item);
            }
            foreach (var item in _context.Categories.Take(10).ToList())
            {
                categories.Add(item);
            }

            return View(new ModelClassView() { categories = categories, product = products });
        }
        public IActionResult Main()
        {
            Main mainViewModel = new Main()
            {
                carouselMains = _carouselMain.GetAll(),
                containerMarketings = _containerMarketing.GetAll(),
                featuretteMains = _featuretteMain.GetAll(),
                socialMedias = _socialMedia.GetAll(),
            };
            return View(mainViewModel);
        }
        #region AboutUs
        //public IActionResult AboutUs()
        //{
        //    AboutUsViewModel aboutViewModel = new AboutUsViewModel()
        //    {
        //        HeaderTitle = "Deneme",
        //        HeaderDescription = "Deneem",
        //        BlogTitle = "",
        //        BlogDescription = "",
        //        WorkingHours = "",
        //        MapUrl = "",
        //        InfoId = 1
        //    };
        //    string fileName = "AboutUs.json";
        //    string jsonString = JsonSerializer.Serialize<AboutUsViewModel>(aboutViewModel);

        //    return View($"AboutUs/{nameof(HomeController.AboutUs)}",jsonString);
        //}
        //[HttpGet]
        //public IActionResult AboutUsEdit()
        //{
        //    return View($"AboutUs/{nameof(HomeController.AboutUsAdd)}");
        //}
        //public IActionResult AboutUsAdd(AboutUsViewModel model)
        //{

        //    return View(nameof(HomeController.AboutUs));
        //}

        #endregion
        #region Carousel
        public IActionResult CarouselAdd()
        {
            return View($"Carousel/{nameof(HomeController.CarouselAdd)}");
        }
        [HttpPost]
        public async Task<IActionResult> CarouselAdd(CarouselViewModel carouselViewModel)
        {
            if (ModelState.IsValid)
            {
                await _carouselMain.AddAsync(new CarouselMain()
                {
                    Title = carouselViewModel.Title,
                    Description = carouselViewModel.Description,
                    BtnTitle = carouselViewModel.BtnTitle,
                    BtnUrl = carouselViewModel.BtnUrl,
                    ImageUrl = await _carouselMain.ImageCreate(carouselViewModel.ImageUrlFile, "Carousel"),
                });
            }
            return RedirectToAction(nameof(HomeController.Main));
        }
        public async Task<IActionResult> CarouselDelete(int id)
        {
            CarouselMain carousel = await _carouselMain.GetByIdAsync(id);

            _carouselMain.ImageDelete(carousel.ImageUrl);
            _carouselMain.Delete(carousel);

            return RedirectToAction(nameof(HomeController.Main));
        }
        public async Task<IActionResult> CarouselEdit(int id)
        {
            CarouselMain carousel = await _carouselMain.GetByIdAsync(id);

            return View($"Carousel/{nameof(HomeController.CarouselEdit)}", new CarouselViewModel()
            {
                Title = carousel.Title,
                Description = carousel.Description,
                BtnTitle = carousel.BtnTitle,
                BtnUrl = carousel.BtnUrl,
                ImageUrl = carousel.ImageUrl,
                CarouselMainId = id
            });
        }
        [HttpPost]
        public async Task<IActionResult> CarouselEdit(CarouselViewModel carouselViewModel)
        {
            if (ModelState.IsValid)
            {
                if (carouselViewModel.ImageUrlFile != null)
                {
                    //Image Sil
                    _carouselMain.ImageDelete(carouselViewModel.ImageUrl);
                    //Image Ekle
                    _carouselMain.Update(new CarouselMain()
                    {
                        Title = carouselViewModel.Title,
                        BtnTitle = carouselViewModel.BtnTitle,
                        BtnUrl = carouselViewModel.BtnUrl,
                        CarouselMainId = carouselViewModel.CarouselMainId,
                        Description = carouselViewModel.Description,
                        ImageUrl = await _carouselMain.ImageCreate(carouselViewModel.ImageUrlFile, "Carousel"),
                    });
                }
                else
                {
                    _carouselMain.Update(new CarouselMain()
                    {
                        CarouselMainId = carouselViewModel.CarouselMainId,
                        Title = carouselViewModel.Title,
                        BtnTitle = carouselViewModel.BtnTitle,
                        BtnUrl = carouselViewModel.BtnUrl,
                        Description = carouselViewModel.Description,
                        ImageUrl = carouselViewModel.ImageUrl,
                    });
                }
                return RedirectToAction(nameof(HomeController.Main));
            }
            else
            {
                return View(carouselViewModel);
            }
        }
        #endregion

        #region Container Marketing
        public IActionResult ContainerMarketingAdd()
        {
            return View($"ContainerMarketing/{nameof(HomeController.ContainerMarketingAdd)}");
        }
        [HttpPost]
        public async Task<IActionResult> ContainerMarketingAdd(CMViewModel containerMarketing)
        {
            if (ModelState.IsValid)
            {

                await _containerMarketing.AddAsync(new ContainerMarketing()
                {
                    Title = containerMarketing.Title,
                    Description = containerMarketing.Description,
                    ImageUrl = await _containerMarketing.ImageCreate(containerMarketing.ImageUrlFile, "ContainerMarketing"),
                });
            }
            return RedirectToAction(nameof(HomeController.Main));
        }
        public async Task<IActionResult> ContainerMarketingDelete(int id)
        {
            ContainerMarketing containerMarketing = await _containerMarketing.GetByIdAsync(id);

            _containerMarketing.ImageDelete(containerMarketing.ImageUrl);
            _containerMarketing.Delete(containerMarketing);

            return RedirectToAction(nameof(HomeController.Main));
        }
        public async Task<IActionResult> ContainerMarketingEdit(int id)
        {
            ContainerMarketing carousel = await _containerMarketing.GetByIdAsync(id);
            return View($"ContainerMarketing/{nameof(HomeController.ContainerMarketingAdd)}", new CMViewModel()
            {
                Title = carousel.Title,
                Description = carousel.Description,
                ImageUrl = carousel.ImageUrl,
                ContainerMarketingId = id
            });
        }
        [HttpPost]
        public async Task<IActionResult> ContainerMarketingEdit(CMViewModel containerMarketing)
        {
            if (ModelState.IsValid)
            {
                if (containerMarketing.ImageUrlFile != null)
                {
                    // Image Delete
                    _containerMarketing.ImageDelete(containerMarketing.ImageUrl);
                    // Image Create
                    _containerMarketing.Update(new ContainerMarketing()
                    {
                        Title = containerMarketing.Title,
                        ContainerMarketingId = containerMarketing.ContainerMarketingId,
                        Description = containerMarketing.Description,
                        ImageUrl = await _containerMarketing.ImageCreate(containerMarketing.ImageUrlFile, "ContainerMarketing"),
                    });
                }
                else
                {
                    _containerMarketing.Update(new ContainerMarketing()
                    {
                        ContainerMarketingId = containerMarketing.ContainerMarketingId,
                        Title = containerMarketing.Title,
                        Description = containerMarketing.Description,
                        ImageUrl = containerMarketing.ImageUrl,
                    });
                }
                return RedirectToAction(nameof(HomeController.Main));
            }
            else
            {
                return View(containerMarketing);
            }
        }
        #endregion

        #region FeaturetteMain
        public IActionResult FeaturetteMainAdd()
        {
            return View($"Featurette/{nameof(HomeController.FeaturetteMainAdd)}");
        }
        [HttpPost]
        public async Task<IActionResult> FeaturetteMainAdd(FeaturetteMainViewModel model)
        {
            if (ModelState.IsValid)
            {

                await _featuretteMain.AddAsync(new FeaturetteMain()
                {
                    Title = model.Title,
                    Description = model.Description,
                    ImageUrl = await _featuretteMain.ImageCreate(model.ImageUrlFile, "FeaturetteMain"),
                });
            }
            return RedirectToAction(nameof(HomeController.Main));
        }
        public async Task<IActionResult> FeaturetteMainDelete(int id)
        {
            FeaturetteMain containerMarketing = await _featuretteMain.GetByIdAsync(id);

            _featuretteMain.ImageDelete(containerMarketing.ImageUrl);

            _featuretteMain.Delete(containerMarketing);

            return RedirectToAction(nameof(HomeController.Main));
        }
        public async Task<IActionResult> FeaturetteMainEdit(int id)
        {
            FeaturetteMain featurette = await _featuretteMain.GetByIdAsync(id);
            return View($"Featurette/{nameof(HomeController.FeaturetteMainEdit)}", new FeaturetteMainViewModel()
            {
                Title = featurette.Title,
                Description = featurette.Description,
                ImageUrl = featurette.ImageUrl,
                FeaturetteMainId = id
            });
        }
        [HttpPost]
        public async Task<IActionResult> FeaturetteMainEdit(FeaturetteMainViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageUrlFile != null)
                {
                    _featuretteMain.ImageDelete(model.ImageUrl);
                    _featuretteMain.Update(new FeaturetteMain()
                    {
                        Title = model.Title,
                        FeaturetteMainId = model.FeaturetteMainId,
                        Description = model.Description,
                        ImageUrl = await _featuretteMain.ImageCreate(model.ImageUrlFile, "FeaturetteMain"),
                    });
                }
                else
                {
                    _featuretteMain.Update(new FeaturetteMain()
                    {
                        FeaturetteMainId = model.FeaturetteMainId,
                        Title = model.Title,
                        Description = model.Description,
                        ImageUrl = model.ImageUrl,
                    });
                }
                return RedirectToAction(nameof(HomeController.Main));
            }
            else
            {
                return View(model);
            }
        }
        #endregion

        #region SocialMedia
        public IActionResult SocialMediaAdd()
        {
            return View($"SocialMedia/{nameof(HomeController.SocialMediaAdd)}");
        }
        [HttpPost]
        public async Task<IActionResult> SocialMediaAdd(SocialMediaViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _socialMedia.AddAsync(new SocialMedia()
                {
                    Title = model.Title,
                    ImageUrl = await _socialMedia.ImageCreate(model.ImageUrlFile, "SocialMedia"),
                    Link = model.Link,
                });
            }
            return RedirectToAction(nameof(HomeController.Main));
        }
        public async Task<IActionResult> SocialMediaDelete(int id)
        {
            SocialMedia socialMedia = await _socialMedia.GetByIdAsync(id);

            _socialMedia.ImageDelete(socialMedia.ImageUrl);

            _socialMedia.Delete(socialMedia);
            return RedirectToAction(nameof(HomeController.Main));
        }
        public async Task<IActionResult> SocialMediaEdit(int id)
        {
            SocialMedia socialMedia = await _socialMedia.GetByIdAsync(id);
            return View($"SocialMedia/{nameof(HomeController.SocialMediaEdit)}", new SocialMediaViewModel()
            {
                Title = socialMedia.Title,
                ImageUrl = socialMedia.ImageUrl,
                SocialMediaId = id,
                Link = socialMedia.Link,
            });
        }
        [HttpPost]
        public async Task<IActionResult> SocialMediaEdit(SocialMediaViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageUrlFile != null)
                {
                    _socialMedia.ImageDelete(model.ImageUrl);

                    _socialMedia.Update(new SocialMedia()
                    {
                        Title = model.Title,
                        SocialMediaId = model.SocialMediaId,
                        Link = model.Link,
                        ImageUrl = await _socialMedia.ImageCreate(model.ImageUrlFile, "SocialMedia"),
                    });
                }
                else
                {
                    _socialMedia.Update(new SocialMedia()
                    {
                        SocialMediaId = model.SocialMediaId,
                        Title = model.Title,
                        Link = model.Link,
                        ImageUrl = model.ImageUrl,
                    });
                }
                return RedirectToAction(nameof(HomeController.Main));
            }
            else
            {
                return View(model);
            }
        }
        #endregion
    }
}
