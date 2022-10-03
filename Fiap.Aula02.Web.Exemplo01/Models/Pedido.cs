using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula02.Web.Exemplo01.Models
{

    /**
     * Criar a pagina de cadastro utilizando taghelpers
     * Armazenar o Pedido em uma lista no Controller
     *      private static Ilist<Pedido> _banco;
     * Criar uma página para listar todos os pedidos
     */

    public class Pedido
    {
        [HiddenInput]
        public int Codigo { get; set; }
        public decimal Valor { get; set; }

        //Defini o tipo do campo HTML que será gerado
        [DataType(DataType.Date), Display(Name = "Data Venda")]
        public DateTime Data { get; set; }

        //Defini o texto do label no HTML
        [Display(Name = "Nome do Cliente")]
        public string Cliente { get; set; }
        public bool Pago { get; set; }

        [Display(Name = "Opção de Pagamento")]
        public TipoPagamento TipoPagamento { get; set; }

        public string Categoria { get; set; }




        public override string ToString()
        {
            return $"cliente: {Cliente}, valor: {Valor}";
        }


    }

    public enum TipoPagamento
    {
        Debito, Cartao, Dinheiro, Pix, Boleto
    }
}
