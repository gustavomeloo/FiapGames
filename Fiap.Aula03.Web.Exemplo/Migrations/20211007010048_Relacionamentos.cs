using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Aula03.Web.Exemplo.Migrations
{
    public partial class Relacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoraId",
                table: "Tbl_Jogo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tbl_Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Jogador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conquistas = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Jogador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Produtora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataFundacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Produtora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Produtora_Tbl_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Tbl_Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Jogo_Jogador",
                columns: table => new
                {
                    JogoId = table.Column<int>(type: "int", nullable: false),
                    JogadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Jogo_Jogador", x => new { x.JogoId, x.JogadorId });
                    table.ForeignKey(
                        name: "FK_Tbl_Jogo_Jogador_Tbl_Jogador_JogadorId",
                        column: x => x.JogadorId,
                        principalTable: "Tbl_Jogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Jogo_Jogador_Tbl_Jogo_JogoId",
                        column: x => x.JogoId,
                        principalTable: "Tbl_Jogo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Jogo_ProdutoraId",
                table: "Tbl_Jogo",
                column: "ProdutoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Jogo_Jogador_JogadorId",
                table: "Tbl_Jogo_Jogador",
                column: "JogadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Produtora_EnderecoId",
                table: "Tbl_Produtora",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Jogo_Tbl_Produtora_ProdutoraId",
                table: "Tbl_Jogo",
                column: "ProdutoraId",
                principalTable: "Tbl_Produtora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Jogo_Tbl_Produtora_ProdutoraId",
                table: "Tbl_Jogo");

            migrationBuilder.DropTable(
                name: "Tbl_Jogo_Jogador");

            migrationBuilder.DropTable(
                name: "Tbl_Produtora");

            migrationBuilder.DropTable(
                name: "Tbl_Jogador");

            migrationBuilder.DropTable(
                name: "Tbl_Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Jogo_ProdutoraId",
                table: "Tbl_Jogo");

            migrationBuilder.DropColumn(
                name: "ProdutoraId",
                table: "Tbl_Jogo");
        }
    }
}
