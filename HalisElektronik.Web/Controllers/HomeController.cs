using HalisElektronik.Models;
using HalisElektronik.Repositories;
using HalisElektronik.Repositories.Implementation;
using HalisElektronik.ViewModels;
using HalisElektronik.ViewModels.ApiFetch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;

namespace HalisElektronik.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiIRepository<Info> _repository;
        private readonly InfoUrl _infoUrl;
        public HomeController(ApiIRepository<Info> repository, InfoUrl homeUrl)
        {
            _repository = repository;
            _infoUrl = homeUrl;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Info()
        {

            return View(await _repository.GetAllItemsAsync(_infoUrl.InfoList));
        }
    }

}