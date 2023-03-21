using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class AjusteMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CondicaoPagamento",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "NomeFornecedor",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "UsuarioSolicitante",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "TotalGeral",
                table: "SolicitacaoCompra");

            migrationBuilder.AddColumn<Guid>(
                name: "CondicaoPagamentoId",
                table: "SolicitacaoCompra",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NomeFornecedorId",
                table: "SolicitacaoCompra",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TotalGeralId",
                table: "SolicitacaoCompra",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioSolicitanteId",
                table: "SolicitacaoCompra",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produto",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CondicaoPagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Valor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicaoPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Money",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Money", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NomeFornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomeFornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSolicitante",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSolicitante", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoCompra_CondicaoPagamentoId",
                table: "SolicitacaoCompra",
                column: "CondicaoPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoCompra_NomeFornecedorId",
                table: "SolicitacaoCompra",
                column: "NomeFornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoCompra_TotalGeralId",
                table: "SolicitacaoCompra",
                column: "TotalGeralId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoCompra_UsuarioSolicitanteId",
                table: "SolicitacaoCompra",
                column: "UsuarioSolicitanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoCompra_CondicaoPagamento_CondicaoPagamentoId",
                table: "SolicitacaoCompra",
                column: "CondicaoPagamentoId",
                principalTable: "CondicaoPagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoCompra_NomeFornecedor_NomeFornecedorId",
                table: "SolicitacaoCompra",
                column: "NomeFornecedorId",
                principalTable: "NomeFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoCompra_Money_TotalGeralId",
                table: "SolicitacaoCompra",
                column: "TotalGeralId",
                principalTable: "Money",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoCompra_UsuarioSolicitante_UsuarioSolicitanteId",
                table: "SolicitacaoCompra",
                column: "UsuarioSolicitanteId",
                principalTable: "UsuarioSolicitante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoCompra_CondicaoPagamento_CondicaoPagamentoId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoCompra_NomeFornecedor_NomeFornecedorId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoCompra_Money_TotalGeralId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoCompra_UsuarioSolicitante_UsuarioSolicitanteId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropTable(
                name: "CondicaoPagamento");

            migrationBuilder.DropTable(
                name: "Money");

            migrationBuilder.DropTable(
                name: "NomeFornecedor");

            migrationBuilder.DropTable(
                name: "UsuarioSolicitante");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacaoCompra_CondicaoPagamentoId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacaoCompra_NomeFornecedorId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacaoCompra_TotalGeralId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacaoCompra_UsuarioSolicitanteId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "CondicaoPagamentoId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "NomeFornecedorId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "TotalGeralId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "UsuarioSolicitanteId",
                table: "SolicitacaoCompra");

            migrationBuilder.AddColumn<int>(
                name: "CondicaoPagamento",
                table: "SolicitacaoCompra",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFornecedor",
                table: "SolicitacaoCompra",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioSolicitante",
                table: "SolicitacaoCompra",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalGeral",
                table: "SolicitacaoCompra",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produto",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal));
        }
    }
}
