using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HalisElektronik.Web.ViewComponents
{
    public class LayoutPageFooter : ViewComponent
    {
       private readonly ApiIRepository<SocialMedia> _repository;
        private readonly HomeUrl _homeUrl;
        public LayoutPageFooter(ApiIRepository<SocialMedia> repository, HomeUrl homeUrl)
        {
            _repository = repository;
            _homeUrl = homeUrl;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _repository.GetAllItemsAsync(_homeUrl.SocialMediaList);
            return View(model.ToList());
        }
    }
}
