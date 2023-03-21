using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class AjusteMoney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoCompra_Money_TotalGeralId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropTable(
                name: "Money");

            migrationBuilder.CreateTable(
                name: "Dinheiro",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Moeda = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dinheiro", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoCompra_Dinheiro_TotalGeralId",
                table: "SolicitacaoCompra",
                column: "TotalGeralId",
                principalTable: "Dinheiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoCompra_Dinheiro_TotalGeralId",
                table: "SolicitacaoCompra");

            migrationBuilder.DropTable(
                name: "Dinheiro");

            migrationBuilder.CreateTable(
                name: "Money",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Money", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoCompra_Money_TotalGeralId",
                table: "SolicitacaoCompra",
                column: "TotalGeralId",
                principalTable: "Money",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
