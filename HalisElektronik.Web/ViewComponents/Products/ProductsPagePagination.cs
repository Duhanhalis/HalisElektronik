using HalisElektronik.Models;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HalisElektronik.Web.ViewComponents
{

    public class ProductsPagePagination : ViewComponent
    {
       private readonly ApiIRepository<Product> _repository;
        private readonly ProductUrl _productUrl;
        public ProductsPagePagination(ApiIRepository<Product> repository, ProductUrl productUrl)
        {
            _repository = repository;
            _productUrl = productUrl;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _repository.GetAllItemsAsync(_productUrl.ProductsList);
            return View(model.ToList().Count);
        }
    }
}
