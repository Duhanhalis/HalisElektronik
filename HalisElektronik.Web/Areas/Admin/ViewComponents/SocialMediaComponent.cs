using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;

namespace HalisElektronik.Web.Areas.Admin.ViewComponents
{
    public class SocialMediaComponent : ViewComponent
    {
        private readonly ApiIRepository<SocialMedia> _context;
        private readonly HomeUrl _url;
        public SocialMediaComponent(ApiIRepository<SocialMedia> context, HomeUrl url)
        {
            _context = context;
            _url = url;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.GetAllItemsAsync(_url.SocialMediaList));
        }
    }
}
