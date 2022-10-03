using Fiap.Aula03.Web.Exemplo.Models;
using Fiap.Aula03.Web.Exemplo.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo.Controllers
{
    public class ProdutoraController : Controller
    {

        private FiapGamesContext _context;


        public ProdutoraController(FiapGamesContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Cadastrar(Produtora produtora)
        {
            _context.Produtoras.Add(produtora);
            _context.SaveChanges();
            TempData["msg"] = "Produtora cadastrada com sucesso";
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View(_context.Produtoras.Include(p => p.Endereco).ToList());
        }
    }
}
