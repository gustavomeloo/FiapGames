using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo.Models
{
    [Table("Tbl_Endereco")]
    public class Endereco
    {
        [Column("Id"), HiddenInput]
        public int EnderecoId { get; set; }

        public string Logradouro { get; set; }

        public string Cep { get; set; }


    }
}
