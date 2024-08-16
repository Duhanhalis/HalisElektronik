using HalisElektronik.Models;
using HalisElektronik.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Utilities
{
    public class DbInitializer : IDbInitializer
    {
        private UserManager<IdentityUser<int>> _userManager;
        private RoleManager<IdentityRole<int>> _roleManager;
        private ApplicationDbContext _context;

        public DbInitializer(ApplicationDbContext context, RoleManager<IdentityRole<int>> roleManager, UserManager<IdentityUser<int>> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task InitializeAsync()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {

                throw;
            }
            //if (!_roleManager.RoleExistsAsync(WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult())
            //{
            //    await _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Admin)).GetAwaiter().GetResult();
            //    await _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Customer)).GetAwaiter().GetResult();
            //    await _userManager.CreateAsync(new IdentityUser
            //    {
            //        UserName = "DH",
            //        Email = "duhanhalis1@outlook.com",
            //    }, "duhanhalis1@outlook.com").GetAwaiter().GetResult();
            //    var AppUser = _context.ApplicationUsers.FirstOrDefault(x => x.Email == "duhanhalis1@outlook.com");
            //    if (AppUser != null)
            //    {
            //        await _userManager.AddToRoleAsync(AppUser, WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult();
            //    }
            //}
            //if (!await _roleManager.RoleExistsAsync(WebSiteRoles.WebSite_Admin))
            //{
            //    await _roleManager.CreateAsync(new IdentityRole<int> { Name = WebSiteRoles.WebSite_Admin });
            //    await _roleManager.CreateAsync(new IdentityRole<int> { Name = WebSiteRoles.WebSite_Customer });

            //    var user = new ApplicationUser
            //    {
            //        UserName = "DH",
            //        Email = "duhanhalis1@outlook.com",
            //    };

            //    var result = await _userManager.CreateAsync(user, "duhanhalis1@outlook.com");
            //    if (result.Succeeded)
            //    {
            //        var appUser = await _userManager.FindByEmailAsync("duhanhalis1@outlook.com");
            //        if (appUser != null)
            //        {
            //            await _userManager.AddToRoleAsync(appUser, WebSiteRoles.WebSite_Admin);
            //        }
            //    }
            //}
        }

        void IDbInitializer.InitializeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
