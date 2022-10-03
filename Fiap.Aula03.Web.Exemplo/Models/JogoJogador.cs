using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo.Models
{
    //Classe que mapeia a tabela associativa
    [Table("Tbl_Jogo_Jogador")]
    public class JogoJogador
    {

        public Jogo Jogo { get; set; }

        public int JogoId { get; set; }

        public Jogador Jogador { get; set; }

        public int JogadorId { get; set; }

    }
}
