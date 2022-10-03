using Fiap.Aula03.Web.Exemplo.Models;
using Fiap.Aula03.Web.Exemplo.Persistencia;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo.Controllers
{
    public class JogoController : Controller
    {
        private FiapGamesContext _context;

        //Receber o context por injeção de dependencia no construtor

        public JogoController(FiapGamesContext context)
        {
            _context = context;
        }

        //? -> permite atribuir null
        public IActionResult Index(string nomeBusca, Plataforma? plataforma)
        {
            return View(_context.Jogos.Where(j =>
                (j.Nome.Contains(nomeBusca) || nomeBusca == null) && 
                (j.Plataforma == plataforma || plataforma == null)).ToList());
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Jogo jogo)
        {
            _context.Jogos.Add(jogo);
            _context.SaveChanges();
            TempData["Cadastrado"] = "Jogo Cadastrado!!";
            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var jogo = _context.Jogos.Find(id);
            return View(jogo);
        }

        [HttpPost]
        public IActionResult Editar(Jogo jogo)
        {
            _context.Jogos.Update(jogo);
            _context.SaveChanges();
            TempData["Alterado"] = "Jogo Alterado!!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            var jogo = _context.Jogos.Find(id);
            _context.Jogos.Remove(jogo);
            _context.SaveChanges();
            TempData["Removido"] = "Jogo Removido!!";
            return RedirectToAction("Index");
        }





    }
}
