using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;

namespace HalisElektronik.Web.Areas.Admin.ViewComponents
{
    public class CarouselComponent : ViewComponent
    {
        private readonly ApiIRepository<CarouselMain> _context;
        private readonly HomeUrl _url;
        public CarouselComponent(ApiIRepository<CarouselMain> context, HomeUrl url)
        {
            _context = context;
            _url = url;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.GetAllItemsAsync(_url.CarouselMainList));
        }
    }
}
