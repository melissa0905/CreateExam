using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;
using CreateExam.Models;
using BusinessLogicLayer;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace CreateExam.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            UserViewModel model = new UserViewModel();
            return View(model);
        }

        public IActionResult Login(User user)
        {
            var model = new UserViewModel()
            {
                user = UserBusiness.GetUser(user.userName, user.userPassword)
            };
            if (model.user != null)
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, "Giris" )
                    };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();

                HttpContext.Session.SetInt32("userId", model.user.userId);
                return RedirectToAction("Index", "Home");
            }
            return View("Error");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
