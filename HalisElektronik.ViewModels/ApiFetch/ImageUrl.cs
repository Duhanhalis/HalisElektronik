using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.ViewModels.ApiFetch
{
    public class ImageUrl
    {
        public string ImageList { get; } = "Image/ImageList";
        /// <summary>
        /// Image id göre çağrılır.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string ImageGetById { get; } = "Image/ImageGetById";
        /// <summary>
        /// Sadece Class oluşturmak için kullanılır.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string ImageCreateByModel { get; } = "Image/ImageCreateByModel";
        public string ImageGetListById { get; } = "Image/ImageGetListById";
        /// <summary>
        /// Hem image hemde class siliyorsun.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string ImageDelete { get; } = "Image/ImageDelete";
        /// <summary>
        /// Razor page de kullanılmak üzere geliştirildi.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetImageByName { get; } = "Image/GetImageByName";
        /// <summary>
        /// Class update etmek için kullanılır.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string ImageUpdate { get; } = "Image/ImageUpdate";
        /// <summary>
        /// İmage class a bir şey yapmıyorsun sadece class tan url çekip dosyayı siliyorsun.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string ImageUpdateDelete { get; } = "Image/ImageUpdateDelete";
        public string PhotoCreate { get; } = "Image/PhotoCreate";
    }
}
