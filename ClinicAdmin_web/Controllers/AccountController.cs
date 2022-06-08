using AspNetCoreHero.ToastNotification.Abstractions;
using ClinicAdmin_web.Extensions;
using ClinicAdmin_web.Models;
using ClinicAdmin_web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClinicAdmin_web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ClinicAdminWebContext _context;
        public INotyfService _notyfService { get; }

        public AccountController(ClinicAdminWebContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (userId != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.AsNoTracking().SingleOrDefault(x => x.Username == model.Username);

                string hashPass = HashMD5.ToMD5(model.Password);
                if(user == null || user.Password != hashPass)
                {
                    _notyfService.Error("Thông tin đăng nhập chưa chính xác");
                    return View();
                }

                //Luu session ma user
                HttpContext.Session.SetString("UserId", user.Id.ToString());

                //Identity
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Username));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.FullName));
                identity.AddClaim(new Claim("UserId", user.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Role, "User"));

                var principal = new ClaimsPrincipal(identity);
                HttpContext.User = principal;

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal), authProperties);

                _notyfService.Success("Đăng nhập thành công.");
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
