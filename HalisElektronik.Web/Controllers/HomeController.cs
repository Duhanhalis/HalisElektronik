using HalisElektronik.Models;
using HalisElektronik.Repositories;
using HalisElektronik.Repositories.Implementation;
using HalisElektronik.Repositories.Interfaces;
using HalisElektronik.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HalisElektronik.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IGenericRepository<Main> _mainRepository;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IGenericRepository<Category> categoryRepository, IGenericRepository<Main> mainRepository, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _mainRepository = mainRepository;
            _context = applicationDbContext;
        }

        public async Task<IActionResult> Index()
        {
            MainViewModel mainViewModel = new MainViewModel()
            {
                carouselMains = await _context.CarouselMains.ToListAsync(),
                containerMarketings = await _context.ContainerMarketings.ToListAsync(),
                featuretteMains = await _context.FeaturetteMains.ToListAsync(),
                socialMedias = await _context.SocialMedia.ToListAsync(),
            };
            _mainRepository.GetAll();
            ViewData["Footer"] = _context.SocialMedia.ToList();
            ViewData["Category"] = _categoryRepository.GetAll();
            Console.WriteLine("Deneme");
            return View(mainViewModel);
        }

        public IActionResult AboutUs()
        {
            
            ViewData["Footer"] = _context.SocialMedia.ToList();
            ViewData["Category"] = _categoryRepository.GetAll();
            return View();
        }
    }
}
