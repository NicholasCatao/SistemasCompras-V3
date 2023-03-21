using FluentValidation;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;

namespace SistemaCompra.Application.Validadores
{
    public class SolicitacaoValidator : AbstractValidator<RegistrarCompraCommand>
    {
        public SolicitacaoValidator()
        {
            RuleSet(ValidationRules.Incluir, () =>
            {
                Validaritens();
            });
        }

        private void Validaritens()
        {
            RuleFor(x => x.Itens.Count).GreaterThan(0).WithMessage("A solicitação de compra deve possuir itens!");
        }
    }
}
