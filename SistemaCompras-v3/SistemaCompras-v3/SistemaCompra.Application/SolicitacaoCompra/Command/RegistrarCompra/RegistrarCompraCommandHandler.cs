using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Threading;
using System.Threading.Tasks;
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


            await _solicitacaoCompraRepository.RegistrarCompraAsync(solicitacao);

            Commit();
            PublishEvents(solicitacao.Events);

            return solicitacao.Id;
        }
    }
}
