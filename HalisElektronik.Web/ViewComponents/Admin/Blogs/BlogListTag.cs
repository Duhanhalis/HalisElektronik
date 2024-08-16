using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace HalisElektronik.Web.ViewComponents.Admin.Blogs
{
    public class BlogListTag : ViewComponent
    {
        private readonly ApiIRepository<BlogsTag> _context;
        private readonly BlogTagUrl _blogTagUrl;
        public BlogListTag(ApiIRepository<BlogsTag> context, BlogTagUrl blogTagUrl)
        {
            _context = context;
            this._blogTagUrl = blogTagUrl;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            if (id != 0)
            {
                BlogsTag blogtag = await _context.GetItemByIdAsync(_blogTagUrl.BlogTagGet,id);
                if (blogtag != null)
                {
                    return View(blogtag);
                }
            }

            return View();
        }
    }
}
