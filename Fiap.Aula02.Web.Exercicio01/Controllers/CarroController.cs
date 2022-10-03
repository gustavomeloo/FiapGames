using Fiap.Aula02.Web.Exercicio01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula02.Web.Exercicio01.Controllers
{
    public class CarroController : Controller
    {

        public static List<Carro> _carro = new List<Carro>();
        private static int _id;

        public IActionResult Index()
        {
            return View(_carro);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarMarcas();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Carro carro)
        {
            carro.Id = ++_id;
            _carro.Add(carro);
            TempData["cadastrado"] = "Carro Cadastrado!!";
            return RedirectToAction("Cadastrar");

        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarMarcas();
            var carro = _carro.Find(c => c.Id == id);
            return View(carro);
        }

        [HttpPost]
        public IActionResult Editar (Carro carro)
        {
            CarregarMarcas();
            _carro[_carro.FindIndex(c => c.Id == carro.Id)] = carro;
            TempData["Alterado"] = "Carro Alterado!!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            _carro.Remove(_carro.Find(c => c.Id == id));
            TempData["removido"] = "Removido com sucesso";
            return RedirectToAction("Index");
        }

        private void CarregarMarcas()
        {
            var carros = new List<string>(new string[] { "Fiat", "Chevrolet", "Hyundai", "Ferrari", "BMW", "Mercedes" });
            ViewBag.marcas = new SelectList(carros);
        }
    }
}
