using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula02.Web.Exemplo01.Models
{
    public class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }

        public Produto() { }

        public Produto( string nome, decimal preco, int quantidade )
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

    }
}
