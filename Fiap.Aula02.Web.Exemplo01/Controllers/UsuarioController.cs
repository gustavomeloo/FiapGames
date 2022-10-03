using Fiap.Aula02.Web.Exemplo01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula02.Web.Exemplo01.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {

            TempData["nome"] = usuario.Nome;
            TempData["data"] = usuario.Data.ToShortDateString();
            TempData["email"] = usuario.Email;

            return RedirectToAction("Cadastrar");
        }




    }
}
