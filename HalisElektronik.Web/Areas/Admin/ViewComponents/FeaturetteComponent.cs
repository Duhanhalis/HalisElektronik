using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;

namespace HalisElektronik.Web.Areas.Admin.ViewComponents
{
    public class FeaturetteComponent : ViewComponent
    {
        private readonly ApiIRepository<FeaturetteMain> _context;
        private readonly HomeUrl _url;
        public FeaturetteComponent(ApiIRepository<FeaturetteMain> context, HomeUrl url)
        {
            _context = context;
            _url = url;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.GetAllItemsAsync(_url.FeaturetteMainList));
        }
    }
}
