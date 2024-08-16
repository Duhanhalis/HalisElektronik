using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        [
            MaxLength(50, ErrorMessage = "Maksimum 50 karekter."),
            MinLength(3, ErrorMessage = "Minumum 3 Karakter."),
            Display(Name = "Kategori İsmi :")
            ]
        public string CategoryName { get; set; } = string.Empty!;
        [MaxLength(200, ErrorMessage = "Maksimum 200 karekter."), Display(Name = "Kategori Açıklaması :")]
        public string? CategoryDescription { get; set; }
        public List<ProductViewModel>? Products { get; set; } = new List<ProductViewModel>();
    }
}
