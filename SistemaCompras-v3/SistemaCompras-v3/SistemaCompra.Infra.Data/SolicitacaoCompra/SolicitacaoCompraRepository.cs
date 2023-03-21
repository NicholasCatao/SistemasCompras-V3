using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System.Threading.Tasks;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
   
    public class SolicitacaoCompraRepository : ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext _context;

        public SolicitacaoCompraRepository(SistemaCompraContext context)
        {
            _context = context;
        }

        public async Task RegistrarCompraAsync(SolicitacaoAgg.SolicitacaoCompra entity)
         => await _context.Set<SolicitacaoAgg.SolicitacaoCompra>().AddAsync(entity);
    }
}
