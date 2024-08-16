using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HalisElektronik.Web.ViewComponents
{
    public class InfoPageSocialMedia:ViewComponent
    {
        private readonly ApiIRepository<SocialMedia> _repository;
        private readonly InfoUrl _infoUrl;
        public InfoPageSocialMedia(ApiIRepository<SocialMedia> repository, InfoUrl infoUrl)
        {
            _repository = repository;
            _infoUrl = infoUrl;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            var model = await _repository.GetAllItemsAsync(_infoUrl.InfoList);
            return View(model.ToList());
        }
    }
}
