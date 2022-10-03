using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo.Models
{
    [Table("Tbl_Produtora")]
    public class Produtora
    {

        [Column("Id"), HiddenInput]
        public int ProdutoraId { get; set; }

        public string Nome { get; set; }

        [DataType(DataType.Date)][Display(Name = "Data Fundação")]
        public DateTime DataFundacao { get; set; }
        
        //1:N
        public virtual ICollection<Jogo> Jogos { get; set; }

        //1:1
        public Endereco Endereco { get; set; }

        public int EnderecoId { get; set; }

    }
}
