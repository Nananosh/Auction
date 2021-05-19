using System;
using System.Collections.Generic;
using Auction.DataBaseConnection;
using Auction.DataBaseConnection.Factory;
using Auction.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Auction.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public void Register(Account account)
        {
            if (ModelState.IsValid)
            {
                Factory.InsertProfile(account);
            }
        }
        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(Account account, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var listUser = Factory.GetProfileInformation(DatabaseConnection.GetProfileInformation());
            Account user = null;
            foreach (var u in listUser)
            {
                if (u.Nickname == account.Nickname && u.Password == account.Password)
                {
                    user = u;
                }
            }
            if (user != null)
            {
                var claims = new List<Claim>();
                // claims.Add(new Claim("Nickname",user.Nickname));
                // claims.Add(new Claim(ClaimTypes.Name,account.Nickname));
                claims.Add(new Claim("Id",user.Id.ToString()));
                // claims.Add(new Claim(ClaimTypes.NameIdentifier,account.Id.ToString()));
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                Console.WriteLine($"{user.Id},{user.Nickname}");
                return Redirect(returnUrl);
            }
            TempData["Error"] = "Ошибка в Nickname или Password";
            return View("login");
        }
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
        
    }
}