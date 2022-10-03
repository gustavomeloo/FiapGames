using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Aula03.Web.Exemplo.Migrations
{
    public partial class produtoranull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Jogo_Tbl_Produtora_ProdutoraId",
                table: "Tbl_Jogo");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoraId",
                table: "Tbl_Jogo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Jogo_Tbl_Produtora_ProdutoraId",
                table: "Tbl_Jogo",
                column: "ProdutoraId",
                principalTable: "Tbl_Produtora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Jogo_Tbl_Produtora_ProdutoraId",
                table: "Tbl_Jogo");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoraId",
                table: "Tbl_Jogo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Jogo_Tbl_Produtora_ProdutoraId",
                table: "Tbl_Jogo",
                column: "ProdutoraId",
                principalTable: "Tbl_Produtora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
