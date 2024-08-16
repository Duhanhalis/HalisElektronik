using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HalisElektronik.Web.ViewComponents
{
    public class MainPageFeaturette:ViewComponent
    {
        private readonly ApiIRepository<FeaturetteMain> _repository;
        private readonly HomeUrl _homeUrl;
        public MainPageFeaturette(ApiIRepository<FeaturetteMain> repository, HomeUrl homeUrl)
        {
            _repository = repository;
            _homeUrl = homeUrl;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _repository.GetAllItemsAsync(_homeUrl.FeaturetteMainList);
            return View(model.ToList());
        }
    }
}
