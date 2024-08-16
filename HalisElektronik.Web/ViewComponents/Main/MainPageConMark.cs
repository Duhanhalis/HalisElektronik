using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HalisElektronik.Web.ViewComponents
{
    public class MainPageConMark : ViewComponent
    {
        private readonly ApiIRepository<ContainerMarketing> _repository;
        private readonly HomeUrl _homeUrl;
        public MainPageConMark(ApiIRepository<ContainerMarketing> repository, HomeUrl homeUrl)
        {
            _repository = repository;
            _homeUrl = homeUrl;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _repository.GetAllItemsAsync(_homeUrl.ContainerMarketingList);
            return View(model.ToList());
        }
    }
}
