using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;

namespace HalisElektronik.Web.Areas.Admin.ViewComponents
{
    public class ContainerMarketingComponent : ViewComponent
    {
        private readonly ApiIRepository<ContainerMarketing> _context;
        private readonly HomeUrl _url;

        public ContainerMarketingComponent(HomeUrl url, ApiIRepository<ContainerMarketing> context)
        {
            _url = url;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.GetAllItemsAsync(_url.ContainerMarketingList));
        }
    }
}
