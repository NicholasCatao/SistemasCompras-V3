using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Solicitante Solicitante { get; set; }
        public Guid SolicitanteId { get; set; }
        public Fornecedor Fornecedor { get;  set; }
        public Guid FornecedorId { get;  set; }
        public IList<Item> Itens { get;  set; }
        public DateTime Data { get;  private set; }
        public Dinheiro TotalGeral { get; private set; }
        public Situacao Situacao { get;  set; }

        public CondicaoPagamento CondicaoPagamento { get; set; }

        private SolicitacaoCompra() { }

       
        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor, IList<Item> Itens)
        {
            Solicitante =  new Solicitante(usuarioSolicitante);
            Fornecedor = new Fornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
        }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Solicitante = new Solicitante(usuarioSolicitante);
            Fornecedor = new Fornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            Itens.Add(new Item(produto, qtde));
        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {
            if (itens is null || itens.Count() == 0) throw new BusinessRuleException("A solicitação de compra deve possuir itens!");
        }

        public void AdicionarTotalGeral(decimal valor)
        {
            TotalGeral = new Dinheiro(valor);
        }
    }
}
