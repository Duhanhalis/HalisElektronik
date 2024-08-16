using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;

namespace HalisElektronik.Web.Areas.Admin.ViewComponents
{
    public class InfoPageSocialMedia:ViewComponent
    {
        private readonly ApiIRepository<SocialMedia> _context;
        private readonly HomeUrl _homeUrl;

        public InfoPageSocialMedia(HomeUrl homeUrl, ApiIRepository<SocialMedia> context)
        {
            _homeUrl = homeUrl;
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.GetAllItemsAsync(_homeUrl.SocialMediaList));
        }
    }
}
