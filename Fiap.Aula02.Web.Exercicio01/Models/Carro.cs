using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula02.Web.Exercicio01.Models
{
    public class Carro
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }

        [DataType(DataType.Date)] [Display(Name = "Data de Fabricação") ]
        public DateTime FabricationDate { get; set; }

        public string Ano { get; set; }

        [Display(Name = "Valor")]
        public decimal Value { get; set; }

        [Display(Name = "Tipo de Combustivel")]
        public TipoCombustivel  Tipo { get; set; }

        public bool Automatic { get; set; }

    }

    public enum TipoCombustivel
    {
        Alcool, Gasolina, Etanol, Hibrido
    }
}
