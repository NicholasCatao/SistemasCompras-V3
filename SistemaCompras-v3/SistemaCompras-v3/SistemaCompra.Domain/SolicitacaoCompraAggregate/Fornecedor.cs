using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class Fornecedor: Entity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public ICollection<SolicitacaoCompra> SolicitacaoCompras { get; set; }

        public Fornecedor() 
        {
            SolicitacaoCompras = new Collection<SolicitacaoCompra>();
        }

        public Fornecedor(string nome)
        {
            if (String.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));
            if (nome.Length < 10) throw new BusinessRuleException("Nome de fornecedor deve ter pelo menos 10 caracteres.");

            Nome = nome;
        }
    }
}
