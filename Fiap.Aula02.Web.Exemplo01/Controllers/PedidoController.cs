using Fiap.Aula02.Web.Exemplo01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula02.Web.Exemplo01.Controllers
{
    public class PedidoController : Controller
    {

        public static List<Pedido> _banco = new List<Pedido>();
        private static int _id; // variável para armazenar o codigo do pedido
        public IActionResult Index()
        {
            //Enviar a lista de pedidos para a view
            //ViewBag.lista = _banco;
            return View(_banco);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var pedido = _banco.Find(p => p.Codigo == id);
            _banco.Remove(pedido);
            TempData["delete"] = "Pedido Deletado!!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarCategorias();
            //pesquisar pelo codigo
            var pedido = _banco.Find(p => p.Codigo == id);
            return View(pedido);
        }

        [HttpPost]
        public IActionResult Editar(Pedido pedido)
        {
            CarregarCategorias();
            //pesquisar pelo codigo 
            _banco[_banco.FindIndex(p => p.Codigo == pedido.Codigo)] = pedido;
            TempData["up"] = "Pedido Alterado!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarCategorias();
            return View();
        }

        private void CarregarCategorias()
        {
            var lista = new List<string>(new string[] { "Alimento", "Eletronico", "Livro", "Cama mesa e Banho" });
            ViewBag.categorias = new SelectList(lista);
        }

        [HttpPost]
        public IActionResult Cadastrar(Pedido pedido)
        {
            pedido.Codigo = ++_id;
            _banco.Add(pedido);
            TempData["msg"] = "Pedido Registrado!";
            return RedirectToAction("Cadastrar");
        }
    }
}
