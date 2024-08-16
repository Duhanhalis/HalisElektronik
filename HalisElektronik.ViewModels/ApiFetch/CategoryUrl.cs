using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.ViewModels.ApiFetch
{
    public class CategoryUrl
    {
        public string CategoryList { get; } = "Category/CategoryList";
        public string CategoryGet { get; } = "Category/CategoryGet";
        public string CategoryEdit { get; } = "Category/CategoryEdit";
        public string CategoryCreate { get; } = "Category/CategoryCreate";
        public string CategoryDelete { get; } = "Category/CategoryDelete";

    }
}
