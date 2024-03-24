using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace HalisElektronik.ViewModels
{
    public class CarouselViewModel
    {
        [Key]
        public int CarouselMainId { get; set; }
        public string? ImageUrl { get; set; }

        [Display(AutoGenerateField = true, AutoGenerateFilter = true, Name = "Carousel(Slider) Fotoğraf :", Prompt = "1908*1080px Olmasına Özen Gösterin !")]
        public IFormFile? ImageUrlFile { get; set; }

        [Display(AutoGenerateField = true,
            AutoGenerateFilter = true, 
            Name = "Başlık :", 
            Prompt = "3 ila 20 Karakter Olmalı")
            ,MaxLength(20, ErrorMessage = "En Fazla 20 Karakter Olmalı"), 
            MinLength(3, ErrorMessage = "En az 3 Karakter Olmalı")]
        public string? Title { get; set; }

        [Display(AutoGenerateField = true,
            AutoGenerateFilter = true,
            Name = "Açıklama :",
            Prompt = "3 ila 50 Karakter Olmalı")
            , MaxLength(50, ErrorMessage = "En Fazla 50 Karakter Olmalı"),
            MinLength(3, ErrorMessage = "En az 3 Karakter Olmalı")]
        public string? Description { get; set; }

        [Display(AutoGenerateField = true,
            AutoGenerateFilter = true,
            Name = "Button İsmi :",
            Prompt = "Basit Tut !")]
        public string? BtnTitle { get; set; }
        [Display(Name = "Button Url :")]
        public string? BtnUrl { get; set; }
    }
}
