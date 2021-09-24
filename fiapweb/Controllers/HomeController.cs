using fiapweb.core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace fiapweb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Nome"] = "Chuck";
            ViewBag.Sobrenome = "Noris";
            ViewBag.Comentario = "<script> alert('eh nois') </script>";

            //acesso ao DB
            var pessoa = new Pessoa() { Nome = "Maguila" };


            //return View("ViewQueNaoExiste");
            return View(pessoa);
        }

        public IActionResult Sobre()
        {
            return View();
        }


        public IActionResult Redirecionamento(string url)
        {
            return LocalRedirect(url);

            //if (Url.IsLocalUrl(url))
            //{
            //    return Redirect(url);

            //}
            //else
            //{
            //    return Redirect("/");
            //}
        }

    }
}
