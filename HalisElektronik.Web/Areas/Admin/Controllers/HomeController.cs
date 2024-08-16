using HalisElektronik.Models;
using HalisElektronik.Repositories;
using HalisElektronik.Repositories.Implementation;
using HalisElektronik.Repositories.Implementation.Mvc.Inteface;
using HalisElektronik.ViewModels;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace HalisElektronik.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {

        private readonly ApiIRepository<CarouselMain> _carousel;
        private readonly ApiIRepository<ContainerMarketing> _container;
        private readonly ApiIRepository<Info> _info;
        private readonly ImageApiInterface<Image> _image;
        private readonly ApiIRepository<FeaturetteMain> _featurette;
        private readonly ApiIRepository<SocialMedia> _socialMedia;
        private readonly HomeUrl _homeUrl;
        private readonly InfoUrl _infoUrl;
        private readonly ImageUrl _imageUrl;
        public HomeController(ApiIRepository<CarouselMain> carousel, HomeUrl homeUrl, ApiIRepository<Info> info, InfoUrl infoUrl, ImageApiInterface<Image> image, ImageUrl imageUrl, ApiIRepository<ContainerMarketing> container, ApiIRepository<FeaturetteMain> featurette, ApiIRepository<SocialMedia> socialMedia)
        {
            _carousel = carousel;
            _homeUrl = homeUrl;
            _info = info;
            _infoUrl = infoUrl;
            _image = image;
            _imageUrl = imageUrl;
            _container = container;
            _featurette = featurette;
            _socialMedia = socialMedia;
        }

        public IActionResult Index()
        {

            return View();
        }

        #region Info
        public async Task<IActionResult> Info()
        {
            return View(await _info.GetAllItemsAsync(_infoUrl.InfoList));
        }

        [HttpGet]
        public IActionResult InfoCreate()
        {
            return View($"Info/{nameof(HomeController.InfoCreate)}");
        }
        [HttpPost]
        public async Task<IActionResult> InfoCreate(Info model)
        {
            if (ModelState.IsValid)
            {
                await _info.AddItemAsync(_infoUrl.InfoCreate, model);
                return RedirectToAction(nameof(HomeController.Info));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> InfoEdit(int id)
        {
            var model = await _info.GetItemByIdAsync(_infoUrl.InfoGet, id);
            return View($"Info/{nameof(HomeController.InfoEdit)}", model);
        }
        [HttpPost]
        public async Task<IActionResult> InfoEdit(Info model)
        {
            if (ModelState.IsValid)
            {
                await _info.UpdateItemAsync(_infoUrl.InfoEdit, model);
                return RedirectToAction(nameof(HomeController.Info));
            }
            return View();
        }
        #endregion

        #region Carousel
        public IActionResult CarouselAdd()
        {
            return View($"Carousel/{nameof(HomeController.CarouselAdd)}");
        }

        [HttpPost]
        public async Task<IActionResult> CarouselAdd(CarouselViewModel model)
        {
            if (model.Image.ImageFile == null)
            {
                return View($"Carousel/{nameof(HomeController.CarouselAdd)}", model);
            }
            await _carousel.AddItemAsync(_homeUrl.CarouselMainCreate, new CarouselMain()
            {
                Title = model.Title,
                Description = model.Description,
                BtnTitle = model.BtnTitle,
                BtnUrl = model.BtnUrl,
                Images = new Image()
                {
                    ImageUrl = await _image.AddImageAsync(_imageUrl.PhotoCreate, model.Image.ImageFile, model.Title),
                    Title = model.Image.Title,
                    EntityType = EntityType.CarouselMain,
                }
            });

            return RedirectToAction(nameof(HomeController.Index));
        }

        public async Task<IActionResult> CarouselDelete(int id)
        {
            var model = await _carousel.GetItemByIdAsync(_homeUrl.CarouselMainGet, id);
            await _image.DeleteImageAsync(_imageUrl.ImageDelete, model.ImageId);
            await _carousel.DeleteItemAsync(_homeUrl.CarouselMainDelete, id);

            return RedirectToAction(nameof(HomeController.Index));
        }

        [HttpGet]
        public async Task<IActionResult> CarouselEdit(int id)
        {
            var carousel = await _carousel.GetItemByIdAsync(_homeUrl.CarouselMainGet, id);
            return View($"Carousel/{nameof(HomeController.CarouselEdit)}", new CarouselViewModel()
            {
                Title = carousel.Title,
                Description = carousel.Description,
                BtnTitle = carousel.BtnTitle,
                BtnUrl = carousel.BtnUrl,
                CarouselMainId = id,
                ImageId = carousel.ImageId,
                Image = new ImageViewModel()
                {
                    Id = carousel.Images.Id,
                    ImageUrl = carousel.Images.ImageUrl,
                    Title = carousel.Images.Title,
                    EntityId = EntityTypeViewModel.CarouselMain,
                },
            });
        }

        [HttpPost]
        public async Task<IActionResult> CarouselEdit(CarouselViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Image.ImageFile != null)
                {
                    //Image Sil
                    await _image.DeleteImageAsync(_imageUrl.ImageUpdateDelete, model.ImageId);
                    //Image Ekle
                    await _image.AddImageClassAsync(_imageUrl.ImageUpdate, new Image()
                    {
                        ImageUrl = await _image.AddImageAsync(_imageUrl.PhotoCreate, model.Image.ImageFile, model.Title),
                        Title = model.Image.Title,
                        Id = model.Image.Id,
                        EntityType = EntityType.CarouselMain,
                    });
                    await _carousel.UpdateItemAsync(_homeUrl.CarouselMainEdit, new CarouselMain()
                    {
                        Title = model.Title,
                        BtnTitle = model.BtnTitle,
                        BtnUrl = model.BtnUrl,
                        CarouselMainId = model.CarouselMainId,
                        Description = model.Description,
                        ImageId = model.ImageId,
                    });
                }
                else
                {
                    await _carousel.UpdateItemAsync(_homeUrl.CarouselMainEdit, new CarouselMain()
                    {
                        Title = model.Title,
                        BtnTitle = model.BtnTitle,
                        BtnUrl = model.BtnUrl,
                        CarouselMainId = model.CarouselMainId,
                        Description = model.Description,
                        ImageId = model.ImageId,
                        Images = await _image.AddImageClassAsync(_imageUrl.ImageUpdate, new Image()
                        {
                            Id = model.Image.Id,
                            Title = model.Image.Title,
                            ImageUrl = model.Image.ImageUrl,
                        })
                    });
                }
                return RedirectToAction(nameof(HomeController.Index));
            }
            else
            {
                return View(nameof(HomeController.CarouselEdit), model);
            }
        }
        #endregion

        #region Container Marketing
        public IActionResult ContainerMarketingAdd()
        {
            return View($"ContainerMarketing/{nameof(HomeController.ContainerMarketingAdd)}");
        }
        [HttpPost]
        public async Task<IActionResult> ContainerMarketingAdd(CMViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _container.AddItemAsync(_homeUrl.ContainerMarketingCreate, new ContainerMarketing()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Images = new Image()
                    {
                        Title = model.Image.Title,
                        ImageUrl = await _image.AddImageAsync(_imageUrl.PhotoCreate, model.Image.ImageFile, model.Title),
                        EntityType = EntityType.ContainerMarketing,
                    }
                });
            }
            return RedirectToAction(nameof(HomeController.Index));
        }
        public async Task<IActionResult> ContainerMarketingDelete(int id)
        {
            var model = await _container.GetItemByIdAsync(_homeUrl.ContainerMarketingGet, id);
            await _image.DeleteImageAsync(_imageUrl.ImageDelete, model.ImageId);
            await _container.DeleteItemAsync(_homeUrl.ContainerMarketingDelete, id);

            return RedirectToAction(nameof(HomeController.Index));
        }
        public async Task<IActionResult> ContainerMarketingEdit(int id)
        {
            var carousel = await _container.GetItemByIdAsync(_homeUrl.ContainerMarketingGet, id);

            return View($"ContainerMarketing/{nameof(HomeController.ContainerMarketingEdit)}", new CMViewModel()
            {
                Title = carousel.Title,
                Description = carousel.Description,
                ContainerMarketingId = id,
                ImageId = carousel.ImageId,
                Image = new ImageViewModel()
                {
                    Id = carousel.Images.Id,
                    ImageUrl = carousel.Images.ImageUrl,
                    Title =carousel.Images.Title,
                    EntityId = EntityTypeViewModel.ContainerMarketing,
                }
            });
        }
        [HttpPost]  
        public async Task<IActionResult> ContainerMarketingEdit(CMViewModel model)
        {
            if (ModelState.IsValid)
            {
                var container = await _container.GetItemByIdAsync(_homeUrl.ContainerMarketingGet, model.ContainerMarketingId);
                if (model.Image.ImageFile != null)
                {
                    // Image Delete
                    await _image.DeleteImageAsync(_imageUrl.ImageUpdateDelete, model.ImageId);
                    // Image Create
                    await _image.AddImageClassAsync(_imageUrl.ImageUpdate, new Image()
                    {
                        Id = model.Image.Id,
                        ImageUrl = await _image.AddImageAsync(_imageUrl.PhotoCreate, model.Image.ImageFile, model.Title),
                        Title = model.Image.Title,
                        EntityType = EntityType.ContainerMarketing
                    });
                    await _container.UpdateItemAsync(_homeUrl.ContainerMarketingEdit, new ContainerMarketing()
                    {
                        Title = model.Title,
                        Description = model.Description,
                        ContainerMarketingId = model.ContainerMarketingId,
                        ImageId = model.ImageId,
                    });
                }
                else
                {
                    await _image.AddImageClassAsync(_imageUrl.ImageUpdate, new Image()
                    {
                        Title = model.Image.Title,
                        Id = model.Image.Id,
                        ImageUrl = model.Image.ImageUrl,
                        EntityType = EntityType.ContainerMarketing
                    });
                    await _container.UpdateItemAsync(_homeUrl.ContainerMarketingEdit, new ContainerMarketing()
                    {
                        Title = model.Title,
                        Description = model.Description,
                        ContainerMarketingId = model.ContainerMarketingId,
                        ImageId = model.ImageId
                    });
                }
                return RedirectToAction(nameof(HomeController.Index));
            }
            else
            {
                return View(model);
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
                await _featurette.AddItemAsync(_homeUrl.FeaturetteMainCreate, new FeaturetteMain()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Images = new Image()
                    {
                        ImageUrl = await _image.AddImageAsync(_imageUrl.PhotoCreate, model.Image.ImageFile, model.Title),
                        Title = model.Image.Title,
                        EntityType = EntityType.FeaturetteMain,
                    }
                });

            }
            return RedirectToAction(nameof(HomeController.Index));
        }
        public async Task<IActionResult> FeaturetteMainDelete(int id)
        {
            var model = await _featurette.GetItemByIdAsync(_homeUrl.FeaturetteMainGet, id);
            await _image.DeleteImageAsync(_imageUrl.ImageDelete, model.ImageId);
            await _featurette.DeleteItemAsync(_homeUrl.FeaturetteMainDelete, id);

            return RedirectToAction(nameof(HomeController.Index));
        }
        public async Task<IActionResult> FeaturetteMainEdit(int id)
        {
            var featurette = await _featurette.GetItemByIdAsync(_homeUrl.FeaturetteMainGet, id);

            return View($"Featurette/{nameof(HomeController.FeaturetteMainEdit)}", new FeaturetteMainViewModel()
            {
                Title = featurette.Title,
                Description = featurette.Description,
                FeaturetteMainId = id,
                ImageId  = featurette.ImageId,
                Image = new ImageViewModel()
                {
                    ImageUrl = featurette.Images.ImageUrl,
                    Id = featurette.Images.Id,
                    Title = featurette.Images.Title,
                    EntityId = EntityTypeViewModel.FeaturetteMain,
                }
            });
        }
        [HttpPost]
        public async Task<IActionResult> FeaturetteMainEdit(FeaturetteMainViewModel model)
        {
            if (ModelState.IsValid)
            {
                var featurette = await _featurette.GetItemByIdAsync(_homeUrl.FeaturetteMainGet, model.FeaturetteMainId);
                if (model.Image.ImageFile != null)
                {
                    await _image.DeleteImageAsync(_imageUrl.ImageUpdateDelete, model.ImageId);
                    // Image Create
                    await _image.AddImageClassAsync(_imageUrl.ImageUpdate, new Image()
                    {
                        Id = model.Image.Id,
                        ImageUrl = await _image.AddImageAsync(_imageUrl.PhotoCreate, model.Image.ImageFile, model.Title),
                        Title = model.Image.Title,
                        EntityType = EntityType.FeaturetteMain,
                    });
                    await _featurette.AddItemAsync(_homeUrl.FeaturetteMainCreate, new FeaturetteMain()
                    {
                        Title = model.Title,
                        FeaturetteMainId = model.FeaturetteMainId,
                        Description = model.Description,
                        ImageId = model.ImageId
                    });
                }
                else
                {
                    await _image.AddImageClassAsync(_imageUrl.ImageUpdate, new Image()
                    {
                        Id = model.Image.Id,
                        ImageUrl = model.Image.ImageUrl,
                        Title = model.Image.Title,
                        EntityType = EntityType.FeaturetteMain
                    });
                    await _featurette.UpdateItemAsync(_homeUrl.FeaturetteMainEdit, new FeaturetteMain()
                    {
                        Title = model.Title,
                        FeaturetteMainId = model.FeaturetteMainId,
                        Description = model.Description,
                        ImageId = model.Image.Id,
                    });
                }
                return RedirectToAction(nameof(HomeController.Index));
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
                await _socialMedia.AddItemAsync(_homeUrl.SocialMediaCreate, new SocialMedia()
                {
                    Title = model.Title,
                    Link = model.Link,
                    Images = new Image()
                    {
                        ImageUrl = await _image.AddImageAsync(_imageUrl.PhotoCreate, model.Image.ImageFile, model.Title),
                        Title = model.Image?.Title,
                        EntityType = EntityType.SocialMedia
                    }
                });
                 return RedirectToAction(nameof(HomeController.Index));
            }
            else
            {
                return View(model);
            }
           
        }
        public async Task<IActionResult> SocialMediaDelete(int id)
        {
            var model = await _socialMedia.GetItemByIdAsync(_homeUrl.SocialMediaGet, id);
            await _image.DeleteImageAsync(_imageUrl.ImageDelete, model.ImageId);
            await _socialMedia.DeleteItemAsync(_homeUrl.SocialMediaGet, id);
            return RedirectToAction(nameof(HomeController.Index));
        }
        public async Task<IActionResult> SocialMediaEdit(int id)
        {
            var socialMedia = await _socialMedia.GetItemByIdAsync(_homeUrl.SocialMediaGet, id);
            
            return View($"SocialMedia/{nameof(HomeController.SocialMediaEdit)}", new SocialMediaViewModel()
            {
                Title = socialMedia.Title,
                SocialMediaId = id,
                Link = socialMedia.Link,
                ImageId = socialMedia.ImageId,
                Image = new ImageViewModel()
                {
                    ImageUrl = socialMedia.Images.ImageUrl,
                    Title = socialMedia.Images.Title,
                    Id = socialMedia.Images.Id,
                    EntityId = EntityTypeViewModel.SocialMedia,
                }
            });
        }
        [HttpPost]
        public async Task<IActionResult> SocialMediaEdit(SocialMediaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var m = await _socialMedia.GetItemByIdAsync(_homeUrl.SocialMediaGet, model.SocialMediaId);
                if (model.Image.ImageFile != null)
                {
                    await _image.DeleteImageAsync(_imageUrl.ImageUpdateDelete, model.ImageId);
                    // Image Create
                    await _image.AddImageClassAsync(_imageUrl.ImageUpdate, new Image()
                    {
                        Id = model.Image.Id,
                        ImageUrl = await _image.AddImageAsync(_imageUrl.PhotoCreate, model.Image.ImageFile, model.Title),
                        Title = model.Image.Title,
                        EntityType = EntityType.SocialMedia,
                    });

                    await _socialMedia.UpdateItemAsync(_homeUrl.SocialMediaEdit, new SocialMedia()
                    {
                        Title = model.Title,
                        SocialMediaId = model.SocialMediaId,
                        Link = model.Link,
                        ImageId = model.ImageId,
                    });
                }
                else
                {
                    await _image.AddImageClassAsync(_imageUrl.ImageUpdate, new Image()
                    {
                        Id = m.Images.Id,
                        ImageUrl = m.Images.ImageUrl,
                        Title = m.Images.Title,
                        EntityType = EntityType.SocialMedia
                    });
                    await _socialMedia.UpdateItemAsync(_homeUrl.SocialMediaEdit, new SocialMedia()
                    {
                        Title = model.Title,
                        SocialMediaId = model.SocialMediaId,
                        Link = model.Link,
                    });
                }
                return RedirectToAction(nameof(HomeController.Index));
            }
            else
            {
                return View(model);
            }
        }
        #endregion
    }
}
