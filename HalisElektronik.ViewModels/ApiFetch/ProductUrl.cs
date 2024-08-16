using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.ViewModels.ApiFetch
{
    public class ProductUrl
    {
        public string ProductsList { get; } = "Products/ProductsList";
        public string ProductCreate { get; } = "Products/ProductCreate";
        public string ProductGet { get; } = "Products/ProductGet";
        public string ProductEdit { get; } = "Products/ProductEdit";
        public string ProductDelete { get; } = "Products/ProductDelete";

        public string ProductImageGet { get; } = "Products/ProductImageGet";
        public string ProductImageGetList { get; } = "Products/ProductImageGetList";
        public string ProductImageDelete { get; } = "Products/ProductImageDelete";
        public string ProductImageCreateByModel { get; } = "Products/ProductImageCreateByModel";
        public string ProductsGetList { get; } = "Products/ProductsGetList";
        public string ProductImageUpdate { get; } = "Products/ProductImageUpdate";
        public string ProductImageUpdateDelete { get; } = "Products/ProductImageUpdateDelete";
    }
}
