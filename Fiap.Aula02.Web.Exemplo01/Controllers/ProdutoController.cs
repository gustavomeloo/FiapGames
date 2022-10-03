using Fiap.Aula02.Web.Exemplo01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula02.Web.Exemplo01.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet] //abrir a pagina com o formulario html
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost] // receber os dados do formulário e adicionar no model
        public IActionResult Cadastrar(Produto produto)
        {

            //Enviar informações para view 
            TempData["nome"] = produto.Nome;
            //TempData["Preco"] = produto.Preco;

            ViewBag.quantidade = produto.Quantidade;
            ViewBag.prod = produto;

            //return RedirectToAction("Cadastrar"); //Redirect para a action cadastrar

            //Enviar o pbjeto produto para a view
            return View(produto); //forward
            //retornar um texto no browser
            //return Content($"Nome: {produto.Nome}, Preco: {produto.Preco}, Quantidade: {produto.Quantidade} ");
        }

        /**
         *Criar uma action que atende a URL /produto/cadastrar  
         *form
         */
    }
}
