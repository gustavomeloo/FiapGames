using Fiap.Aula03.Web.Exemplo.Models;
using Fiap.Aula03.Web.Exemplo.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private FiapGamesContext _context; 

        public HomeController(ILogger<HomeController> logger, FiapGamesContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["jogos"] = _context.Jogos.Count(); // retorna a quantidade de jogadores cadastrados
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
