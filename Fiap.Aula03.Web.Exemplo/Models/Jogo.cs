using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo.Models
{
    [Table("Tbl_Jogo")]
    public class Jogo
    {
        [Column("Id"), HiddenInput]
        public int JogoId { get; set; }
        //Maximo caracteres "MaxLength()"
        [Required, MaxLength(80)]
        public string Nome { get; set; }

        //N:1
        public Produtora Produtora { get; set; }

        public int? ProdutoraId { get; set; }

        public bool? Multiplataforma { get; set; }
        [Required]
        public Plataforma Plataforma { get; set; }

        [DataType(DataType.Date)] [Display(Name = "Data Lançamento")]
        [Column("Data_Lancamento")]
        public DateTime? DataLancamento { get; set; }
        public decimal? Valor { get; set; }

        //N:M
        public ICollection<JogoJogador> JogoJogadores { get; set; }

    }

    public enum Plataforma 
    {
        Pc, Mobile, Xbox, Playstation
    }


}
