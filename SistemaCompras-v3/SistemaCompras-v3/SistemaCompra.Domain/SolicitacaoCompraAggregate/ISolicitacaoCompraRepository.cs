using System.Threading.Tasks;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public interface ISolicitacaoCompraRepository
    {
        Task RegistrarCompraAsync(SolicitacaoCompra solicitacaoCompra);
    }
}
