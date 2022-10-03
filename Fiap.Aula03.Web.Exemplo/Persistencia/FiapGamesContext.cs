using Fiap.Aula03.Web.Exemplo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Aula03.Web.Exemplo.Persistencia
{
    //Classe que gerencia as entidades
    public class FiapGamesContext : DbContext
    {

        public DbSet<Jogo> Jogos { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Produtora> Produtoras { get; set; }

        public DbSet<Jogador> Jogadores { get; set; }

        public DbSet<JogoJogador> JogosJogadores { get; set; }

        //Construtor que recebe a string de conexão
        public FiapGamesContext( DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurar a chave composta da tabela associativa
            modelBuilder.Entity<JogoJogador>().HasKey(j => new { j.JogoId, j.JogadorId });

            //Configurar o relacionamento da associativa com o jogador
            modelBuilder.Entity<JogoJogador>()
                .HasOne(j => j.Jogador) //Associativa possui um
                .WithMany(j => j.JogoJogadores) // Com varios
                .HasForeignKey(j => j.JogadorId); //FK

            //Configurar o relacionamento da associativa com o jogo
            modelBuilder.Entity<JogoJogador>()
                .HasOne(j => j.Jogo)
                .WithMany(j => j.JogoJogadores)
                .HasForeignKey(j => j.JogoId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
