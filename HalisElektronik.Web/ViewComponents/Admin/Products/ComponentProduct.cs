using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;

namespace HalisElektronik.Web.ViewComponents
{
    public class ComponentProduct : ViewComponent
    {
        private readonly ApiIRepository<Product> _repository;
        private readonly ProductUrl _productUrl;
        public ComponentProduct(ApiIRepository<Product> repository, ProductUrl productUrl)
        {
            _repository = repository;
            _productUrl = productUrl;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _repository.GetAllItemsAsync(_productUrl.ProductsList));
        }
    }
}
