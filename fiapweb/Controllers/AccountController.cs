using fiapweb.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace fiapweb.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                foreach (var role in User.Claims.ToList().Where(a=>a.Type == ClaimTypes.Role ))
                {
                    var a = role;
                }

                return RedirectToAction("Create", "Pais");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            //service
            if (model.UserName == "Fernando" && model.Password == "123Mudar")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, model.UserName));
                claims.Add(new Claim(ClaimTypes.Role, "admins"));
                claims.Add(new Claim(ClaimTypes.Role, "teste"));
                var id = new ClaimsIdentity(claims, "password");
                var principal = new ClaimsPrincipal(id);
                await HttpContext.SignInAsync("app", principal, new AuthenticationProperties() { IsPersistent = model.IsPersistent });

                return RedirectToAction("Create", "Pais");
            }

            return View();
        }


        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
