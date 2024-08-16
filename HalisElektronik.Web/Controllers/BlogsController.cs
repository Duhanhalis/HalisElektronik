using HalisElektronik.Models;
using HalisElektronik.Repositories;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;

namespace HalisElektronik.Web.Controllers
{
    public class BlogsController : Controller
    {
        private readonly ApiIRepository<Blog> _repository;
        private readonly BlogUrl _blogUrl;
        public BlogsController(ApiIRepository<Blog> repository, BlogUrl blogUrl)
        {
            _repository = repository;
            _blogUrl = blogUrl;
        }

        [HttpGet("[controller]/Bloglar")]
        public async Task<IActionResult> Index(int page = 1, string? searchQuery = null, int? blogQuery = null)
        {
            int pageSize = 20;
            var values = await _repository.GetAllItemsAsync(_blogUrl.BlogList);

            if (blogQuery == null && String.IsNullOrEmpty(searchQuery))
            {
                return View(values.Skip((page - 1) * pageSize).Take(pageSize).ToList());
            }
            // SearchQuery Null Ise
            else if (String.IsNullOrEmpty(searchQuery) && blogQuery != null)
            {
                return View(values.Where(x => x.BlogsTagId == blogQuery).Skip((page - 1) * pageSize).Take(pageSize).ToList());
            }
            // Category Null Ise
            else if (searchQuery != null && blogQuery == null)
            {
                return View(values.Where(
                x => x.BlogTitle.ToLower().Contains(searchQuery.ToLower()) ||
                x.BlogAltTitle.ToLower().Contains(searchQuery.ToLower()) ||
                x.BlogId.ToString().ToLower().Contains(searchQuery.ToLower()) ||
                x.BlogDescription.ToLower().Contains(searchQuery.ToLower())).Skip((page - 1) * pageSize).Take(pageSize).ToList());
            }
            else
            {
                return View(values.Where(
               x => x.BlogTitle.ToLower().Contains(searchQuery.ToLower()) ||
               x.BlogAltTitle.ToLower().Contains(searchQuery.ToLower()) ||
               x.BlogId.ToString().ToLower().Contains(searchQuery.ToLower()) ||
               x.BlogDescription.ToLower().Contains(searchQuery.ToLower()) && x.BlogsTagId == blogQuery).Skip((page - 1) * pageSize).Take(pageSize).ToList());
            }

        }

        [HttpGet("[controller]/Bloglar/{id?}")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _repository.GetItemByIdAsync(_blogUrl.BlogGetAsync, id);
            if (model == null) { return View(NotFound()); }
            else
            {
                return View(model);
            }
        }
    }
}
