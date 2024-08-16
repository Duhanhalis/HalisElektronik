using AutoMapper;
using HalisElektronik.Models;
using HalisElektronik.Repositories;
using HalisElektronik.Repositories.Implementation.Mvc.Inteface;
using HalisElektronik.ViewModels;
using HalisElektronik.ViewModels.ApiFetch;
using HalisElektronik.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.Unicode;
namespace HalisElektronik.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BlogController : Controller
    {
        private readonly ApiIRepository<Blog> _blogRepository;
        private readonly ApiIRepository<BlogsTag> _blogTagRepository;
        private readonly ImageApiInterface<Image> _imageRepo;
        private readonly BlogUrl _blogUrl;
        private readonly BlogTagUrl _blogTagUrl;
        private readonly ImageUrl _imageUrl;
        public BlogController(ApiIRepository<Blog> blog, ApiIRepository<BlogsTag> blogtag, BlogUrl blogUrl, BlogTagUrl blogTagUrl = null, ImageUrl imageUrl = null, ImageApiInterface<Image> imageRepo = null)
        {
            _blogRepository = blog;
            _blogTagRepository = blogtag;
            _blogUrl = blogUrl;
            _blogTagUrl = blogTagUrl;
            _imageUrl = imageUrl;
            _imageRepo = imageRepo;
        }
        public async Task<IActionResult> Index()
        {

            return View(await _blogRepository.GetAllItemsAsync(_blogUrl.BlogList));
        }
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 10;

            IEnumerable<Blog> model = await _blogRepository.GetAllItemsAsync(_blogUrl.BlogList);

            return View(model.Skip((page - 1) * pageSize).Take(pageSize).ToList());
        }
        #region BlogsTag

        [HttpGet]
        public IActionResult TagCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TagCreateAsync(BlogsTagViewModel model)
        {
            if (ModelState.IsValid)
            {

                await _blogTagRepository.AddItemAsync(_blogTagUrl.BlogTagCreate, new BlogsTag()
                {
                    BlogsTagName = model.BlogsTagName
                });
                return RedirectToAction(nameof(BlogController.Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TagEditAsync(int id)
        {
            if (ModelState.IsValid)
            {

                var model = await _blogTagRepository.GetItemByIdAsync(_blogTagUrl.BlogTagGet, id);
                return View(new BlogsTagViewModel()
                {
                    BlogsTagName = model.BlogsTagName,
                    BlogsTagId = model.BlogsTagId
                });
            }
            return RedirectToAction(nameof(BlogController.Index));
        }
        [HttpPost]
        public async Task<IActionResult> TagEditAsync(BlogsTagViewModel model)
        {
            if (ModelState.IsValid)
            {

                await _blogTagRepository.UpdateItemAsync(_blogTagUrl.BlogTagEdit, new BlogsTag()
                {
                    BlogsTagId = model.BlogsTagId,
                    BlogsTagName = model.BlogsTagName
                });
                return RedirectToAction(nameof(BlogController.Index));
            }
            return View();
        }
        public async Task<IActionResult> TagDelete(int id)
        {
            await _blogTagRepository.DeleteItemAsync(_blogTagUrl.BlogTagDelete, id);
            return RedirectToAction(nameof(BlogController.Index));
        }
        #endregion

        #region Blogs

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Tags = new SelectList(await _blogTagRepository.GetAllItemsAsync(_blogTagUrl.BlogTagList), "BlogsTagId", "BlogsTagName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BlogViewModel model)
        {
            if (ModelState.IsValid)
            {

                await _blogRepository.AddItemAsync(_blogUrl.BlogCreate, new Blog()
                {
                    BlogAltTitle = model.BlogAltTitle,
                    BlogTitle = model.BlogTitle,
                    BlogDescription = model.BlogDescription,
                    BlogsTagId = model.BlogsTagId,
                    Date_Time = DateTime.Now,
                    BlogImage = new Image()
                    {
                        ImageUrl = await _imageRepo.AddImageAsync(_imageUrl.PhotoCreate, model.Images.ImageFile, model.BlogTitle),
                        Title = model.Images.Title,
                        EntityType = EntityType.Blog
                    }
                });
                return RedirectToAction(nameof(BlogController.Index));
            }
            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _blogRepository.GetItemByIdAsync(_blogUrl.BlogGetAsync, id);
            //var modelImage = await _image.GetItemByIdAsync(_imageUrl.ImageGetById, model.ImageId);
            if (model != null)
            {
                ViewBag.Tags = new SelectList(await _blogTagRepository.GetAllItemsAsync(_blogTagUrl.BlogTagList), "BlogsTagId", "BlogsTagName");

                return View(new BlogViewModel()
                {
                    BlogAltTitle = model.BlogAltTitle,
                    BlogDescription = model.BlogDescription,
                    BlogsTagId = model.BlogsTagId,
                    BlogTitle = model.BlogTitle,
                    Date_Time = model.Date_Time,
                    BlogId = model.BlogId,
                    ImageId = model.ImageId,
                    Images = new ImageViewModel()
                    {
                        ImageUrl = model.BlogImage.ImageUrl,
                        Title = model.BlogImage.Title,
                        Id = model.BlogImage.Id,
                        EntityId = EntityTypeViewModel.Blog
                    },
                });
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Edit(BlogViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Images.ImageFile != null)
                {
                    await _imageRepo.DeleteImageAsync(_imageUrl.ImageUpdateDelete, model.ImageId);

                    await _blogRepository.UpdateItemAsync(_blogUrl.BlogEdit, new Blog()
                    {
                        BlogTitle = model.BlogTitle,
                        BlogAltTitle = model.BlogAltTitle,
                        BlogDescription = model.BlogDescription,
                        BlogId = model.BlogId,
                        BlogsTagId = model.BlogsTagId,
                        Date_Time = DateTime.Now,
                        ImageId = model.ImageId,
                        BlogImage = await _imageRepo.AddImageClassAsync(_imageUrl.ImageUpdate, new Image()
                        {
                            Id = model.Images.Id,
                            ImageUrl = await _imageRepo.AddImageAsync(_imageUrl.PhotoCreate, model.Images.ImageFile, model.BlogTitle),
                            Title = model.Images.Title,
                            EntityType = EntityType.Blog,
                        })
                    });
                }
                else
                {
                    await _blogRepository.UpdateItemAsync(_blogUrl.BlogEdit, new Blog()
                    {
                        BlogTitle = model.BlogTitle,
                        BlogAltTitle = model.BlogAltTitle,
                        BlogDescription = model.BlogDescription,
                        BlogId = model.BlogId,
                        BlogsTagId = model.BlogsTagId,
                        Date_Time = DateTime.Now,
                        ImageId = model.ImageId,
                        BlogImage = new Image()
                        {
                            ImageUrl = model.Images.ImageUrl,
                            Id = model.Images.Id,
                            Title = model.Images.Title,
                        }
                    });
                }
                return RedirectToAction(nameof(BlogController.Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Blog model = await _blogRepository.GetItemByIdAsync(_blogUrl.BlogGetAsync, id);

            await _imageRepo.DeleteImageAsync(_imageUrl.ImageDelete, model.ImageId);

            await _blogRepository.DeleteItemAsync(_blogUrl.BlogDelete, model.BlogId);

            return RedirectToAction(nameof(BlogController.Index));
        }
        #endregion
    }
}
