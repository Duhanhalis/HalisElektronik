using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HalisElektronik.Web.ViewComponents
{
    public class MainPageCarousel : ViewComponent
    {
        private readonly ApiIRepository<CarouselMain> _repository;
        private readonly HomeUrl _homeUrl;
        public MainPageCarousel(ApiIRepository<CarouselMain> repository, HomeUrl homeUrl)
        {
            _repository = repository;
            _homeUrl = homeUrl;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _repository.GetAllItemsAsync(_homeUrl.CarouselMainList);
            return View(model.ToList());
        }
    }
}
