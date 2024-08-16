using HalisElektronik.Models;
using HalisElektronik.Repositories;
using HalisElektronik.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HalisElektronik.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IdentityDb _identityDb;
        public AdminController(SignInManager<ApplicationUser> signInResult, UserManager<ApplicationUser> userManager, IdentityDb identityDb)
        {
            _signInManager = signInResult;
            _userManager = userManager;
            _identityDb = identityDb;
        }
        [Route("[controller]/GirişYap")]
        public IActionResult LogIn()
        {
            return View();
        }
        [Route("[controller]/GirişYap")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInView model)
        {
            var signIn = await _userManager.FindByEmailAsync(model.Email);
            if (ModelState.IsValid)
            {
                if (signIn == null)
                {
                    ModelState.AddModelError("", "Hatalı Girdiniz!");
                    return View(model);
                }
                else
                {
                    await _signInManager.PasswordSignInAsync(signIn, model.Password, model.MemberMe, false);
                    return RedirectToAction("Index","Home");
                }
            }
            return View(model);
        }
    }
}
