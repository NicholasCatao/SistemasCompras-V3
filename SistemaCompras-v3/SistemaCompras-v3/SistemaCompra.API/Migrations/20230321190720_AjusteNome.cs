using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class AjusteNome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoCompra_NomeFornecedor_NomeFornecedorId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoCompra_UsuarioSolicitante_UsuarioSolicitanteId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropTable(
                name: "NomeFornecedor");

            migrationBuilder.DropTable(
                name: "UsuarioSolicitante");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacaoCompra_NomeFornecedorId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacaoCompra_UsuarioSolicitanteId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "NomeFornecedorId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "UsuarioSolicitanteId",
                table: "SolicitacaoCompra");

            migrationBuilder.AddColumn<Guid>(
                name: "FornecedorId",
                table: "SolicitacaoCompra",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SolicitanteId",
                table: "SolicitacaoCompra",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solicitante",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitante", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoCompra_FornecedorId",
                table: "SolicitacaoCompra",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoCompra_SolicitanteId",
                table: "SolicitacaoCompra",
                column: "SolicitanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoCompra_Fornecedor_FornecedorId",
                table: "SolicitacaoCompra",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoCompra_Solicitante_SolicitanteId",
                table: "SolicitacaoCompra",
                column: "SolicitanteId",
                principalTable: "Solicitante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoCompra_Fornecedor_FornecedorId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoCompra_Solicitante_SolicitanteId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Solicitante");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacaoCompra_FornecedorId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacaoCompra_SolicitanteId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "SolicitanteId",
                table: "SolicitacaoCompra");

            migrationBuilder.AddColumn<Guid>(
                name: "NomeFornecedorId",
                table: "SolicitacaoCompra",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioSolicitanteId",
                table: "SolicitacaoCompra",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "NomeFornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomeFornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSolicitante",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSolicitante", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoCompra_NomeFornecedorId",
                table: "SolicitacaoCompra",
                column: "NomeFornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoCompra_UsuarioSolicitanteId",
                table: "SolicitacaoCompra",
                column: "UsuarioSolicitanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoCompra_NomeFornecedor_NomeFornecedorId",
                table: "SolicitacaoCompra",
                column: "NomeFornecedorId",
                principalTable: "NomeFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoCompra_UsuarioSolicitante_UsuarioSolicitanteId",
                table: "SolicitacaoCompra",
                column: "UsuarioSolicitanteId",
                principalTable: "UsuarioSolicitante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
