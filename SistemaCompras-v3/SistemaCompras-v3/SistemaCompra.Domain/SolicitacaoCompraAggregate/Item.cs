using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using System;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class Item : Entity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public Produto Produto { get; set; }
        public int Qtde { get; set; }

        public Dinheiro Subtotal => ObterSubtotal();

        public Item(Produto produto, int qtde)
        {
            Produto = produto ?? throw new ArgumentNullException(nameof(produto));
            Qtde = qtde;
        }

        private Dinheiro ObterSubtotal()
        {
            return new Dinheiro(Produto.Preco * Qtde);
        }

        private Item() { }

    }
}
