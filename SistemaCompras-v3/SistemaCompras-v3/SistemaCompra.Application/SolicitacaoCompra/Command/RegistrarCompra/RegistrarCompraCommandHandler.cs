using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Threading;
using System.Threading.Tasks;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, Guid>
    {
        private readonly ISolicitacaoCompraRepository _solicitacaoCompraRepository;

        public RegistrarCompraCommandHandler(ISolicitacaoCompraRepository solicitacaoCompraRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            _solicitacaoCompraRepository = solicitacaoCompraRepository;
        }

        public async Task<Guid> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var solicitacao = new SolicitacaoAgg.SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor, request.Itens);


            foreach (var item in request.Itens)
            {
                var produto = new ProdutoAgg.Produto
                {
                    Categoria = item.Produto.Categoria,
                    Descricao = item.Produto.Descricao,
                    Nome = item.Produto.Nome,
                    Preco = item.Produto.Preco,
                    Situacao = item.Produto.Situacao
                };

                solicitacao.AdicionarTotalGeral(item.Subtotal.Valor);

                if (item.Subtotal.Valor > 5000m) solicitacao.CondicaoPagamento = new CondicaoPagamento(30);
            }

            await _solicitacaoCompraRepository.RegistrarCompraAsync(solicitacao);

            Commit();
            PublishEvents(solicitacao.Events);

            return solicitacao.Id;
        }
    }
}
