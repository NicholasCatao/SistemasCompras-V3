using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<Guid>
    {
        [Required]
        public string UsuarioSolicitante { get; set; }
        [Required]
        public string NomeFornecedor { get; set; }

      // [Required(ErrorMessage = "Informe pelo menos um item.")] opção de validação 
        public IList<Item> Itens { get; set; }
    }
}
