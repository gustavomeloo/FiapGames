using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo.Models
{
    [Table("Tbl_Jogador")]
    public class Jogador
    {
        [Column("Id"), HiddenInput]
        public int JogadorId { get; set; }

        public string Nome { get; set; }

        [Required]
        public string NickName { get; set; }

        public int Conquistas { get; set; }

        public Genero Genero { get; set; }

        //N:M
        public ICollection<JogoJogador> JogoJogadores { get; set; }

    }

    public enum Genero
    {
        Masculino, Feminino
    }
}
